using Resume.Abstraction.Interfaces.Resume;
using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Presentation.Core;
using Resume.Frontend.Presentation.Factory;

namespace Resume.Frontend.Presentation.Section;

public partial class EmploymentSection
{
    private class EmploymentSectionUi : BaseUi<EmploymentSectionLogic, EmploymentSectionViewModel>
    {
        private readonly ILocaleService localeService;

        /// <inheritdoc />
        public EmploymentSectionUi(
            EmploymentSectionLogic logic, EmploymentSectionViewModel viewModel, IEntityService entityService,
            ILocaleService localeService) : base(
            logic, viewModel, entityService)
        {
            this.localeService = localeService;
        }

        /// <inheritdoc />
        protected override void ConfigureGrid(Grid grid)
        {
            grid.SafeArea(SafeArea.InsetMask.VisibleBounds);
            grid.RowDefinitions(Enumerable
                .Repeat(new GridLength(10, GridUnitType.Auto), EntityService.GetEmployments().Count).ToArray());
        }

        /// <inheritdoc />
        protected override void AddControlsToGrid(Grid grid)
        {
            var pieces = EntityService.GetEmployments()
                .Select((employment, index) => BuildPiece(employment).Grid(row: index, column: 0));

            grid.Children.AddRange(pieces);
        }

        private StackPanel BuildPiece(IEmployment employment)
        {
            StackPanel panel = StackPanelFactory.CreateDefaultPanel();
            panel.Orientation = Orientation.Vertical;

            TextBlock pieceHeader = BuildPieceHeader(employment);
            TextBlock pieceSubHeader = BuildPieceSubHeader(employment);
            TextBlock pieceDescription = BuildPieceDescription(employment);
            ListView? pieceLinks = BuildPieceLinks(employment);

            panel.Children.Add(pieceHeader);
            panel.Children.Add(pieceSubHeader);
            panel.Children.Add(pieceDescription);

            if (pieceLinks != null)
            {
                panel.Children.Add(pieceLinks);
            }

            return panel;
        }

        private ListView? BuildPieceLinks(IEmployment employment)
        {
            if (employment.Links == null || !employment.Links.Any())
            {
                return null;
            }

            var listView = new ListView
            {
                HorizontalAlignment = HorizontalAlignment.Left,
            };
            var items = employment.Links.Select(link => new ListViewItem
            {
                Content = link,
            });
            listView.Items.AddRange(items);

            return listView;
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
