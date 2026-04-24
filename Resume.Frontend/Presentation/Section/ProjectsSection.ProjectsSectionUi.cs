using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Presentation.Core;

namespace Resume.Frontend.Presentation.Section;

public partial class ProjectsSection
{
    private class ProjectsSectionUi : BaseUi<ProjectsSectionLogic, ProjectsSectionViewModel>
    {
        /// <inheritdoc />
        public ProjectsSectionUi(
            ProjectsSectionLogic logic, ProjectsSectionViewModel viewModel, IEntityService entityService,
            ILocaleService localeService) : base(
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
            // TODO: Add ProjectsSection controls.
        }
    }
}
