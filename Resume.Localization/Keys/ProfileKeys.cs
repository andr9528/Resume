using Resume.Abstraction.Interfaces.Keys;
using Resume.Localization.Strings;

namespace Resume.Localization.Keys;

public record ProfileKeys : IProfileKeys
{
    /// <inheritdoc />
    public string Description { get; init; } = nameof(Resources.Profile_Description);

    /// <inheritdoc />
    public string Name { get; init; } = nameof(Resources.Profile_Name);
}
