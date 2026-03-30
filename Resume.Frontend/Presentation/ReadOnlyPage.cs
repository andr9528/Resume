using Resume.Frontend.Presentation.Core;
using Resume.Localization.Abstractions;
using Resume.Services.Abstractions;

namespace Resume.Frontend.Presentation;

public partial class ReadOnlyPage : BasePage
{
    public ReadOnlyPage()
    {
        ILocaleService localeService = GetLocaleService();
        IEntityService entityService = GetEntityService();
        ILocalizationCategories categories = GetLocalizationCategories();

        DataContext = new ReadOnlyPageViewModel();

        var logic = new ReadOnlyPageLogic((ReadOnlyPageViewModel)DataContext);
        var ui = new ReadOnlyPageUi(logic, (ReadOnlyPageViewModel)DataContext, localeService, categories,
            entityService);

        this.Background(Theme.Brushes.Background.Default).Content(ui.CreateScrollView());
    }
}
