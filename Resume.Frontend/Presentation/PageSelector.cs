using Resume.Frontend.Abstraction;
using Resume.Frontend.Extensions;
using Resume.Frontend.Presentation.Factory;

namespace Resume.Frontend.Presentation;

/// <summary>
/// Page navigation menu that hosts "regions" (pages) and swaps Content based on selection.
/// </summary>
public sealed partial class PageSelector : Page
{
    private const double PANE_COLUMN_WEIGHT = 10d;
    private readonly IServiceProvider serviceProvider;

    private ListView menuList = null!;
    private Frame contentFrame = null!;
    private Frame paneFrame = null!;

    public PageSelector(IServiceProvider sp, IEnumerable<IPageRegion> regionDefinitions)
    {
        serviceProvider = sp ?? throw new ArgumentNullException(nameof(sp));

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
        var paneRoot = GridFactory.CreateDefaultGrid();

        paneRoot.Background = new SolidColorBrush(Color.FromArgb(255, 32, 32, 32));
        paneRoot.HorizontalAlignment = HorizontalAlignment.Stretch;
        paneRoot.VerticalAlignment = VerticalAlignment.Stretch;
        paneRoot.Margin = new Thickness(0);
        paneRoot.Padding = new Thickness(0);

        paneRoot.Children.Add(menuList);

        return paneRoot;
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
