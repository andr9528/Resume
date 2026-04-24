using Resume.Frontend.Presentation.Core;

namespace Resume.Frontend.Presentation.Section;

public partial class ProjectsSection
{
    private class ProjectsSectionLogic : BaseLogic<ProjectsSectionViewModel>
    {
        public ProjectsSectionLogic(ProjectsSectionViewModel viewModel) : base(viewModel)
        {
        }
    }
}
