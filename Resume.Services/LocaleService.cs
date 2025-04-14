using System.Globalization;
using System.Resources;
using Microsoft.Extensions.Logging;
using Resume.Services.Abstractions;

namespace Resume.Services;

public class LocaleService : ILocaleService
{
    private readonly ILocalizationService localizationService;
    private readonly ILogger<LocaleService> logger;
    private readonly ResourceManager resourceManager;

    public LocaleService(ILocalizationService localizationService, ILogger<LocaleService> logger)
    {
        this.localizationService = localizationService;
        this.logger = logger;

        Console.WriteLine($"Getting new Resource Manager");
        resourceManager = new ResourceManager($"Resume.Localization.Strings.Resources",
            typeof(Localization.Strings.Resources).Assembly);
    }

    /// <inheritdoc />
    public string GetLocalizedString(string key)
    {
        CultureInfo currentCulture = GetCurrentCulture();

        return resourceManager.GetString(key, currentCulture) ?? key;
    }

    /// <inheritdoc />
    public async Task ToggleLanguage()
    {
        CultureInfo currentCulture = GetCurrentCulture();
        CultureInfo culture =
            localizationService.SupportedCultures.First(culture => culture.Name != currentCulture.Name);

        logger.LogInformation($"Changing language to: {culture.Name}");
        await localizationService.SetCurrentCultureAsync(culture);
    }

    public CultureInfo GetCurrentCulture()
    {
        return localizationService.CurrentCulture;
    }
}
