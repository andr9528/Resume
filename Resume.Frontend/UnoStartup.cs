using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Abstraction;
using Resume.Frontend.NavigationRegion;
using Resume.Models.Frontend;
using Resume.Services;
using Resume.Startup;
using Resume.Startup.Modules;

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

        app.Configure(host => host.UseConfiguration(configure: ConfigureConfigurationSource));
    }

    private IHostBuilder ConfigureConfigurationSource(IConfigBuilder configBuilder)
    {
        return configBuilder.EmbeddedSource<App>().Section<AppConfig>();
    }
}
