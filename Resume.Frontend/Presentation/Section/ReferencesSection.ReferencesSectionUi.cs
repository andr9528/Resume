using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Presentation.Core;

namespace Resume.Frontend.Presentation.Section;

public partial class ReferencesSection
{
    private class ReferencesSectionUi : BaseUi<ReferencesSectionLogic, ReferencesSectionViewModel>
    {
        /// <inheritdoc />
        public ReferencesSectionUi(
            ReferencesSectionLogic logic, ReferencesSectionViewModel viewModel, IEntityService entityService) : base(
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
            // TODO: Add ReferencesSection controls.
        }
    }
}
