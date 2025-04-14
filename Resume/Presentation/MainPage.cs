using Resume.Presentation.Core;
using Resume.Presentation.Factory;
using Resume.Services.Abstractions;

namespace Resume.Presentation;

public sealed partial class MainPage : BasePage
{
    public MainPage()
    {
        ILocaleService localeService = GetLocaleService();
        IEntityService entityService = GetEntityService();
        var appInfo = GetAppInfo();

        DataContext = new MainViewModel();

        var logic = new MainPageLogic((MainViewModel) DataContext, localeService, appInfo);
        var ui = new MainPageUi(logic, (MainViewModel) DataContext, localeService, entityService);

        this.Background(Theme.Brushes.Background.Default).Content(ui.CreateContentGrid());

        Console.WriteLine($"Completed Construction of {nameof(MainPage)}.");
    }

    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty] private string? testBox = "Testing Bindings";
        [ObservableProperty] private string? title;


        public MainViewModel()
        {
        }
    }

    public class MainPageLogic
    {
        private readonly MainViewModel viewModel;
        private readonly ILocaleService localeService;
        private readonly IOptions<AppConfig> appInfo;
        private Frame? contentFrame;

        public MainPageLogic(MainViewModel viewModel, ILocaleService localeService, IOptions<AppConfig> appInfo)
        {
            this.viewModel = viewModel;
            this.localeService = localeService;
            this.appInfo = appInfo;

            viewModel.Title += $" - {localeService.GetLocalizedString("ApplicationName")}";
            viewModel.Title += $" - {appInfo?.Value?.Environment}";
            viewModel.Title += $" - Current Language: {localeService.GetCurrentCulture().Name}";
        }

        public void RegisterContentFrameFrame(Frame frame)
        {
            contentFrame = frame;
        }
    }

    public class MainPageUi : BaseUi<MainPageLogic, MainViewModel>
    {
        private readonly ILocaleService localeService;
        private readonly IEntityService entityService;

        public MainPageUi(
            MainPageLogic logic, MainViewModel viewModel, ILocaleService localeService,
            IEntityService entityService) : base(logic, viewModel)
        {
            this.localeService = localeService;
            this.entityService = entityService;
        }

        /// <inheritdoc />
        protected override void ConfigureGrid(Grid grid)
        {
            const int rowOneHeight = 10;
            const int rowTwoHeight = 100 - rowOneHeight;

            grid.SafeArea(SafeArea.InsetMask.VisibleBounds);
            grid.RowDefinitions(new GridLength(rowOneHeight, GridUnitType.Auto),
                new GridLength(rowTwoHeight, GridUnitType.Auto));
        }

        /// <inheritdoc />
        protected override void AddControlsToGrid(Grid grid)
        {
            StackPanel header = CreateHeaderStackPanel().Grid(row: 0, column: 0);
            Frame contentFrame = CreateContentFrame().Grid(row: 1, column: 0);

            grid.Children.Add(header);
            grid.Children.Add(contentFrame);
        }

        private StackPanel CreateHeaderStackPanel()
        {
            StackPanel stackPanel = StackPanelFactory.CreateDefaultPanel();

            TextBlock titleTextBlock = CreateTitleTextBlock();
            StackPanel printButtons = CreatePrintingButtonsStackPanel();
            StackPanel localeButtons = CreateLocalizationButtonsStackPanel();

            stackPanel.Children.Add(titleTextBlock);
            stackPanel.Children.Add(printButtons);
            stackPanel.Children.Add(localeButtons);

            return stackPanel;
        }

        private StackPanel CreateLocalizationButtonsStackPanel()
        {
            StackPanel stackPanel = StackPanelFactory.CreateDefaultPanel();
            stackPanel.HorizontalAlignment = HorizontalAlignment.Right;

            return stackPanel;
        }

        private StackPanel CreatePrintingButtonsStackPanel()
        {
            StackPanel stackPanel = StackPanelFactory.CreateDefaultPanel();

            return stackPanel;
        }

        private TextBlock CreateTitleTextBlock()
        {
            var titleTextBlock = new TextBlock
            {
                FontSize = 20,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
            };
            titleTextBlock.SetBinding(TextBlock.TextProperty, new Binding
            {
                Source = ViewModel,
                Path = new PropertyPath(nameof(ViewModel.Title)),
            });

            return titleTextBlock;
        }

        private Frame CreateContentFrame()
        {
            var frame = new Frame {Background = new SolidColorBrush(Colors.White),};

            Logic.RegisterContentFrameFrame(frame);

            return frame;
        }
    }
}
