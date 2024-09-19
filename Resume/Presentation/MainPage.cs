namespace Resume.Presentation;

public sealed partial class MainPage : Page
{
    public MainPage()
    {
        this.DataContext<BindableMainModel>((page, vm) => page.NavigationCacheMode(NavigationCacheMode.Required)
            .Background(Theme.Brushes.Background.Default).Content(new Grid().SafeArea(SafeArea.InsetMask.All)
                .RowDefinitions("Auto,*").Children(new NavigationBar().Content(() => vm.Title),
                    new StackPanel().Grid(row: 1).HorizontalAlignment(HorizontalAlignment.Center)
                        .VerticalAlignment(VerticalAlignment.Center).Spacing(16).Children(GetStackChildren(vm)))));
    }

    private UIElement[] GetStackChildren(BindableMainModel vm)
    {
        return new UIElement[]
        {
            new TextBox().Text(x => x.Binding(() => vm.Name).Mode(BindingMode.TwoWay))
                .PlaceholderText("Enter your name:"),
            new Button().Content("Go to Second Page").AutomationProperties(automationId: "SecondPageButton")
                .Command(() => vm.Test),
            new TextBox().Text(x => x.Binding(vm.TestBox).Mode(BindingMode.TwoWay))
                .PlaceholderText("Awaiting Test Text..."),
        };
    }
}
