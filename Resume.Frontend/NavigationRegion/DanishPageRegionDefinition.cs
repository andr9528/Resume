using System.Drawing;
using Resume.Abstraction.Enums;
using Resume.Abstraction.Interfaces.Services;
using Resume.Frontend.Abstraction;
using Resume.Frontend.Presentation;

namespace Resume.Frontend.NavigationRegion;

public class DanishPageRegionDefinition : IPageRegion
{
    private readonly ILogger<DanishPageRegionDefinition> logger;

    public DanishPageRegionDefinition(ILogger<DanishPageRegionDefinition> logger)
    {
        this.logger = logger;
    }

    /// <inheritdoc />
    public string DisplayName => "Dansk";

    /// <inheritdoc />
    public IconElement Icon => new SymbolIcon(Symbol.Flag);

    /// <inheritdoc />
    public UIElement CreateControl(IServiceProvider services)
    {
        ILocaleService localeService = services.GetService<ILocaleService>() ??
                                       throw new ArgumentException(
                                           $"Expected to get an implementation of {nameof(ILocaleService)}");
        localeService.SetLanguage(LanguageType.DANISH);

        logger.LogInformation($"Changing page to: Danish {nameof(StructureBorder)}");
        return ActivatorUtilities.CreateInstance<StructureBorder>(services, LanguageType.DANISH);
    }
}
