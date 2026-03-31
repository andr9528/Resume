using System.Globalization;

namespace Resume.Abstraction.Interfaces.Services;

public interface IAppLocalizationService
{
    IReadOnlyList<CultureInfo> SupportedCultures { get; }
    CultureInfo CurrentCulture { get; }
    Task SetCurrentCultureAsync(CultureInfo culture);
}
