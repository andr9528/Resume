using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Presentation.Factory;

namespace Resume.Frontend.Presentation.Section;

public partial class ProjectsSection : Border
{
    public ProjectsSection(IEntityService entityService, ILocaleService localeService)
    {
        DataContext = new ProjectsSectionViewModel();

        this.ConfigureSectionBorder();

        var logic = new ProjectsSectionLogic((ProjectsSectionViewModel)DataContext);
        var ui = new ProjectsSectionUi(logic, (ProjectsSectionViewModel)DataContext, entityService, localeService);

        this.Background(Theme.Brushes.Background.Default).Child(ui.CreateContentGrid());
    }
}
