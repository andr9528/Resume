using Resume.Localization.Abstractions;

namespace Resume.Localization.Keys;

public record LocalizationCategories : ILocalizationCategories
{
    /// <inheritdoc />
    public ILinkKeys LinkKeys { get; }

    /// <inheritdoc />
    public IProfileKeys ProfileKeys { get; }

    /// <inheritdoc />
    public IUserInterfaceKeys UserInterfaceKeys { get; }

    public LocalizationCategories(ILinkKeys linkKeys, IProfileKeys profileKeys, IUserInterfaceKeys userInterfaceKeys)
    {
        LinkKeys = linkKeys;
        ProfileKeys = profileKeys;
        UserInterfaceKeys = userInterfaceKeys;
    }
}
