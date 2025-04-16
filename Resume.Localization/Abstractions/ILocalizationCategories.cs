namespace Resume.Localization.Abstractions;

public interface ILocalizationCategories
{
    ILinkKeys LinkKeys { get; }
    IProfileKeys ProfileKeys { get; }
    IUserInterfaceKeys UserInterfaceKeys { get; }
}
