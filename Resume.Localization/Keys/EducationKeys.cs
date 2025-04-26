using Resume.Localization.Abstractions;
using Resume.Localization.Strings;

namespace Resume.Localization.Keys;

public record EducationKeys : IEducationKeys
{
    /// <inheritdoc />
    public string GradeBachelor { get; init; } = nameof(Resources.Education_Grade_Bachelor);

    /// <inheritdoc />
    public string GradeSoftware { get; init; } = nameof(Resources.Education_Grade_Software);

    /// <inheritdoc />
    public string GradeHtx { get; init; } = nameof(Resources.Education_Grade_Htx);

    /// <inheritdoc />
    public string DescriptionBachelor { get; init; } = nameof(Resources.Education_Description_Bachelor);

    /// <inheritdoc />
    public string DescriptionSoftware { get; init; } = nameof(Resources.Education_Description_Software);

    /// <inheritdoc />
    public string DescriptionHtx { get; init; } = nameof(Resources.Education_Description_Htx);

    /// <inheritdoc />
    public string SchoolNameHtx { get; init; } = nameof(Resources.Education_School_Name_Htx);

    /// <inheritdoc />
    public string SchoolNameUcl { get; init; } = nameof(Resources.Education_School_Name_Ucl);
}
