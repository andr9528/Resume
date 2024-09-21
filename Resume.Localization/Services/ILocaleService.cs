using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Resume.Localization.Services;

public interface ILocaleService
{
    string GetLocalizedString(string key);
    CultureInfo GetCurrentCulture();
    Task ToggleLanguage<TModel>(object caller) where TModel : ObservableObject;
}
