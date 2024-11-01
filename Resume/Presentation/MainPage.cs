namespace Resume.Presentation;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.DataContext<MainViewModel>(BuildDataContext);
    }

    private void BuildDataContext(MainPage page, MainViewModel vm)
    {
        page.NavigationCacheMode(NavigationCacheMode.Required).Background(Theme.Brushes.Background.Default)
            .Content(BuildPageContent(vm));
    }

    private Grid BuildPageContent(MainViewModel vm)
    {
        return new Grid().SafeArea(SafeArea.InsetMask.All).RowDefinitions("Auto,*").Children(GetGridChildren(vm));
    }

    private UIElement[] GetGridChildren(MainViewModel vm)
    {
        return new UIElement[]
        {
            new HeaderControl(),
            new StackPanel().Grid(row: 1).HorizontalAlignment(HorizontalAlignment.Center)
                .VerticalAlignment(VerticalAlignment.Center).Spacing(16).Children(GetStackChildren(vm)),
        };
    }

    private UIElement[] GetStackChildren(MainViewModel vm)
    {
        return new UIElement[]
        {
            new TextBox().Text("Does this Render?"),
            new Button().Content("Test Button").AutomationProperties(automationId: "TestButton")
                .Command(() => vm.TestCommand),
            new TextBox().Text(x => x.Binding(() => vm.TestBox).Mode(BindingMode.TwoWay))
                .PlaceholderText("Awaiting Test Text..."),
        };
    }
}
