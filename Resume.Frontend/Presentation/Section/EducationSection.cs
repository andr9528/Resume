using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Presentation.Factory;

namespace Resume.Frontend.Presentation.Section;

public partial class EducationSection : Border
{
    public EducationSection(IEntityService entityService, ILocaleService localeService)
    {
        DataContext = new EducationSectionViewModel();

        this.ConfigureSectionBorder();

        var logic = new EducationSectionLogic((EducationSectionViewModel) DataContext);
        var ui = new EducationSectionUi(logic, (EducationSectionViewModel) DataContext, entityService, localeService);

        this.Background(Theme.Brushes.Background.Default).Child(ui.CreateContentGrid());
    }
}
