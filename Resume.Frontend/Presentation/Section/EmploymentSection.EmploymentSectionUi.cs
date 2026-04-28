using Resume.Abstraction.Enums.Keys;
using Resume.Abstraction.Interfaces.Resume;
using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Extensions;
using Resume.Frontend.Presentation.Core;
using Resume.Frontend.Presentation.Factory;
using Resume.Models.Extensions;
using Resume.Models.Resume;

namespace Resume.Frontend.Presentation.Section;

public partial class EmploymentSection
{
    private class EmploymentSectionUi : BaseUi<EmploymentSectionLogic, EmploymentSectionViewModel>
    {
        private readonly ILocaleService localeService;

        /// <inheritdoc />
        public EmploymentSectionUi(
            EmploymentSectionLogic logic, EmploymentSectionViewModel viewModel, IEntityService entityService,
            ILocaleService localeService) : base(logic, viewModel, entityService)
        {
            this.localeService = localeService;
        }

        /// <inheritdoc />
        protected override void ConfigureGrid(Grid grid)
        {
            int employmentCount = EntityService.GetEmployments().Count;

            grid.SafeArea(SafeArea.InsetMask.VisibleBounds);
            grid.RowDefinitions(Enumerable.Repeat(new GridLength(10, GridUnitType.Auto), employmentCount + 1)
                .ToArray());
        }

        /// <inheritdoc />
        protected override void AddControlsToGrid(Grid grid)
        {
            TextBlock sectionHeader = TextBlockFactory.BuildSectionHeader(
                localeService.GetLocalizedString(UserInterfaceKey.EMPLOYMENT_HEADER.ToKey())).SetRow(0);
            var pieces = EntityService.GetEmployments()
                .Select((employment, index) => BuildPiece(employment).Grid(row: index + 1, column: 0));

            grid.Children.Add(sectionHeader);
            grid.Children.AddRange(pieces);
        }

        private Border BuildPiece(IEmployment employment)
        {
            StackPanel panel = StackPanelFactory.CreateDefaultPanel();
            panel.Orientation = Orientation.Vertical;

            TextBlock pieceHeader = BuildPieceHeader(employment);
            TextBlock pieceSubHeader = BuildPieceSubHeader(employment);
            TextBlock pieceDescription = BuildPieceDescription(employment);
            ListView? links = ListViewFactory.BuildLinksListView(employment.Links);

            panel.Children.Add(pieceHeader);
            panel.Children.Add(pieceSubHeader);
            panel.Children.Add(pieceDescription);

            if (links != null)
            {
                panel.Children.Add(links);
            }

            return panel.WrapWithTopBorder();
        }

        private TextBlock BuildPieceDescription(IEmployment employment)
        {
            return new TextBlock
            {
                Text = employment.WorkDescription,
                FontSize = 14,
                Margin = new Thickness(0, 0, 0, 10),
                TextWrapping = TextWrapping.WrapWholeWords,
                HorizontalAlignment = HorizontalAlignment.Stretch,
            };
        }

        private TextBlock BuildPieceSubHeader(IEmployment employment)
        {
            string end = employment.EndDate != null ? $"{employment.EndDate:MMM yyyy}" : "TEMP";
            return new TextBlock
            {
                Text = $"{employment.City}, {employment.StartDate:MMM yyyy} - {end}, {employment.EmploymentType}",
                FontSize = 14,
                Margin = new Thickness(0, 0, 0, 10),
            };
        }

        private TextBlock BuildPieceHeader(IEmployment employment)
        {
            return new TextBlock
            {
                Text = $"{employment.JobTitle} - {employment.Employer}",
                FontSize = 18,
                Margin = new Thickness(0, 0, 0, 10),
            };
        }
    }
}
