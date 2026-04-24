using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Presentation.Core;

namespace Resume.Frontend.Presentation.Section;

public partial class CoursesSection
{
    private class CoursesSectionUi : BaseUi<CoursesSectionLogic, CoursesSectionViewModel>
    {
        private readonly ILocaleService localeService;

        /// <inheritdoc />
        public CoursesSectionUi(
            CoursesSectionLogic logic, CoursesSectionViewModel viewModel, IEntityService entityService,
            ILocaleService localeService) : base(
            logic, viewModel, entityService)
        {
            this.localeService = localeService;
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
            // TODO: Add CoursesSection controls.
        }
    }
}
