using Resume.Abstraction.Enums;
using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Abstraction;
using Resume.Frontend.Presentation;

namespace Resume.Frontend.NavigationRegion;

public class EnglishPageRegionDefinition : IPageRegion
{
    private readonly ILogger<EnglishPageRegionDefinition> logger;

    public EnglishPageRegionDefinition(ILogger<EnglishPageRegionDefinition> logger)
    {
        this.logger = logger;
    }

    /// <inheritdoc />
    public string DisplayName => "English";

    /// <inheritdoc />
    public IconElement Icon => new SymbolIcon(Symbol.Flag);

    /// <inheritdoc />
    public async Task<UIElement> CreateControl(IServiceProvider services)
    {
        try
        {
            ILocaleService localeService = services.GetService<ILocaleService>() ??
                                           throw new ArgumentException(
                                               $"Expected to get an implementation of {nameof(ILocaleService)}");
            await localeService.SetLanguage(LanguageType.ENGLISH);

            logger.LogInformation($"Changing page to: English {nameof(StructureFrame)}");
            return ActivatorUtilities.CreateInstance<StructureFrame>(services);
        }
        catch (Exception e)
        {
            logger.LogError(e, $"Exception caught when attempting to change page to '{DisplayName}'");
            throw;
        }
    }
}
