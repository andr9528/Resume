namespace Resume.Presentation;

public sealed partial class MainPage
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty] private string? testBox = "Testing Bindings";
        [ObservableProperty] private string? title;


        public MainPageViewModel()
        {
        }
    }
}
