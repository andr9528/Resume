using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Presentation.Factory;

namespace Resume.Frontend.Presentation.Section;

public partial class ProfileSection : Border
{
    public ProfileSection(IEntityService entityService, ILocaleService localeService)
    {
        DataContext = new ProfileSectionViewModel();

        this.ConfigureSectionBorder();

        var logic = new ProfileSectionLogic((ProfileSectionViewModel) DataContext);
        var ui = new ProfileSectionUi(logic, (ProfileSectionViewModel) DataContext, entityService, localeService);

        this.Background(Theme.Brushes.Background.Default).Child(ui.CreateContentGrid());
    }
}
