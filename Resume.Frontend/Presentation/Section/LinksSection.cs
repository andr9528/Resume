using Resume.Abstraction.Interfaces.Services;

namespace Resume.Frontend.Presentation.Section;

public partial class LinksSection : Border
{
    public LinksSection(IEntityService entityService)
    {
        DataContext = new LinksSectionViewModel();

        var logic = new LinksSectionLogic((LinksSectionViewModel)DataContext);
        var ui = new LinksSectionUi(logic, (LinksSectionViewModel)DataContext, entityService);

        this.Background(Theme.Brushes.Background.Default).Child(ui.CreateContentGrid());
    }
}
