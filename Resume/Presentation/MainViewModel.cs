using System.Globalization;
using Resume.Localization.Keys.Abstraction;
using Resume.Localization.Services;

namespace Resume.Presentation;

public partial class MainViewModel : ObservableObject
{
    private readonly ILocaleService localeService;

    [ObservableProperty] private string? testBox = "Testing Bindings";

    private int count = 0;

    [ObservableProperty] private string counterText = "Press Me";

    public MainViewModel(IOptions<AppConfig> appInfo, ILocalizationKeys localizationKeys, ILocaleService localeService)
    {
        this.localeService = localeService;

        Title = "Main";
        Title += $" - {localeService.GetLocalizedString("ApplicationName")}";
        Title += $" - {appInfo?.Value?.Environment}";
        Title += $" - Current Language: {localeService.GetCurrentCulture().Name}";
        TestCommand = new AsyncRelayCommand(Test);
        Counter = new RelayCommand(OnCount);

        TestBox = $"{localeService.GetLocalizedString(localizationKeys.Links.FashionHeroGitHubProject)}";
    }

    public string? Title { get; }

    public ICommand TestCommand { get; }

    public ICommand Counter { get; }

    internal async Task Test()
    {
        await localeService.ToggleLanguage<MainViewModel>(this);
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
