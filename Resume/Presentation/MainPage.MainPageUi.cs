using Resume.Presentation.Core;
using Resume.Presentation.Factory;
using Resume.Services.Abstractions;

namespace Resume.Presentation;

public sealed partial class MainPage
{
    public class MainPageUi : BaseUi<MainPageLogic, MainPageViewModel>
    {
        private readonly ILocaleService localeService;
        private readonly IEntityService entityService;

        public MainPageUi(
            MainPageLogic logic, MainPageViewModel viewModel, ILocaleService localeService,
            IEntityService entityService) : base(logic, viewModel)
        {
            this.localeService = localeService;
            this.entityService = entityService;
        }

        /// <inheritdoc />
        protected override void ConfigureGrid(Grid grid)
        {
            const int rowOneHeight = 15;
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
            stackPanel.Background = new SolidColorBrush(Colors.Black);
            stackPanel.HorizontalAlignment = HorizontalAlignment.Stretch;
            stackPanel.VerticalAlignment = VerticalAlignment.Stretch;
            stackPanel.Margin = new Thickness(0, 0, 0, 0);
            stackPanel.Padding = new Thickness(10);

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
                Foreground = new SolidColorBrush(Colors.White),
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
