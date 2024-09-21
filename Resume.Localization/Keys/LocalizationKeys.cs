using Resume.Localization.Keys.Abstraction;

namespace Resume.Localization.Keys;

public record LocalizationKeys : ILocalizationKeys
{
    /// <inheritdoc />
    public ILinks Links { get; }

    public LocalizationKeys(ILinks links)
    {
        Links = links;
    }
}
