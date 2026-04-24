using Resume.Abstraction.Interfaces.Services;

namespace Resume.Frontend.Presentation.Section;

public partial class EmploymentSection : Border
{
    public EmploymentSection(IEntityService entityService, ILocaleService localeService)
    {
        DataContext = new EmploymentSectionViewModel();

        var logic = new EmploymentSectionLogic((EmploymentSectionViewModel)DataContext);
        var ui = new EmploymentSectionUi(logic, (EmploymentSectionViewModel) DataContext, entityService, localeService);

        this.Background(Theme.Brushes.Background.Default).Child(ui.CreateContentGrid());
    }
}
