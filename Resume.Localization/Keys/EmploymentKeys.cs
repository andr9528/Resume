using Resume.Localization.Abstractions;
using Resume.Localization.Strings;

namespace Resume.Localization.Keys;

public record EmploymentKeys : IEmploymentKeys
{
    /// <inheritdoc />
    public string EmployerApps4All { get; init; } = nameof(Resources.Employment_Employer_Apps4All);

    /// <inheritdoc />
    public string EmployerTv2 { get; init; } = nameof(Resources.Employment_Employer_Tv2);

    /// <inheritdoc />
    public string JobTitleApps4All { get; init; } = nameof(Resources.Employment_Job_Title_Apps4All);

    /// <inheritdoc />
    public string JobTitleTv2 { get; init; } = nameof(Resources.Employment_Job_Title_Tv2);

    /// <inheritdoc />
    public string WorkDescriptionApps4All { get; init; } = nameof(Resources.Employment_Work_Description_Apps4All);

    /// <inheritdoc />
    public string WorkDescriptionTv2 { get; init; } = nameof(Resources.Employment_Work_Description_Tv2);
}
