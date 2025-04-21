using Resume.Localization.Abstractions;
using Resume.Localization.Strings;

namespace Resume.Localization.Keys;

public record LanguageKeys : ILanguageKeys
{
    /// <inheritdoc />
    public string DanishLanguage { get; init; } = nameof(Resources.Language_Danish_Language);

    /// <inheritdoc />
    public string EnglishLanguage { get; init; } = nameof(Resources.Language_English_Language);

    /// <inheritdoc />
    public string GermanLanguage { get; init; } = nameof(Resources.Language_German_Language);
}

