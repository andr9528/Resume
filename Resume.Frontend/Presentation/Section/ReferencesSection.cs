using Resume.Abstraction.Interfaces.Services;

namespace Resume.Frontend.Presentation.Section;

public partial class ReferencesSection : Border
{
    public ReferencesSection(IEntityService entityService, ILocaleService localeService)
    {
        DataContext = new ReferencesSectionViewModel();

        var logic = new ReferencesSectionLogic((ReferencesSectionViewModel)DataContext);
        var ui = new ReferencesSectionUi(logic, (ReferencesSectionViewModel)DataContext, entityService, localeService);

        this.Background(Theme.Brushes.Background.Default).Child(ui.CreateContentGrid());
    }
}
