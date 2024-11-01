using Resume.Localization.Abstractions;

namespace Resume.Localization.Keys;

public class ProfileKeys : IProfileKeys
{
    /// <inheritdoc />
    public string Description { get; init; } = "Profile_Description";

    /// <inheritdoc />
    public string Name { get; init; } = "Profile_Name";
}
