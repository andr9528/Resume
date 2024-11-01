namespace Resume.Presentation;

public class HeaderControl : ContentControl
{
    private ILogger<HeaderControl> logger;

    public HeaderControl()
    {
        logger = Application.Current.ServiceLocation().GetInstance<ILogger<HeaderControl>>();
        var headerViewModel = Application.Current.ServiceLocation().GetInstance<HeaderViewModel>();
        logger.LogInformation($"Successfully Build View Model for Header.");

        this.Content(BuildChildren(headerViewModel));
    }

    private UIElement[] BuildChildren(HeaderViewModel headerViewModel)
    {
        return new UIElement[]
        {
            new AppBar().Content(BuildAppBarContent(headerViewModel)),
        };
    }

    private UIElement[] BuildAppBarContent(HeaderViewModel headerViewModel)
    {
        return new UIElement[]
        {
            BuildHeaderTextElement(headerViewModel),
        };
    }

    private UIElement BuildHeaderTextElement(HeaderViewModel headerViewModel)
    {
        TextBlock headerText =
            new TextBlock().Text(x => x.Binding(() => headerViewModel.Title).Mode(BindingMode.TwoWay));

        return new AppBarElementContainer().Content(headerText);
    }
}
