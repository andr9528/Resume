using System.Globalization;
using Resume.Localization.Abstractions;
using Resume.Localization;
using Resume.Services.Abstractions;

namespace Resume.Presentation;

public partial class MainViewModel : ObservableObject
{
    private readonly ILocaleService localeService;
    private readonly INavigator navigator;
    private readonly IEntityService entityService;

    [ObservableProperty] private string? testBox = "Testing Bindings";

    public MainViewModel(
        IOptions<AppConfig> appInfo, ILocaleService localeService, INavigator navigator, IEntityService entityService)
    {
        this.localeService = localeService;
        this.navigator = navigator;
        this.entityService = entityService;

        TestCommand = new AsyncRelayCommand(Test);

        TestBox = entityService.GetProfile().Description;
    }

    public ICommand TestCommand { get; }

    private async Task Test()
    {
        await localeService.ToggleLanguage<MainViewModel>(this, navigator);
    }
}
