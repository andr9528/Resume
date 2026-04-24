using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Presentation.Factory;

namespace Resume.Frontend.Presentation.Section;

public partial class LinksSection : Border
{
    public LinksSection(IEntityService entityService, ILocaleService localeService)
    {
        DataContext = new LinksSectionViewModel();

        this.ConfigureSectionBorder();

        var logic = new LinksSectionLogic((LinksSectionViewModel)DataContext);
        var ui = new LinksSectionUi(logic, (LinksSectionViewModel)DataContext, entityService, localeService);

        this.Background(Theme.Brushes.Background.Default).Child(ui.CreateContentGrid());
    }
}
