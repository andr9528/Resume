using Resume.Localization.Abstractions;
using Resume.Localization.Keys;
using Resume.Services;
using Resume.Services.Abstractions;

namespace Resume;

public class Startup
{
    public IServiceProvider ServiceProvider { get; private set; }

    private void ConfigureServices(IServiceCollection services)
    {
        // Localization Hierarchy
        services.AddSingleton<ILocalizationCategories, LocalizationCategories>();
        services.AddSingleton<ILinkKeys, LinkKeys>();
        services.AddSingleton<IProfileKeys, ProfileKeys>();
        services.AddSingleton<IUserInterfaceKeys, UserInterfaceKeys>();

        // Business Logic Services
        services.AddSingleton<ILocaleService, LocaleService>();
        services.AddSingleton<IEntityService, EntityService>();


        ServiceProvider = services.BuildServiceProvider();
    }

    public void ConfigureApp(IApplicationBuilder app)
    {
#if DEBUG
        app.Configure(host => host.UseEnvironment(Environments.Development));
#endif

        app.Configure(host => host.UseLogging(ConfigureLogging, true)).Configure(host => host.UseSerilog(true, true))
            .Configure(host => host.UseConfiguration(configure: ConfigureConfigurationSource))
            .Configure(host => host.UseLocalization(ConfigureLocalization))
            .Configure(host => host.ConfigureServices(ConfigureServices));
    }

    private void ConfigureLocalization(HostBuilderContext context, IServiceCollection services)
    {
        // Enables localization (see appsettings.json for supported languages)
    }

    private IHostBuilder ConfigureConfigurationSource(IConfigBuilder configBuilder)
    {
        return configBuilder.EmbeddedSource<App>().Section<AppConfig>();
    }

    private void ConfigureLogging(HostBuilderContext context, ILoggingBuilder logBuilder)
    {
        // Configure log levels for different categories of logging
        logBuilder.SetMinimumLevel(context.HostingEnvironment.IsDevelopment() ? LogLevel.Information : LogLevel.Warning)

            // Default filters for core Uno Platform namespaces
            .CoreLogLevel(LogLevel.Warning);

        // Uno Platform namespace filter groups
        // Uncomment individual methods to see more detailed logging
        //// Generic Xaml events
        //logBuilder.XamlLogLevel(LogLevel.Debug);
        //// Layout specific messages
        //logBuilder.XamlLayoutLogLevel(LogLevel.Debug);
        //// Storage messages
        //logBuilder.StorageLogLevel(LogLevel.Debug);
        //// Binding related messages
        //logBuilder.XamlBindingLogLevel(LogLevel.Debug);
        //// Binder memory references tracking
        //logBuilder.BinderMemoryReferenceLogLevel(LogLevel.Debug);
        //// DevServer and HotReload related
        //logBuilder.HotReloadCoreLogLevel(LogLevel.Information);
        //// Debug JS interop
        //logBuilder.WebAssemblyLogLevel(LogLevel.Debug);
    }
}
