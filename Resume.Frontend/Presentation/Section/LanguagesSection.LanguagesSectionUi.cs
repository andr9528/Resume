using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Presentation.Core;

namespace Resume.Frontend.Presentation.Section;

public partial class LanguagesSection
{
    private class LanguagesSectionUi : BaseUi<LanguagesSectionLogic, LanguagesSectionViewModel>
    {
        /// <inheritdoc />
        public LanguagesSectionUi(
            LanguagesSectionLogic logic, LanguagesSectionViewModel viewModel, IEntityService entityService) : base(
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
            // TODO: Add LanguagesSection controls.
        }
    }
}
