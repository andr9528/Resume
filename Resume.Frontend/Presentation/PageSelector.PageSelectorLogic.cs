using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Abstraction;
using Resume.Frontend.Presentation.Core;
using Uno.Foundation;

namespace Resume.Frontend.Presentation;

public sealed partial class PageSelector
{
    private sealed class PageSelectorLogic : BaseLogic<PageSelectorViewModel>
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IDownloadService downloadService;
        private readonly ILogger<PageSelector> logger;

        public PageSelectorLogic(
            PageSelectorViewModel viewModel, IServiceProvider serviceProvider, IDownloadService downloadService,
            ILogger<PageSelector> logger) : base(viewModel)
        {
            this.serviceProvider = serviceProvider;
            this.downloadService = downloadService;
            this.logger = logger;
        }

        private async Task PreloadRegions()
        {
            foreach (IPageRegion region in ViewModel.Regions)
            {
                UIElement control = await region.CreateControl(serviceProvider);

                control.Opacity = 0;
                control.IsHitTestVisible = false;

                ViewModel.RegionControls.Add(region, control);
                ViewModel.ContentHost.Children.Add(control);
            }
        }

        private async Task ShowRegion(IPageRegion region)
        {
            await region.CreateControl(serviceProvider);

            foreach ((IPageRegion key, UIElement control) in ViewModel.RegionControls)
            {
                bool isSelected = key == region;

                control.Opacity = isSelected ? 1 : 0;
                control.IsHitTestVisible = isSelected;
            }
        }

        public async void MenuListItemClicked(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (e.ClickedItem is not IPageRegion region)
                {
                    return;
                }

                await ShowRegion(region);
            }
            catch (Exception exe)
            {
                logger.LogError(exe, "Exception thrown while attempting to change language.");
            }
        }

        private async Task NavigateToFirstRegion()
        {
            if (!ViewModel.Regions.Any())
            {
                return;
            }

            IPageRegion region = ViewModel.Regions[0];

            ViewModel.MenuList.SelectedItem = region;

            await ShowRegion(region);
        }

        internal async void DownloadButtonClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                await downloadService.DownloadResumePdf(DownloadAction);
            }
            catch (Exception exe)
            {
                logger.LogError(exe, "Exception thrown while attempting to download Pdf.");
            }
        }

        private Task DownloadAction(string url, string fileName)
        {
#if __WASM__
            string packageBase = GetPackageBase();
            string fullUrl = BuildFullUrl(packageBase, url);

            logger.LogInformation("Download Url: {Url}", url);
            logger.LogInformation("Download FileName: {FileName}", fileName);
            logger.LogInformation("Download PackageBase: {PackageBase}", packageBase);
            logger.LogInformation("Download FullUrl: {FullUrl}", fullUrl);

            string safeFullUrl = ToJavaScriptString(fullUrl);
            string safeName = ToJavaScriptString(fileName);

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

        private string ToJavaScriptString(string value)
        {
            return "'" + value.Replace("\\", "\\\\").Replace("'", "\\'").Replace("\r", "\\r").Replace("\n", "\\n") +
                   "'";
        }

        private string BuildFullUrl(string packageBase, string relativeUrl)
        {
            if (string.IsNullOrWhiteSpace(packageBase))
            {
                logger.LogWarning("Package base was empty. Falling back to relative URL: {RelativeUrl}", relativeUrl);

                return relativeUrl;
            }

            return new Uri(new Uri(packageBase), relativeUrl).ToString();
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

        public async void Initialize()
        {
            try
            {
                await PreloadRegions();
                await NavigateToFirstRegion();
            }
            catch (Exception e)
            {
                logger.LogError(e, "Exception thrown during Initialization of Pages");
                throw;
            }
        }
    }
}
