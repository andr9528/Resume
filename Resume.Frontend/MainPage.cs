using Resume.Abstraction.Interfaces.Keys;
using Resume.Frontend.Extensions;
using Resume.Frontend.Presentation.Core;
using Resume.Frontend.Presentation.Factory;
using Resume.Services.Abstractions;

namespace Resume.Frontend.Presentation;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        Background = new SolidColorBrush(Colors.LightGray);

        Grid contentGrid = CreateGrid();
        AddElementsToGrid(contentGrid);

        Content = contentGrid;
    }

    private void AddElementsToGrid(Grid contentGrid)
    {
        var selector = ActivatorUtilities.CreateInstance<PageSelector>(App.Startup.ServiceProvider);

        contentGrid.Children.Add(selector.SetRow(0).SetColumn(0));
    }

    private Grid CreateGrid()
    {
        Grid grid = GridFactory.CreateDefaultGrid();
        grid.Margin(new Thickness(0));

        grid.DefineRows(sizes: [100,]);
        grid.DefineColumns(sizes: [100,]);

        return grid;
    }
}
