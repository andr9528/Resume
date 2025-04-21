using Resume.Localization.Abstractions;
using Resume.Localization.Strings;

namespace Resume.Localization.Keys;

public record UserInterfaceKeys : IUserInterfaceKeys
{
    /// <inheritdoc />
    public string Title { get; init; } = nameof(Resources.User_Interface_Title);

    /// <inheritdoc />
    public string SkillsHeader { get; init; } = nameof(Resources.User_Interface_Skills_Header);
}
