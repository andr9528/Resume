using System.Globalization;
using Microsoft.Extensions.Logging;
using Resume.Abstraction.Enums;
using Resume.Abstraction.Interfaces.Services;

namespace Resume.Services;

public class LocaleService : ILocaleService
{
    private readonly ILogger<LocaleService> logger;
    private LanguageType currentLanguage = LanguageType.ENGLISH;

    public LocaleService(ILogger<LocaleService> logger)
    {
        this.logger = logger;
    }

    /// <inheritdoc />
    public string GetLocalizedString(string key)
    {
        var translations = GetTranslationsForCurrentLanguage();

        if (translations.TryGetValue(key, out string? localizedString) && !string.IsNullOrWhiteSpace(localizedString))
        {
            return localizedString;
        }

        if (Translations.Fallback.All.TryGetValue(key, out string? fallbackString) &&
            !string.IsNullOrWhiteSpace(fallbackString))
        {
            logger.LogDebug("Falling back to fallback translation for key '{Key}' and language '{Language}'.", key,
                currentLanguage);

            return fallbackString;
        }

        logger.LogWarning("Failed to get localized string for key '{Key}' and language '{Language}'. Returning key.",
            key, currentLanguage);

        return key;
    }

    /// <inheritdoc />
    public Task SetLanguage(LanguageType type)
    {
        if (currentLanguage == type)
        {
            return Task.CompletedTask;
        }

        currentLanguage = type;

        CultureInfo culture = GetCultureFromLanguage(type);

        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;

        logger.LogInformation("Changed language to '{Language}' using culture '{Culture}'.", currentLanguage,
            culture.Name);

        return Task.CompletedTask;
    }

    /// <inheritdoc />
    public bool IsTargetedLanguage(LanguageType type)
    {
        return currentLanguage == type;
    }

    private Dictionary<string, string> GetTranslationsForCurrentLanguage()
    {
        return currentLanguage switch
        {
            LanguageType.DANISH => Translations.Danish.All,
            LanguageType.ENGLISH => Translations.English.All,
            var _ => Translations.Fallback.All,
        };
    }


    private CultureInfo GetCultureFromLanguage(LanguageType type)
    {
        return type switch
        {
            LanguageType.DANISH => new CultureInfo("da"),
            LanguageType.ENGLISH => new CultureInfo("en"),
            var _ => throw new ArgumentException($"Received invalid type for {nameof(LanguageType)}"),
        };
    }

    public CultureInfo GetCurrentCulture()
    {
        return GetCultureFromLanguage(currentLanguage);
    }
}
