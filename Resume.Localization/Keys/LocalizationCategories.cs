using Resume.Localization.Abstractions;

namespace Resume.Localization.Keys;

public record LocalizationCategories : ILocalizationCategories
{
    /// <inheritdoc />
    public ILinks Links { get; }

    public LocalizationCategories(ILinks links)
    {
        Links = links;
    }
}
