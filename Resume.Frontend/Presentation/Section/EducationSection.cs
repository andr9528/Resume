using Resume.Abstraction.Interfaces.Services;

namespace Resume.Frontend.Presentation.Section;

public partial class EducationSection : Border
{
    public EducationSection(IEntityService entityService, ILocaleService localeService)
    {
        DataContext = new EducationSectionViewModel();

        var logic = new EducationSectionLogic((EducationSectionViewModel)DataContext);
        var ui = new EducationSectionUi(logic, (EducationSectionViewModel)DataContext, entityService, localeService);

        this.Background(Theme.Brushes.Background.Default).Child(ui.CreateContentGrid());
    }
}
