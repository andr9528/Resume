using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Presentation.Factory;

namespace Resume.Frontend.Presentation.Section;

public partial class LanguagesSection : Border
{
    public LanguagesSection(IEntityService entityService, ILocaleService localeService)
    {
        DataContext = new LanguagesSectionViewModel();

        this.ConfigureSectionBorder();

        var logic = new LanguagesSectionLogic((LanguagesSectionViewModel)DataContext);
        var ui = new LanguagesSectionUi(logic, (LanguagesSectionViewModel)DataContext, entityService, localeService);

        this.Background(Theme.Brushes.Background.Default).Child(ui.CreateContentGrid());
    }
}
