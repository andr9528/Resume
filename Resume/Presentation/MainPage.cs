namespace Resume.Presentation;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        //this.DataContext<MainViewModel>((page, vm) => page.NavigationCacheMode(NavigationCacheMode.Required)
        //    .Background(Theme.Brushes.Background.Default).Content(new Grid().SafeArea(SafeArea.InsetMask.All)
        //        .RowDefinitions("Auto,*").Children(new NavigationBar().Content(() => vm.Title),
        //            new StackPanel().Grid(row: 1).HorizontalAlignment(HorizontalAlignment.Center)
        //                .VerticalAlignment(VerticalAlignment.Center).Spacing(16).Children(GetStackChildren(vm)))));

        this.DataContext<MainViewModel>((page, vm) => page.NavigationCacheMode(NavigationCacheMode.Required)
            .Background(Theme.Brushes.Background.Default).Content(new Grid().SafeArea(SafeArea.InsetMask.All)
                .RowDefinitions("Auto,*").Children(new NavigationBar().Content(() => vm.Title),
                    new StackPanel().Grid(row: 1).HorizontalAlignment(HorizontalAlignment.Center)
                        .VerticalAlignment(VerticalAlignment.Center).Spacing(16).Children(GetStackChildren(vm)))));
    }

    private UIElement[] GetStackChildren(MainViewModel vm)
    {
        return new UIElement[]
        {
            new TextBox().Text("Does this Render?"),
            new Button().Content("Test Button").AutomationProperties(automationId: "TestButton")
                .Command(() => vm.Test()),
            new TextBox().Text(x => x.Binding(() => vm.TestBox).Mode(BindingMode.TwoWay))
                .PlaceholderText("Awaiting Test Text..."),
        };
    }
}
