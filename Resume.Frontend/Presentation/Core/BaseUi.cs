using Resume.Localization.Abstractions;
using Resume.Services.Abstractions;
using Serilog;

namespace Resume.Presentation.Core;

public abstract class BaseUi<TLogic, TViewModel> where TLogic : class where TViewModel : class
{
    protected BaseUi(
        TLogic logic, TViewModel viewModel, ILocaleService localeService, ILocalizationCategories categories,
        IEntityService entityService)
    {
        Logic = logic;
        ViewModel = viewModel;
        LocaleService = localeService;
        LocaleCategories = categories;
        EntityService = entityService;
    }

    protected TLogic Logic { get; }
    protected TViewModel ViewModel { get; }
    public ILocaleService LocaleService { get; }
    public ILocalizationCategories LocaleCategories { get; }
    public IEntityService EntityService { get; }

    public Grid CreateContentGrid()
    {
        var grid = new Grid();

        ConfigureGrid(grid);
        AddControlsToGrid(grid);

        return grid;
    }

    protected abstract void ConfigureGrid(Grid grid);

    protected abstract void AddControlsToGrid(Grid grid);
}
