using Resume.Styles;
using Uno.Resizetizer;

namespace Resume;

public partial class App : Application
{
    /// <summary>
    /// Initializes the singleton application object. This is the first line of authored code
    /// executed, and as such is the logical equivalent of main() or WinMain().
    /// </summary>
    public App()
    {
        InitializeComponent();
        RequestedTheme = ApplicationTheme.Light;
    }

    protected Window? MainWindow { get; private set; }
    protected IHost? Host { get; private set; }
    public Startup Startup { get; private set; }

    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        Startup = new Startup();

        // Load WinUI Resources
        Resources.Build(r => r.Merged(new XamlControlsResources()));

        // Load Uno.UI.Toolkit and Material Resources
        Resources.Build(
            r => r.Merged(new MaterialToolkitTheme(new ColorPaletteOverride(), new MaterialFontsOverride())));
        IApplicationBuilder builder = this.CreateBuilder(args);

        Startup.ConfigureApp(builder);

        MainWindow = builder.Window;

#if DEBUG
        MainWindow.EnableHotReload();
#endif
        MainWindow.SetWindowIcon();

        Host = builder.Build();
        // Do not repeat app initialization when the Window already has content,
        // just ensure that the window is active
        if (MainWindow.Content is not Frame rootFrame)
        {
            // Create a Frame to act as the navigation context and navigate to the first page
            rootFrame = new Frame();

            // Place the frame in the current Window
            MainWindow.Content = rootFrame;
        }

        if (rootFrame.Content == null)
        {
            // When the navigation stack isn't restored navigate to the first page,
            // configuring the new page by passing required information as a navigation
            // parameter
            rootFrame.Navigate(typeof(MainPage));
        }

        // Ensure the current window is active
        MainWindow.Activate();
    }
}
