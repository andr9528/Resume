using Resume.Abstraction.Interfaces.Services;

namespace Resume.Frontend.Presentation.Section;

public partial class ProjectsSection : Border
{
    public ProjectsSection(IEntityService entityService)
    {
        DataContext = new ProjectsSectionViewModel();

        var logic = new ProjectsSectionLogic((ProjectsSectionViewModel)DataContext);
        var ui = new ProjectsSectionUi(logic, (ProjectsSectionViewModel)DataContext, entityService);

        this.Background(Theme.Brushes.Background.Default).Child(ui.CreateContentGrid());
    }
}
