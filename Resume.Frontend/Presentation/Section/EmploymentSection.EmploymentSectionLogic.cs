using Resume.Frontend.Presentation.Core;

namespace Resume.Frontend.Presentation.Section;

public partial class EmploymentSection
{
    private class EmploymentSectionLogic : BaseLogic<EmploymentSectionViewModel>
    {
        public EmploymentSectionLogic(EmploymentSectionViewModel viewModel) : base(viewModel)
        {
        }
    }
}
