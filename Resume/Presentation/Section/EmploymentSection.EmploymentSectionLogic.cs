using Resume.Presentation.Core;

namespace Resume.Presentation.Section;

public partial class EmploymentSection
{
    private class EmploymentSectionLogic : BaseLogic<EmploymentSectionViewModel>
    {
        public EmploymentSectionLogic(EmploymentSectionViewModel viewModel) : base(viewModel)
        {
        }
    }
}
