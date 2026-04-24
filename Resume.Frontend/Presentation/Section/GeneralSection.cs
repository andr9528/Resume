using Resume.Abstraction.Interfaces.Services;

namespace Resume.Frontend.Presentation.Section;

public partial class GeneralSection : Border
{
    public GeneralSection(IEntityService entityService)
    {
        DataContext = new GeneralSectionViewModel();

        var logic = new GeneralSectionLogic((GeneralSectionViewModel)DataContext);
        var ui = new GeneralSectionUi(logic, (GeneralSectionViewModel)DataContext, entityService);

        this.Background(Theme.Brushes.Background.Default).Child(ui.CreateContentGrid());
    }
}
