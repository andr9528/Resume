using Resume.Frontend.Presentation.Core;

namespace Resume.Frontend.Presentation.Section;

public partial class LanguagesSection
{
    private class LanguagesSectionLogic : BaseLogic<LanguagesSectionViewModel>
    {
        public LanguagesSectionLogic(LanguagesSectionViewModel viewModel) : base(viewModel)
        {
        }
    }
}
