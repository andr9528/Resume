using Resume.Localization.Abstractions;
using Resume.Presentation.Core;
using Resume.Services.Abstractions;

namespace Resume.Presentation;

public sealed partial class MainPage : BasePage
{
    public MainPage()
    {
        ILocaleService localeService = GetLocaleService();
        IEntityService entityService = GetEntityService();
        ILocalizationCategories categories = GetLocalizationCategories();
        var appInfo = GetAppInfo();

        DataContext = new MainPageViewModel();

        var logic = new MainPageLogic((MainPageViewModel) DataContext, localeService, appInfo, categories);
        var ui = new MainPageUi(logic, (MainPageViewModel) DataContext, localeService, categories, entityService);

        this.Background(Theme.Brushes.Background.Default).Content(ui.CreateContentGrid());
    }
}
