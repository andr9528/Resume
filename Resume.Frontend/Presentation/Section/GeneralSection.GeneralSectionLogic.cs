using Resume.Frontend.Presentation.Core;

namespace Resume.Frontend.Presentation.Section;

public partial class GeneralSection
{
    private class GeneralSectionLogic : BaseLogic<GeneralSectionViewModel>
    {
        public GeneralSectionLogic(GeneralSectionViewModel viewModel) : base(viewModel)
        {
        }
    }
}
