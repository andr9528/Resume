using System.Globalization;
using Resume.Localization.Keys.Abstraction;

namespace Resume.Presentation;

public partial class MainViewModel : ObservableObject
{
    private readonly INavigator navigator;
    private readonly ILocalizationService localizationService;

    [ObservableProperty] private string? testBox = "Testing Bindings";

    private int count = 0;

    [ObservableProperty] private string counterText = "Press Me";

    public MainViewModel(
        IStringLocalizer localizer, IOptions<AppConfig> appInfo, INavigator navigator,
        ILocalizationService localizationService, ILocalizationKeys localizationKeys)
    {
        this.navigator = navigator;
        this.localizationService = localizationService;

        Title = "Main";
        Title += $" - {localizer["ApplicationName"]}";
        Title += $" - {appInfo?.Value?.Environment}";
        TestCommand = new AsyncRelayCommand(Test);
        Counter = new RelayCommand(OnCount);

        TestBox = $"{localizer[localizationKeys.Links.FashionHeroGitHubProject]}";
    }

    public string? Title { get; }

    public ICommand TestCommand { get; }

    public ICommand Counter { get; }

    internal async Task Test()
    {
        CultureInfo currentCulture = localizationService.CurrentCulture;
        CultureInfo culture =
            localizationService.SupportedCultures.First(culture => culture.Name != currentCulture.Name);
        await localizationService.SetCurrentCultureAsync(culture);
        await navigator.NavigateViewModelAsync<MainViewModel>(this);
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
