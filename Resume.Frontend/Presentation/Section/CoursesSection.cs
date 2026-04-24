using Resume.Abstraction.Interfaces.Services;

namespace Resume.Frontend.Presentation.Section;

public partial class CoursesSection : Border
{
    public CoursesSection(IEntityService entityService)
    {
        DataContext = new CoursesSectionViewModel();

        var logic = new CoursesSectionLogic((CoursesSectionViewModel)DataContext);
        var ui = new CoursesSectionUi(logic, (CoursesSectionViewModel)DataContext, entityService);

        this.Background(Theme.Brushes.Background.Default).Child(ui.CreateContentGrid());
    }
}
