using System.Text.Json;
using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Abstraction;
using Resume.Frontend.Extensions;
using Resume.Frontend.Presentation.Factory;
using Resume.Services;
using Uno.Foundation;

namespace Resume.Frontend.Presentation;

/// <summary>
/// Page navigation menu that hosts "regions" (pages) and swaps Content based on selection.
/// </summary>
public sealed partial class PageSelector : Page
{
    private const double PANE_COLUMN_WEIGHT = 10d;
    private readonly IServiceProvider serviceProvider;
    private readonly IDownloadService downloadService;
    private readonly ILogger<PageSelector> logger;

    private ListView menuList = null!;
    private Frame contentFrame = null!;
    private Frame paneFrame = null!;

    public PageSelector(IServiceProvider sp, IEnumerable<IPageRegion> regionDefinitions, IDownloadService downloadService, ILogger<PageSelector> logger)
    {
        serviceProvider = sp ?? throw new ArgumentNullException(nameof(sp));
        this.downloadService = downloadService;
        this.logger = logger;

        Margin = new Thickness(0);

        var regions = CreateMenuList(regionDefinitions ?? throw new ArgumentNullException(nameof(regionDefinitions)));

        Content = CreatePageContentGrid();

        if (regions.Any())
        {
            menuList.SelectedIndex = 0;
        }
    }

    private void CreateFrames()
    {
        contentFrame = new Frame();
        paneFrame = new Frame
        {
            Content = CreatePaneContentGrid(),
        };
    }

    private Grid CreatePageContentGrid()
    {
        CreateFrames();

        Grid pageRoot = GridFactory.CreateDefaultGrid();

        pageRoot.HorizontalAlignment = HorizontalAlignment.Stretch;
        pageRoot.VerticalAlignment = VerticalAlignment.Stretch;
        pageRoot.Margin = new Thickness(0);
        pageRoot.Padding = new Thickness(0);

        const double contentColumnWeight = 100 - PANE_COLUMN_WEIGHT;

        pageRoot.ColumnDefinitions.Add(new ColumnDefinition
            {Width = new GridLength(PANE_COLUMN_WEIGHT, GridUnitType.Star),});
        pageRoot.ColumnDefinitions.Add(new ColumnDefinition
            {Width = new GridLength(contentColumnWeight, GridUnitType.Star),});

        pageRoot.Children.Add(paneFrame.SetColumn(0));
        pageRoot.Children.Add(contentFrame.SetColumn(1));

        return pageRoot;
    }

    private Grid CreatePaneContentGrid()
    {
        Grid paneRoot = GridFactory.CreateDefaultGrid();

        paneRoot.Background = new SolidColorBrush(Color.FromArgb(255, 32, 32, 32));
        paneRoot.HorizontalAlignment = HorizontalAlignment.Stretch;
        paneRoot.VerticalAlignment = VerticalAlignment.Stretch;
        paneRoot.Margin = new Thickness(0);
        paneRoot.Padding = new Thickness(0);

        paneRoot.RowDefinitions.Add(new RowDefinition {Height = GridLength.Auto});
        paneRoot.RowDefinitions.Add(new RowDefinition {Height = new GridLength(1, GridUnitType.Star)});
        paneRoot.RowDefinitions.Add(new RowDefinition {Height = GridLength.Auto});

        paneRoot.Children.Add(menuList.SetRow(0));

        Button downloadButton = BuildDownloadButton();
        paneRoot.Children.Add(downloadButton.SetRow(2));

        return paneRoot;
    }

    private Button BuildDownloadButton()
    {
        var downloadButton = new Button
        {
            Content = "Download",
            HorizontalAlignment = HorizontalAlignment.Stretch,
            Margin = new Thickness(5),
            Background = new SolidColorBrush(Colors.DarkBlue)
        };

        downloadButton.Click += (_, _) =>
        {
            DispatcherQueue.TryEnqueue(async () => { await downloadService.DownloadResumePdf(DownloadAction); });
        };
        return downloadButton;
    }

    private Task DownloadAction(string url, string fileName)
    {
#if __WASM__
        var packageBase = GetPackageBase();
        var fullUrl = BuildFullUrl(packageBase, url);

        logger.LogInformation("Download Url: {Url}", url);
        logger.LogInformation("Download FileName: {FileName}", fileName);
        logger.LogInformation("Download PackageBase: {PackageBase}", packageBase);
        logger.LogInformation("Download FullUrl: {FullUrl}", fullUrl);

        var safeFullUrl = JsonSerializer.Serialize(fullUrl);
        var safeName = JsonSerializer.Serialize(fileName);

        WebAssemblyRuntime.InvokeJS($$"""
                                      const link = document.createElement('a');
                                      link.href = {{safeFullUrl}};
                                      link.download = {{safeName}};
                                      document.body.appendChild(link);
                                      link.click();
                                      document.body.removeChild(link);
                                      """);
#endif
        return Task.CompletedTask;
    }

    private string BuildFullUrl(string packageBase, string relativeUrl)
    {
        if (string.IsNullOrWhiteSpace(packageBase))
        {
            logger.LogWarning("Package base was empty. Falling back to relative URL: {RelativeUrl}", relativeUrl);
            return relativeUrl;
        }

        var fullUrl = new Uri(new Uri(packageBase), relativeUrl).ToString();

        return fullUrl;
    }

    private string GetPackageBase()
    {
        var packageBase = "";

#if __WASM__
        packageBase = WebAssemblyRuntime.InvokeJS("""
                                                  (() => {
                                                      const packageResource = performance
                                                          .getEntriesByType("resource")
                                                          .map(x => new URL(x.name))
                                                          .find(x => x.pathname.includes("/package_"));

                                                      if (!packageResource) {
                                                          return "";
                                                      }

                                                      const packageSegmentIndex = packageResource.pathname
                                                          .split("/")
                                                          .findIndex(x => x.startsWith("package_"));

                                                      const packagePath = packageResource.pathname
                                                          .split("/")
                                                          .slice(0, packageSegmentIndex + 1)
                                                          .join("/") + "/";

                                                      return packageResource.origin + packagePath;
                                                  })()
                                                  """);
#endif

        return packageBase;
    }

    private List<IPageRegion> CreateMenuList(IEnumerable<IPageRegion> regionDefinitions)
    {
        var regions = regionDefinitions.ToList();

        menuList = new ListView
        {
            Background = new SolidColorBrush(Colors.Transparent),
            SelectionMode = ListViewSelectionMode.Single,
            ItemsSource = regions,
            ItemTemplate = CreateMenuItemTemplate(),
            ItemContainerStyle = CreateMenuItemStyle(),
            HorizontalAlignment = HorizontalAlignment.Stretch,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(5),
        };

        menuList.SelectionChanged += MenuList_SelectionChanged;
        return regions;
    }

    private void MenuList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (menuList.SelectedItem is IPageRegion region)
        {
            DispatcherQueue.TryEnqueue(() => contentFrame.Content = region.CreateControl(serviceProvider).Result);
        }
    }

    private DataTemplate CreateMenuItemTemplate()
    {
        return new DataTemplate(() =>
        {
            Grid templateGrid = GridFactory.CreateDefaultGrid();
            templateGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
            templateGrid.Margin = new Thickness(0);

            templateGrid.ColumnDefinitions.Add(new ColumnDefinition {Width = new GridLength(30),});
            templateGrid.ColumnDefinitions.Add(new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star),});

            var iconPresenter = new ContentPresenter
            {
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
            };
            iconPresenter.SetBinding(ContentPresenter.ContentProperty,
                new Binding {Path = new PropertyPath(nameof(IPageRegion.Icon)),});

            var text = new TextBlock
            {
                Foreground = new SolidColorBrush(Colors.White),
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Margin = new Thickness(5, 0, 0, 0),
                TextWrapping = TextWrapping.NoWrap,
                TextTrimming = TextTrimming.CharacterEllipsis,
            };
            text.SetBinding(TextBlock.TextProperty,
                new Binding {Path = new PropertyPath(nameof(IPageRegion.DisplayName)),});

            templateGrid.Children.Add(iconPresenter.SetColumn(0));
            templateGrid.Children.Add(text.SetColumn(1));

            return templateGrid;
        });
    }

    private Style CreateMenuItemStyle()
    {
        var style = new Style(typeof(ListViewItem));
        style.Setters.Add(new Setter(BackgroundProperty, new SolidColorBrush(Colors.Transparent)));
        style.Setters.Add(new Setter(BorderThicknessProperty, new Thickness(0)));
        style.Setters.Add(new Setter(PaddingProperty, new Thickness(4, 2, 4, 2)));
        style.Setters.Add(new Setter(ForegroundProperty, new SolidColorBrush(Colors.White)));
        style.Setters.Add(new Setter(HorizontalContentAlignmentProperty, HorizontalAlignment.Stretch));
        return style;
    }
}
