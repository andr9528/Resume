using Resume.Localization.Abstractions;
using Resume.Presentation.Core;
using Resume.Services.Abstractions;

namespace Resume.Presentation;

public partial class ReadOnlyPage : BasePage
{
    public ReadOnlyPage()
    {
        ILocaleService localeService = GetLocaleService();
        IEntityService entityService = GetEntityService();
        ILocalizationCategories categories = GetLocalizationCategories();

        DataContext = new ReadOnlyPageViewModel();

        var logic = new ReadOnlyPageLogic((ReadOnlyPageViewModel) DataContext);
        var ui = new ReadOnlyPageUi(logic, (ReadOnlyPageViewModel) DataContext, localeService, categories,
            entityService);

        this.Background(Theme.Brushes.Background.Default).Content(ui.CreateScrollView());
    }
}
