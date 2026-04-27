using Resume.Abstraction.Enums.Keys;
using Resume.Abstraction.Interfaces.Resume;
using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Extensions;
using Resume.Frontend.Presentation.Core;
using Resume.Frontend.Presentation.Factory;
using Resume.Models.Extensions;

namespace Resume.Frontend.Presentation.Section;

public partial class CoursesSection
{
    private class CoursesSectionUi : BaseUi<CoursesSectionLogic, CoursesSectionViewModel>
    {
        private readonly ILocaleService localeService;

        /// <inheritdoc />
        public CoursesSectionUi(
            CoursesSectionLogic logic,
            CoursesSectionViewModel viewModel,
            IEntityService entityService,
            ILocaleService localeService) : base(logic, viewModel, entityService)
        {
            this.localeService = localeService;
        }

        /// <inheritdoc />
        protected override void ConfigureGrid(Grid grid)
        {
            int courseCount = EntityService.GetCourses().Count;

            grid.SafeArea(SafeArea.InsetMask.VisibleBounds);
            grid.RowDefinitions(Enumerable.Repeat(new GridLength(10, GridUnitType.Auto), courseCount + 1).ToArray());
        }

        /// <inheritdoc />
        protected override void AddControlsToGrid(Grid grid)
        {
            var sectionHeader = TextBlockFactory.BuildSectionHeader(
                localeService.GetLocalizedString(UserInterfaceKey.COURSES_HEADER.ToKey())).SetRow(0);

            var pieces = EntityService.GetCourses()
                .Select((course, index) => BuildPiece(course).Grid(row: index + 1, column: 0));

            grid.Children.Add(sectionHeader);
            grid.Children.AddRange(pieces);
        }

        private StackPanel BuildPiece(ICourse course)
        {
            StackPanel panel = StackPanelFactory.CreateDefaultPanel();
            panel.Orientation = Orientation.Vertical;

            panel.Children.Add(BuildPieceHeader(course));
            panel.Children.Add(BuildPieceSubHeader(course));
            panel.Children.Add(BuildPieceDescription(course));

            return panel;
        }

        private TextBlock BuildPieceHeader(ICourse course)
        {
            return new TextBlock
            {
                Text = course.Name,
                FontSize = 18,
                Margin = new Thickness(0, 0, 0, 5),
                VerticalAlignment = VerticalAlignment.Top,
            };
        }

        private TextBlock BuildPieceSubHeader(ICourse course)
        {
            string end = course.EndDate is not null ? $"{course.EndDate:MMM yyyy}" : "TEMP";

            return new TextBlock
            {
                Text = $"{course.StartDate:MMM yyyy} - {end}",
                FontSize = 14,
                Margin = new Thickness(0, 0, 0, 5),
                VerticalAlignment = VerticalAlignment.Top,
            };
        }

        private TextBlock BuildPieceDescription(ICourse course)
        {
            return new TextBlock
            {
                Text = course.Description,
                FontSize = 14,
                Margin = new Thickness(0, 0, 0, 10),
                TextWrapping = TextWrapping.WrapWholeWords,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Top,
            };
        }
    }
}
