using Resume.Abstraction.Interfaces.Keys;
using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Abstraction;
using Resume.Frontend.NavigationRegion;
using Resume.Localization.Keys;
using Resume.Models.Frontend;
using Resume.Services;
using Resume.Startup;
using Resume.Startup.Modules;
using Path = System.IO.Path;

namespace Resume.Frontend;

public class UnoStartup : ModularStartup<IApplicationBuilder>
{
    public UnoStartup()
    {
        AddModule(new LoggingStartupModule(new[]
        {
            LogTarget.BROWSER_CONSOLE,
        }));
    }

    protected override void ConfigureServices(IServiceCollection services)
    {
        base.ConfigureServices(services);

        // Localization Hierarchy
        services.AddSingleton<ILocalizationCategories, LocalizationCategories>();
        services.AddSingleton<ILinkKeys, LinkKeys>();
        services.AddSingleton<IProfileKeys, ProfileKeys>();
        services.AddSingleton<IUserInterfaceKeys, UserInterfaceKeys>();
        services.AddSingleton<IEmploymentKeys, EmploymentKeys>();
        services.AddSingleton<IEducationKeys, EducationKeys>();
        services.AddSingleton<IGeneralInformationKeys, GeneralInformationKeys>();
        services.AddSingleton<ILanguageKeys, LanguageKeys>();
        services.AddSingleton<IReferencesKeys, ReferencesKeys>();
        services.AddSingleton<IProjectKeys, ProjectKeys>();

        // Business Logic Services
        services.AddSingleton<ILocaleService, LocaleService>();
        services.AddSingleton<IEntityService, EntityService>();

        // Language Regions
        services.AddSingleton<IPageRegion, DanishPageRegionDefinition>();
        services.AddSingleton<IPageRegion, EnglishPageRegionDefinition>();
    }

    /// <inheritdoc />
    protected override void ConfigureApplication(IApplicationBuilder app)
    {
        base.ConfigureApplication(app);

#if DEBUG
        app.Configure(host => host.UseEnvironment(Environments.Development));
#endif

        app.Configure(host => host.UseConfiguration(configure: ConfigureConfigurationSource))
            .Configure(host => host.UseLocalization(ConfigureLocalization));

    }

    private void ConfigureLocalization(HostBuilderContext context, IServiceCollection services)
    {
        // Enables localization (see appsettings.json for supported languages)
    }

    private IHostBuilder ConfigureConfigurationSource(IConfigBuilder configBuilder)
    {
        return configBuilder.EmbeddedSource<App>().Section<AppConfig>();
    }
}
