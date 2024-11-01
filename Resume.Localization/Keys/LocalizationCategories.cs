using Resume.Localization.Abstractions;

namespace Resume.Localization.Keys;

public record LocalizationCategories : ILocalizationCategories
{
    /// <inheritdoc />
    public ILinkKeys LinkKeys { get; }

    /// <inheritdoc />
    public IProfileKeys ProfileKeys { get; }

    public LocalizationCategories(ILinkKeys linkKeys, IProfileKeys profileKeys)
    {
        LinkKeys = linkKeys;
        ProfileKeys = profileKeys;
    }
}
