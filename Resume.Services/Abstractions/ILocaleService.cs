using System.Globalization;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Resume.Services.Abstractions;

public interface ILocaleService
{
    string GetLocalizedString(string key);
    CultureInfo GetCurrentCulture();

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <param name="caller"></param>
    /// <param name="navigator">
    ///     This is taken as an argument, instead of the service depending on it in the constructor.
    ///     Depending on and using the version from the constructor was causing an ArgumentNullException.
    /// </param>
    /// <returns></returns>
    Task ToggleLanguage<TModel>(object caller, INavigator navigator) where TModel : ObservableObject;
}
