using Resume.Abstraction.Interfaces.Services;
using Resume.Services;

namespace Resume.Frontend.Presentation.Section;

public partial class SkillsSection : Border
{
    public SkillsSection(IEntityService entityService, ILocaleService localeService)
    {
        DataContext = new SkillsSectionViewModel();

        var logic = new SkillsSectionLogic((SkillsSectionViewModel)DataContext);
        var ui = new SkillsSectionUi(logic, (SkillsSectionViewModel)DataContext, entityService, localeService);

        this.Background(Theme.Brushes.Background.Default).Child(ui.CreateContentGrid());
    }
}
