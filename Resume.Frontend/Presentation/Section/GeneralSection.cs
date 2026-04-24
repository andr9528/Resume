using Resume.Abstraction.Interfaces.Services;

namespace Resume.Frontend.Presentation.Section;

public partial class GeneralSection : Border
{
    public GeneralSection(IEntityService entityService, ILocaleService localeService)
    {
        DataContext = new GeneralSectionViewModel();

        var logic = new GeneralSectionLogic((GeneralSectionViewModel)DataContext);
        var ui = new GeneralSectionUi(logic, (GeneralSectionViewModel)DataContext, entityService, localeService);

        this.Background(Theme.Brushes.Background.Default).Child(ui.CreateContentGrid());
    }
}
