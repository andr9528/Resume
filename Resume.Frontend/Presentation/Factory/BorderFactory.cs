namespace Resume.Frontend.Presentation.Factory;

public static class BorderFactory
{
    public static void ConfigureSectionBorder(this Border border)
    {
        border.BorderThickness = new Thickness(0, 3, 0, 0);
        border.BorderBrush = new SolidColorBrush(Colors.Black);
        border.Padding = new Thickness(0, 5, 0, 0);
    }
}
