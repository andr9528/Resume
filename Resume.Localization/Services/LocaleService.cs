using System.Globalization;
using System.Resources;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;

namespace Resume.Localization.Services;

public class LocaleService : ILocaleService
{
    private readonly INavigator navigator;
    private readonly ILocalizationService localizationService;
    private readonly ILogger<LocaleService> logger;
    private readonly ResourceManager resourceManager;

    public LocaleService(INavigator navigator, ILocalizationService localizationService, ILogger<LocaleService> logger)
    {
        this.navigator = navigator;
        this.localizationService = localizationService;
        this.logger = logger;

        resourceManager = new ResourceManager($"Resume.Localization.Strings.Resources", GetType().Assembly);
    }

    /// <inheritdoc />
    public string GetLocalizedString(string key)
    {
        CultureInfo currentCulture = GetCurrentCulture();

        return resourceManager.GetString(key, currentCulture) ?? key;
    }

    /// <inheritdoc />
    public async Task ToggleLanguage<TModel>(object caller) where TModel : ObservableObject
    {
        CultureInfo currentCulture = GetCurrentCulture();
        CultureInfo culture =
            localizationService.SupportedCultures.First(culture => culture.Name != currentCulture.Name);

        logger.LogInformation($"Changing language to: {culture.Name}");
        await localizationService.SetCurrentCultureAsync(culture);
        await navigator.NavigateViewModelAsync<TModel>(caller, Qualifiers.ClearBackStack);
    }

    public CultureInfo GetCurrentCulture()
    {
        return localizationService.CurrentCulture;
    }
}
