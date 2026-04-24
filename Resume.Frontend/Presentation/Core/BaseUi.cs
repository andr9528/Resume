using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Presentation.Factory;

namespace Resume.Frontend.Presentation.Core;

public abstract class BaseUi<TLogic, TViewModel> where TLogic : class where TViewModel : class
{
    protected BaseUi(TLogic logic, TViewModel viewModel, IEntityService entityService)
    {
        Logic = logic;
        ViewModel = viewModel;
        EntityService = entityService;
    }

    protected TLogic Logic { get; }
    protected TViewModel ViewModel { get; }

    protected IEntityService EntityService { get; }

    public Grid CreateContentGrid()
    {
        var grid = GridFactory.CreateDefaultGrid();

        ConfigureGrid(grid);
        AddControlsToGrid(grid);

        return grid;
    }

    protected abstract void ConfigureGrid(Grid grid);

    protected abstract void AddControlsToGrid(Grid grid);
}
