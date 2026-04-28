using Resume.Abstraction.Enums.Keys;
using Resume.Abstraction.Interfaces.Resume;
using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Extensions;
using Resume.Frontend.Presentation.Core;
using Resume.Frontend.Presentation.Factory;
using Resume.Models.Extensions;

namespace Resume.Frontend.Presentation.Section;

public partial class LinksSection
{
    private class LinksSectionUi : BaseUi<LinksSectionLogic, LinksSectionViewModel>
    {
        private readonly ILocaleService localeService;

        /// <inheritdoc />
        public LinksSectionUi(
            LinksSectionLogic logic, LinksSectionViewModel viewModel, IEntityService entityService,
            ILocaleService localeService) : base(logic, viewModel, entityService)
        {
            this.localeService = localeService;
        }

        /// <inheritdoc />
        protected override void ConfigureGrid(Grid grid)
        {
            int linkCount = EntityService.GetLinks().Count;

            grid.SafeArea(SafeArea.InsetMask.VisibleBounds);
            grid.RowDefinitions(Enumerable.Repeat(new GridLength(10, GridUnitType.Auto), linkCount + 1).ToArray());
        }

        /// <inheritdoc />
        protected override void AddControlsToGrid(Grid grid)
        {
            TextBlock sectionHeader = TextBlockFactory.BuildSectionHeader(
                localeService.GetLocalizedString(UserInterfaceKey.LINKS_HEADER.ToKey())).SetRow(0);
            var pieces = EntityService.GetLinks()
                .Select((link, index) => BuildPiece(link).Grid(row: index + 1, column: 0));

            grid.Children.Add(sectionHeader);
            grid.Children.AddRange(pieces);
        }

        private Grid BuildPiece(ILink link)
        {
            const int headerRowSize = 1;
            const int remarkRowSize = 1;
            const int urlRowSize = 1;

            bool hasRemark = !string.IsNullOrWhiteSpace(link.Remark);
            int[] rowSizes = hasRemark
                ? new[] {headerRowSize, remarkRowSize, urlRowSize,}
                : new[] {headerRowSize, urlRowSize,};

            Grid grid = GridFactory.CreateDefaultGrid().DefineRows(GridUnitType.Auto, rowSizes);

            grid.Children.Add(BuildTitle(link).Grid(row: 0, column: 0));

            if (hasRemark)
            {
                grid.Children.Add(BuildRemark(link).Grid(row: 1, column: 0));
                grid.Children.Add(BuildUrl(link).Grid(row: 2, column: 0));
            }
            else
            {
                grid.Children.Add(BuildUrl(link).Grid(row: 1, column: 0));
            }

            return grid;
        }

        private TextBlock BuildTitle(ILink link)
        {
            return new TextBlock
            {
                Text = link.Title,
                FontSize = 18,
                Margin = new Thickness(10, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Center,
            };
        }

        private TextBlock BuildRemark(ILink link)
        {
            return new TextBlock
            {
                Text = link.Remark,
                FontSize = 16,
                Margin = new Thickness(20, 0, 0, 0),
                VerticalAlignment = VerticalAlignment.Center,
                TextWrapping = TextWrapping.Wrap,
            };
        }

        private HyperlinkButton BuildUrl(ILink link)
        {
            HyperlinkButton button = ButtonFactory.BuildHyperlinkButton(link.Url);

            button.Margin = new Thickness(10, 0, 0, 5);

            if (button.Content is TextBlock textBlock)
            {
                textBlock.FontSize = 16;
            }

            return button;
        }
    }
}
