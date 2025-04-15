using Resume.Localization.Abstractions;
using Resume.Localization.Keys;
using Resume.Services;
using Resume.Services.Abstractions;

namespace Resume;

public class Startup
{
    public IServiceProvider ServiceProvider { get; private set; }

    public void ConfigureServices(IServiceCollection services)
    {
        try
        {
            Console.WriteLine($"Configuring Services...");

            // Localization Hierarchy
            services.AddSingleton<ILocalizationCategories, LocalizationCategories>();
            services.AddSingleton<ILinkKeys, LinkKeys>();
            services.AddSingleton<IProfileKeys, ProfileKeys>();

            // Business Logic Services
            services.AddSingleton<ILocaleService, LocaleService>();
            services.AddSingleton<IEntityService, EntityService>();


            var exception =
                new NullReferenceException($"Failed to build Service Provider inside '{nameof(Startup)}' class.");
            ServiceProvider = services.BuildServiceProvider() ?? throw exception;

            if (ServiceProvider == null)
            {
                throw new NullReferenceException($"Service Provider became null immediately after assignment",
                    exception);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public IApplicationBuilder ConfigureApp(IApplicationBuilder app)
    {
        Console.WriteLine($"Configuring Application...");

        // Add navigation support for toolkit controls such as TabBar and NavigationView
        return app.Configure(host => host
#if DEBUG
            // Switch to Development environment when running in DEBUG
            .UseEnvironment(Environments.Development)
#endif
            .UseLogging(ConfigureLogging, true).UseSerilog(true, true)
            .UseConfiguration(configure: ConfigureConfigurationSource).UseLocalization(ConfigureLocalization));
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
