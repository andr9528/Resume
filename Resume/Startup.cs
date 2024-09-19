using Resume.Localization.Keys;
using Resume.Localization.Keys.Abstraction;

namespace Resume;

public class Startup
{
    public void ConfigureApp(IApplicationBuilder builder)
    {
        // Add navigation support for toolkit controls such as TabBar and NavigationView
        builder.UseToolkitNavigation()
#if MAUI_EMBEDDING
            .UseMauiEmbedding<MauiControls.App>(maui => maui
                .UseMauiControls())
#endif
            .Configure(host => host
#if DEBUG
                // Switch to Development environment when running in DEBUG
                .UseEnvironment(Environments.Development)
#endif
                .UseLogging(ConfigureLogging, true).UseSerilog(true, true)
                .UseConfiguration(configure: ConfigureConfigurationSource).UseLocalization(ConfigureLocalization)
                .ConfigureServices(ConfigureAdditionalServices)
                .UseNavigation(ReactiveViewModelMappings.ViewModelMappings, RegisterRoutes));
    }

    private void ConfigureLocalization(HostBuilderContext context, IServiceCollection services)
    {
        // Enables localization (see appsettings.json for supported languages)
    }

    private IHostBuilder ConfigureConfigurationSource(IConfigBuilder configBuilder)
    {
        return configBuilder.EmbeddedSource<App>().Section<AppConfig>();
    }

    private void ConfigureAdditionalServices(HostBuilderContext context, IServiceCollection services)
    {
        // TODO: Register your services
        services.AddSingleton<ILocalizationKeys, LocalizationKeys>();
        services.AddSingleton<ILinks, Links>();
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

    private void RegisterRoutes(IViewRegistry views, IRouteRegistry routes)
    {
        views.Register(new ViewMap(ViewModel: typeof(ShellModel)), new ViewMap<MainPage, MainModel>());

        routes.Register(new RouteMap("", views.FindByViewModel<ShellModel>(), Nested: new RouteMap[]
        {
            new("Main", views.FindByViewModel<MainModel>(), true),
        }));
    }
}
