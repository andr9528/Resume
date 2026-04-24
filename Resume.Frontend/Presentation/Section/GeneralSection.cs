using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Presentation.Factory;

namespace Resume.Frontend.Presentation.Section;

public partial class GeneralSection : Border
{
    public GeneralSection(IEntityService entityService, ILocaleService localeService)
    {
        DataContext = new GeneralSectionViewModel();

        this.ConfigureSectionBorder();

        var logic = new GeneralSectionLogic((GeneralSectionViewModel)DataContext);
        var ui = new GeneralSectionUi(logic, (GeneralSectionViewModel)DataContext, entityService, localeService);

        this.Background(Theme.Brushes.Background.Default).Child(ui.CreateContentGrid());
    }
}
