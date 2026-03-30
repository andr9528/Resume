using Resume.Localization.Abstractions;
using Resume.Presentation.Core;
using Resume.Services.Abstractions;

namespace Resume.Presentation;

public sealed partial class MainPage
{
    public class MainPageLogic : BaseLogic<MainPageViewModel>
    {
        private readonly ILocaleService localeService;
        private readonly IOptions<AppConfig> appInfo;
        private readonly ILocalizationCategories categories;
        private Frame? contentFrame;

        public MainPageLogic(
            MainPageViewModel viewModel, ILocaleService localeService, IOptions<AppConfig> appInfo,
            ILocalizationCategories categories) : base(viewModel)
        {
            this.localeService = localeService;
            this.appInfo = appInfo;
            this.categories = categories;

            string title = localeService.GetLocalizedString(categories.UserInterfaceKeys.Title);
            Console.WriteLine($"Title: {title}");

            ViewModel.Title = title;
            ViewModel.Title += $" - {appInfo?.Value?.Environment}";
            ViewModel.Title += $" - Current Language: {localeService.GetCurrentCulture().Name}";
        }

        public void RegisterContentFrameFrame(Frame frame)
        {
            contentFrame = frame;
        }
    }
}
