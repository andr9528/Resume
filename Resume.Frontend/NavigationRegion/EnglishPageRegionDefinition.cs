using Resume.Abstraction.Enums;
using Resume.Frontend.Abstraction;
using Resume.Frontend.Presentation;

namespace Resume.Frontend.NavigationRegion;

public class EnglishPageRegionDefinition : IPageRegion
{
    private readonly ILogger<EnglishPageRegionDefinition> logger;
    private UIElement? region;

    public EnglishPageRegionDefinition(ILogger<EnglishPageRegionDefinition> logger)
    {
        this.logger = logger;
    }

    /// <inheritdoc />
    public string DisplayName => "English";

    /// <inheritdoc />
    public IconElement Icon => new SymbolIcon(Symbol.Flag);

    /// <inheritdoc />
    public UIElement CreateControl(IServiceProvider services)
    {
        logger.LogInformation($"Changing page to: English {nameof(StructureBorder)}");
        if (region != null)
        {
            return region;
        }

        region = ActivatorUtilities.CreateInstance<StructureBorder>(services, LanguageType.ENGLISH);
        return region;
    }
}
