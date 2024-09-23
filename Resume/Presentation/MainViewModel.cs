using System.Globalization;
using Resume.Localization.Abstractions;
using Resume.Localization;
using Resume.Services.Abstractions;

namespace Resume.Presentation;

public partial class MainViewModel : ObservableObject
{
    private readonly ILocaleService localeService;
    private readonly INavigator navigator;

    [ObservableProperty] private string? testBox = "Testing Bindings";

    private int count = 0;

    [ObservableProperty] private string counterText = "Press Me";

    public MainViewModel(
        IOptions<AppConfig> appInfo, ILocalizationCategories localizationCategories, ILocaleService localeService,
        INavigator navigator)
    {
        this.localeService = localeService;
        this.navigator = navigator;

        Title = "Main";
        Title += $" - {localeService.GetLocalizedString("ApplicationName")}";
        Title += $" - {appInfo?.Value?.Environment}";
        Title += $" - Current Language: {localeService.GetCurrentCulture().Name}";
        TestCommand = new AsyncRelayCommand(Test);
        Counter = new RelayCommand(OnCount);

        TestBox = $"{localeService.GetLocalizedString(localizationCategories.Links.FashionHeroGitHubProject)}";
    }

    public string? Title { get; }

    public ICommand TestCommand { get; }

    public ICommand Counter { get; }

    private async Task Test()
    {
        await localeService.ToggleLanguage<MainViewModel>(this, navigator);
    }

    private void OnCount()
    {
        CounterText = ++count switch
        {
            1 => "Pressed Once!",
            _ => $"Pressed {count} times!",
        };
    }
}
