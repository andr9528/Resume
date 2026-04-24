using Resume.Abstraction.Interfaces.Services;

namespace Resume.Frontend.Presentation.Section;

public partial class CoursesSection : Border
{
    public CoursesSection(IEntityService entityService, ILocaleService localeService)
    {
        DataContext = new CoursesSectionViewModel();

        var logic = new CoursesSectionLogic((CoursesSectionViewModel)DataContext);
        var ui = new CoursesSectionUi(logic, (CoursesSectionViewModel)DataContext, entityService, localeService);

        this.Background(Theme.Brushes.Background.Default).Child(ui.CreateContentGrid());
    }
}
