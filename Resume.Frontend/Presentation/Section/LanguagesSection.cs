using Resume.Abstraction.Interfaces.Services;

namespace Resume.Frontend.Presentation.Section;

public partial class LanguagesSection : Border
{
    public LanguagesSection(IEntityService entityService, ILocaleService localeService)
    {
        DataContext = new LanguagesSectionViewModel();

        var logic = new LanguagesSectionLogic((LanguagesSectionViewModel)DataContext);
        var ui = new LanguagesSectionUi(logic, (LanguagesSectionViewModel)DataContext, entityService, localeService);

        this.Background(Theme.Brushes.Background.Default).Child(ui.CreateContentGrid());
    }
}
