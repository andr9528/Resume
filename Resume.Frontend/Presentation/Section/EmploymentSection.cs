using Resume.Abstraction.Interfaces.Services;

namespace Resume.Frontend.Presentation.Section;

public partial class EmploymentSection : Border
{
    public EmploymentSection(IEntityService entityService)
    {
        DataContext = new EmploymentSectionViewModel();

        var logic = new EmploymentSectionLogic((EmploymentSectionViewModel)DataContext);
        var ui = new EmploymentSectionUi(logic, (EmploymentSectionViewModel) DataContext, entityService);

        this.Background(Theme.Brushes.Background.Default).Child(ui.CreateContentGrid());
    }
}
