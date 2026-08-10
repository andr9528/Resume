using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Abstraction;
using Resume.Services;

namespace Resume.Frontend.Presentation;

/// <summary>
/// Page navigation menu that hosts "regions" (pages) and swaps Content based on selection.
/// </summary>
public sealed partial class PageSelector : Page
{
    public PageSelector(
        IServiceProvider serviceProvider, IEnumerable<IPageRegion> regionDefinitions, IDownloadService downloadService,
        ILogger<PageSelector> logger)
    {
        ArgumentNullException.ThrowIfNull(serviceProvider);
        ArgumentNullException.ThrowIfNull(regionDefinitions);
        ArgumentNullException.ThrowIfNull(downloadService);
        ArgumentNullException.ThrowIfNull(logger);

        DataContext = new PageSelectorViewModel();

        Margin = new Thickness(0);

        var viewModel = (PageSelectorViewModel) DataContext;
        var logic = new PageSelectorLogic(viewModel, serviceProvider, downloadService, logger);
        var ui = new PageSelectorUi(logic, viewModel, regionDefinitions);

        Content = ui.CreateContentGrid();

        logic.Initialize();
    }
}
