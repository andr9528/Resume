using System.Globalization;
using Resume.Abstraction.Interfaces.Services;

namespace Resume.Services;

public class AppLocalizationService : IAppLocalizationService
{
    private readonly IReadOnlyList<CultureInfo> supportedCultures;

    public AppLocalizationService()
    {
        supportedCultures = new List<CultureInfo>
        {
            new("en"),
            new("da"),
        };
    }

    public IReadOnlyList<CultureInfo> SupportedCultures => supportedCultures;

    public CultureInfo CurrentCulture { get; private set; } = CultureInfo.CurrentUICulture;

    public Task SetCurrentCultureAsync(CultureInfo culture)
    {
        if (supportedCultures.All(x => x.Name != culture.Name))
        {
            throw new ArgumentException($"Culture '{culture.Name}' is not supported.");
        }

        CurrentCulture = culture;

        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;

        return Task.CompletedTask;
    }
}
