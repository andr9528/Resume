using System.Globalization;
using Resume.Abstraction.Enums;

namespace Resume.Abstraction.Interfaces.Services;

public interface ILocaleService
{
    string GetLocalizedString(string key);
    CultureInfo GetCurrentCulture();
    Task SetLanguage(LanguageType type);
    bool IsTargetedLanguage(LanguageType type);
    public LanguageType GetCurrentLanguageType();
}
