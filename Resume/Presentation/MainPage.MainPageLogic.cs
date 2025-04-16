using Resume.Localization.Abstractions;
using Resume.Services.Abstractions;

namespace Resume.Presentation;

public sealed partial class MainPage
{
    public class MainPageLogic
    {
        private readonly MainPageViewModel viewModel;
        private readonly ILocaleService localeService;
        private readonly IOptions<AppConfig> appInfo;
        private readonly ILocalizationCategories categories;
        private Frame? contentFrame;

        public MainPageLogic(
            MainPageViewModel viewModel, ILocaleService localeService, IOptions<AppConfig> appInfo,
            ILocalizationCategories categories)
        {
            this.viewModel = viewModel;
            this.localeService = localeService;
            this.appInfo = appInfo;
            this.categories = categories;

            string title = localeService.GetLocalizedString(categories.UserInterfaceKeys.Title);
            Console.WriteLine($"Title: {title}");

            viewModel.Title = title;
            viewModel.Title += $" - {appInfo?.Value?.Environment}";
            viewModel.Title += $" - Current Language: {localeService.GetCurrentCulture().Name}";
        }

        public void RegisterContentFrameFrame(Frame frame)
        {
            contentFrame = frame;
        }
    }
}
