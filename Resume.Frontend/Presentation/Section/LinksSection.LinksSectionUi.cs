using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Presentation.Core;

namespace Resume.Frontend.Presentation.Section;

public partial class LinksSection
{
    private class LinksSectionUi : BaseUi<LinksSectionLogic, LinksSectionViewModel>
    {
        /// <inheritdoc />
        public LinksSectionUi(
            LinksSectionLogic logic, LinksSectionViewModel viewModel, IEntityService entityService) : base(
            logic, viewModel, entityService)
        {
        }

        /// <inheritdoc />
        protected override void ConfigureGrid(Grid grid)
        {
            grid.SafeArea(SafeArea.InsetMask.VisibleBounds);
            grid.RowDefinitions(GridLength.Auto);
        }

        /// <inheritdoc />
        protected override void AddControlsToGrid(Grid grid)
        {
            // TODO: Add LinksSection controls.
        }
    }
}
