using Resume.Abstraction.Interfaces.Keys;
using Resume.Services.Abstractions;

namespace Resume.Frontend.Presentation.Section;

public partial class EmploymentSection : StackPanel
{
    public EmploymentSection(
        IEntityService entityService, ILocaleService localeService, ILocalizationCategories categories)
    {
        DataContext = new EmploymentSectionViewModel();

        var logic = new EmploymentSectionLogic((EmploymentSectionViewModel)DataContext);
        var ui = new EmploymentSectionUi(logic, (EmploymentSectionViewModel)DataContext, localeService, categories,
            entityService);

        this.Background(Theme.Brushes.Background.Default).Children.Add(ui.CreateContentGrid());
    }
}
