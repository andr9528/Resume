using Resume.Frontend.Presentation.Core;

namespace Resume.Frontend.Presentation.Section;

public partial class SkillsSection
{
    private class SkillsSectionLogic : BaseLogic<SkillsSectionViewModel>
    {
        public SkillsSectionLogic(SkillsSectionViewModel viewModel) : base(viewModel)
        {
        }
    }
}
