using System.Globalization;
using Resume.Localization.Keys.Abstraction;

namespace Resume.Presentation;

public partial record MainModel
{
    private readonly INavigator _navigator;
    private readonly ILocalizationService localizationService;

    public MainModel(
        IStringLocalizer localizer, IOptions<AppConfig> appInfo, INavigator navigator,
        ILocalizationService localizationService, ILocalizationKeys localizationKeys)
    {
        _navigator = navigator;
        this.localizationService = localizationService;
        Title = "Main";
        Title += $" - {localizer["ApplicationName"]}";
        Title += $" - {appInfo?.Value?.Environment}";
        Title += $" - Current Language: {Windows.Globalization.ApplicationLanguages.PrimaryLanguageOverride}";

        TestBox = $"{localizer[localizationKeys.Links.FashionHeroGitHubProject]}";
    }

    public string? Title { get; }
    public string? TestBox { get; }

    public IState<string> Name => State<string>.Value(this, () => string.Empty);

    public IState<int> Count => State<int>.Value(this, () => 0);

    public IFeed<string> CounterText => Count.Select(_currentCount => _currentCount switch
    {
        0 => "Press Me",
        1 => "Pressed Once!",
        _ => $"Pressed {_currentCount} times!",
    });

    public async Task Counter(CancellationToken ct)
    {
        await Count.Update(x => ++x, ct);
    }

    public async Task Test()
    {
        CultureInfo currentCulture = localizationService.CurrentCulture;
        CultureInfo culture =
            localizationService.SupportedCultures.First(culture => culture.Name != currentCulture.Name);
        await localizationService.SetCurrentCultureAsync(culture);
        await _navigator.NavigateViewModelAsync<MainModel>(this);
    }
}
