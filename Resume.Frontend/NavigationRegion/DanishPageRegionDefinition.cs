using System.Drawing;
using Resume.Abstraction.Enums;
using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Abstraction;
using Resume.Frontend.Presentation;

namespace Resume.Frontend.NavigationRegion;

public class DanishPageRegionDefinition : IPageRegion
{
    private readonly ILogger<DanishPageRegionDefinition> logger;
    private UIElement? cachedControl;

    public DanishPageRegionDefinition(ILogger<DanishPageRegionDefinition> logger)
    {
        this.logger = logger;
    }

    public string DisplayName => "Dansk";

    public IconElement Icon => new SymbolIcon(Symbol.Flag);

    public async Task<UIElement> CreateControl(IServiceProvider services)
    {
        try
        {
            ILocaleService localeService = services.GetService<ILocaleService>() ??
                                           throw new ArgumentException(
                                               $"Expected to get an implementation of {nameof(ILocaleService)}");

            await localeService.SetLanguage(LanguageType.DANISH);

            if (cachedControl != null)
            {
                return cachedControl;
            }

            logger.LogInformation($"Creating page: Danish {nameof(StructureFrame)}");

            cachedControl = ActivatorUtilities.CreateInstance<StructureFrame>(services);

            return cachedControl;
        }
        catch (Exception e)
        {
            logger.LogError(e, $"Exception caught when attempting to change page to '{DisplayName}'");
            throw;
        }
    }
}
