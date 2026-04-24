using Resume.Frontend.Presentation.Core;

namespace Resume.Frontend.Presentation.Section;

public partial class EducationSection
{
    private class EducationSectionLogic : BaseLogic<EducationSectionViewModel>
    {
        public EducationSectionLogic(EducationSectionViewModel viewModel) : base(viewModel)
        {
        }
    }
}
