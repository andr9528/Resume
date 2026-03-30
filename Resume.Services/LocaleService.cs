using System.Globalization;
using System.Resources;
using Microsoft.Extensions.Logging;
using Resume.Abstraction.Enums;
using Resume.Abstraction.Interfaces.Services;

namespace Resume.Services;

public class LocaleService : ILocaleService
{
    private const string RESOURCE_MANAGER_PATH = "Resume.Localization.Strings.Resources";
    private readonly ILocalizationService localizationService;
    private readonly ILogger<LocaleService> logger;
    private readonly ResourceManager resourceManager;

    public LocaleService(ILocalizationService localizationService, ILogger<LocaleService> logger)
    {
        this.localizationService = localizationService;
        this.logger = logger;

        logger.LogInformation($"Getting new Resource Manager");
        resourceManager = new ResourceManager(RESOURCE_MANAGER_PATH, typeof(Localization.Strings.Resources).Assembly);
    }

    /// <inheritdoc />
    public string GetLocalizedString(string key)
    {
        CultureInfo currentCulture = GetCurrentCulture();

        string? localizedString = resourceManager.GetString(key, currentCulture);

        if (!string.IsNullOrWhiteSpace(localizedString))
        {
            return localizedString;
        }

        logger.LogInformation($"Failed to get a localized string for '{key}' in culture '{currentCulture.Name}'...");
        return key;
    }

    /// <inheritdoc />
    public async Task SetLanguage(LanguageType type)
    {
        CultureInfo currentCulture = GetCurrentCulture();

        string language = GetSupportedCulturesFromEnum(type);
        CultureInfo targetCulture = localizationService.SupportedCultures.First(culture => culture.Name == language);

        logger.LogInformation($"Attempting to change language from '{targetCulture.Name}' to '{targetCulture.Name}'.");

        if (Equals(currentCulture, targetCulture))
            return;

        logger.LogInformation($"Changing language to: {targetCulture.Name}");
        await localizationService.SetCurrentCultureAsync(targetCulture);
    }

    private string GetSupportedCulturesFromEnum(LanguageType type)
    {
        return type switch
        {
            LanguageType.DANISH => "da",
            LanguageType.ENGLISH => "en",
            var _ => throw new ArgumentException($"Received invalid type for {nameof(LanguageType)}"),
        };
    }

    public CultureInfo GetCurrentCulture()
    {
        return localizationService.CurrentCulture;
    }
}
