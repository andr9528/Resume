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

    /// <inheritdoc />
    public IEmploymentKeys EmploymentKeys { get; }

    /// <inheritdoc />
    public IEducationKeys EducationKeys { get; }

    /// <inheritdoc />
    public IGeneralInformationKeys GeneralInformationKeys { get; }

    /// <inheritdoc />
    public ILanguageKeys LanguageKeys { get; }

    /// <inheritdoc />
    public IReferencesKeys ReferencesKeys { get; }

    /// <inheritdoc />
    public IProjectKeys ProjectKeys { get; }

    public LocalizationCategories(
        ILinkKeys linkKeys, IProfileKeys profileKeys, IUserInterfaceKeys userInterfaceKeys,
        IEmploymentKeys employmentKeys, IEducationKeys educationKeys, IGeneralInformationKeys generalInformationKeys,
        ILanguageKeys languageKeys, IReferencesKeys referencesKeys, IProjectKeys projectKeys)
    {
        LinkKeys = linkKeys;
        ProfileKeys = profileKeys;
        UserInterfaceKeys = userInterfaceKeys;
        EmploymentKeys = employmentKeys;
        EducationKeys = educationKeys;
        GeneralInformationKeys = generalInformationKeys;
        LanguageKeys = languageKeys;
        ReferencesKeys = referencesKeys;
        ProjectKeys = projectKeys;
    }
}
