using Resume.Entities.Abstractions;
using Resume.Services;
using Resume.Services.Abstractions;

namespace Resume.Presentation;

public partial class HeaderViewModel : ObservableObject
{
    private readonly IProfile profile;

    public HeaderViewModel(
        IOptions<AppConfig> appInfo, ILocaleService localeService, INavigator navigator, IEntityService entityService)
    {
        profile = entityService.GetProfile();

        Title = profile.Description;
        Title += $" - {localeService.GetLocalizedString("ApplicationName")}";
        Title += $" - {appInfo?.Value?.Environment}";
        Title += $" - Current Language: {localeService.GetCurrentCulture().Name}";
    }

    [ObservableProperty] public string? title;
}
