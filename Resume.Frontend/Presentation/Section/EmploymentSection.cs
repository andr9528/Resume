using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Presentation.Factory;

namespace Resume.Frontend.Presentation.Section;

public partial class EmploymentSection : Border
{
    public EmploymentSection(IEntityService entityService, ILocaleService localeService)
    {
        DataContext = new EmploymentSectionViewModel();

        this.ConfigureSectionBorder();

        var logic = new EmploymentSectionLogic((EmploymentSectionViewModel) DataContext);
        var ui = new EmploymentSectionUi(logic, (EmploymentSectionViewModel) DataContext, entityService, localeService);

        this.Background(Theme.Brushes.Background.Default).Child(ui.CreateContentGrid());
    }
}
