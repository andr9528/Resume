using Resume.Entities.Abstractions.Enums;
using Resume.Entities.Abstractions.Interfaces;

namespace Resume.Entities;

public class Language : ILanguage
{
    /// <inheritdoc />
    public int Importance { get; set; }

    /// <inheritdoc />
    public string Name { get; set; }

    /// <inheritdoc />
    public LanguageLevel Level { get; set; }
}
