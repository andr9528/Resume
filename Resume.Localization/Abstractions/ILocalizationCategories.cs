namespace Resume.Localization.Abstractions;

public interface ILocalizationCategories
{
    ILinkKeys LinkKeys { get; }
    IProfileKeys ProfileKeys { get; }
    IUserInterfaceKeys UserInterfaceKeys { get; }
    IEmploymentKeys EmploymentKeys { get; }
    IEducationKeys EducationKeys { get; }
    IGeneralInformationKeys GeneralInformationKeys { get; }
    ILanguageKeys LanguageKeys { get; }
    IReferencesKeys ReferencesKeys { get; }
    IProjectKeys ProjectKeys { get; }
}
