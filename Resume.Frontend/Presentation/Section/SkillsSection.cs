using Resume.Abstraction.Interfaces.Services;

namespace Resume.Frontend.Presentation.Section;

public partial class SkillsSection : Border
{
    public SkillsSection(IEntityService entityService)
    {
        DataContext = new SkillsSectionViewModel();

        var logic = new SkillsSectionLogic((SkillsSectionViewModel)DataContext);
        var ui = new SkillsSectionUi(logic, (SkillsSectionViewModel)DataContext, entityService);

        this.Background(Theme.Brushes.Background.Default).Child(ui.CreateContentGrid());
    }
}
