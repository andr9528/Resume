using Resume.Abstraction.Interfaces.Services;

namespace Resume.Frontend.Presentation.Section;

public partial class EducationSection : Border
{
    public EducationSection(IEntityService entityService)
    {
        DataContext = new EducationSectionViewModel();

        var logic = new EducationSectionLogic((EducationSectionViewModel)DataContext);
        var ui = new EducationSectionUi(logic, (EducationSectionViewModel)DataContext, entityService);

        this.Background(Theme.Brushes.Background.Default).Child(ui.CreateContentGrid());
    }
}
