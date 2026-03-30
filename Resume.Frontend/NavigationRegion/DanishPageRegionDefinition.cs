using System.Drawing;
using Resume.Abstraction.Enums;
using Resume.Frontend.Abstraction;
using Resume.Frontend.Presentation;

namespace Resume.Frontend.NavigationRegion;

public class DanishPageRegionDefinition : IPageRegion
{
    private readonly ILogger<DanishPageRegionDefinition> logger;
    private UIElement? region;

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
        logger.LogInformation($"Changing page to: Danish {nameof(StructureBorder)}");
        if (region != null)
        {
            return region;
        }

        region = ActivatorUtilities.CreateInstance<StructureBorder>(services, LanguageType.DANISH);
        return region;
    }
}
