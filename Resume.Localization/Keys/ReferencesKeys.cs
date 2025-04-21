using Resume.Localization.Abstractions;
using Resume.Localization.Strings;

namespace Resume.Localization.Keys;

public record ReferencesKeys : IReferencesKeys
{
    /// <inheritdoc />
    public string CompanyNameTv2 { get; init; } = nameof(Resources.References_Company_Name_Tv2);
}

