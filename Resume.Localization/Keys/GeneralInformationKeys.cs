using Resume.Localization.Abstractions;
using Resume.Localization.Strings;

namespace Resume.Localization.Keys;

public record GeneralInformationKeys : IGeneralInformationKeys
{
    /// <inheritdoc />
    public string Country { get; init; } = nameof(Resources.General_Information_Country);
}
