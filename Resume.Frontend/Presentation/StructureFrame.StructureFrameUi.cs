using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Presentation.Core;
using Resume.Frontend.Presentation.Section;
using Resume.Frontend.Extensions;

namespace Resume.Frontend.Presentation;

public partial class StructureFrame
{
    private class StructureFrameUi : BaseUi<StructureFrameLogic, StructureFrameViewModel>
    {
        private const int OUTER_MARGIN_COLUMN_WIDTH = 10;
        private const int CONTENT_DIVIDER_COLUMN_WIDTH = 4;
        private const int CONTENT_COLUMN_ONE_WIDTH = 43;
        private const int CONTENT_COLUMN_TWO_WIDTH = 33;
        private readonly int[] gridColumnWidths =
        [
            OUTER_MARGIN_COLUMN_WIDTH, CONTENT_COLUMN_ONE_WIDTH, CONTENT_DIVIDER_COLUMN_WIDTH, CONTENT_COLUMN_TWO_WIDTH, OUTER_MARGIN_COLUMN_WIDTH,
        ];

        public StructureFrameUi(StructureFrameLogic logic, StructureFrameViewModel viewModel, IEntityService entityService) : base(logic,
            viewModel, entityService)
        {
        }

        protected override void ConfigureGrid(Grid grid)
        {
            grid.SafeArea(SafeArea.InsetMask.VisibleBounds);
            grid.ColumnDefinitions(gridColumnWidths.Select(x => new GridLength(x, GridUnitType.Star)).ToArray());
            grid.RowDefinitions(GridLength.Auto);
        }

        protected override void AddControlsToGrid(Grid grid)
        {
            var columnOneContent = CreateAndFillColumnOne();
            var columnTwoContent = CreateAndFillColumnTwo();

            grid.Children.Add(columnOneContent);
            grid.Children.Add(columnTwoContent);
        }

        private Grid CreateAndFillColumnOne()
        {
            var columnOne = new Grid().SetColumn(1).SetRow(0);

            EmploymentSection employmentSection = new EmploymentSection(EntityService).SetRow(0);
            EducationSection educationSection = new EducationSection(EntityService).SetRow(1);
            CoursesSection coursesSection = new CoursesSection(EntityService).SetRow(2);
            ProjectsSection projectsSection = new ProjectsSection(EntityService).SetRow(3);
            ReferencesSection referencesSection = new ReferencesSection(EntityService).SetRow(4);

            columnOne.Add(employmentSection);
            columnOne.Add(educationSection);
            columnOne.Add(coursesSection);
            columnOne.Add(projectsSection);
            columnOne.Add(referencesSection);

            return columnOne;
        }

        private Grid CreateAndFillColumnTwo()
        {
            var columnTwo = new Grid().SetColumn(3).SetRow(0);

            GeneralSection generalSection = new GeneralSection(EntityService).SetRow(0);
            LinksSection linksSection = new LinksSection(EntityService).SetRow(1);
            SkillsSection skillsSection = new SkillsSection(EntityService).SetRow(2);
            LanguagesSection languagesSection = new LanguagesSection(EntityService).SetRow(3);

            columnTwo.Add(generalSection);
            columnTwo.Add(linksSection);
            columnTwo.Add(skillsSection);
            columnTwo.Add(languagesSection);

            return columnTwo;
        }

        internal ScrollViewer CreateScrollView()
        {
            var scrollView = new ScrollViewer
            {
                HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden,
                VerticalScrollBarVisibility = ScrollBarVisibility.Auto,
                Margin = new Thickness(80, 0),
            };

            scrollView.Content(CreateContentGrid());

            return scrollView;
        }
    }
}
