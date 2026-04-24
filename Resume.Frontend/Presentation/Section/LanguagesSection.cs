using Resume.Abstraction.Interfaces.Services;

namespace Resume.Frontend.Presentation.Section;

public partial class LanguagesSection : Border
{
    public LanguagesSection(IEntityService entityService)
    {
        DataContext = new LanguagesSectionViewModel();

        var logic = new LanguagesSectionLogic((LanguagesSectionViewModel)DataContext);
        var ui = new LanguagesSectionUi(logic, (LanguagesSectionViewModel)DataContext, entityService);

        this.Background(Theme.Brushes.Background.Default).Child(ui.CreateContentGrid());
    }
}
