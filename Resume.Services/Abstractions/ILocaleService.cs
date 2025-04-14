using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Resume.Services.Abstractions;

public interface ILocaleService
{
    string GetLocalizedString(string key);
    CultureInfo GetCurrentCulture();
    Task ToggleLanguage();
}
