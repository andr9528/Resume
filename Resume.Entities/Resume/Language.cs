using Resume.Abstraction.Enums;
using Resume.Abstraction.Interfaces;

namespace Resume.Entities.Resume;

public class Language : ILanguage
{
    /// <inheritdoc />
    public int Importance { get; set; }

    /// <inheritdoc />
    public string Name { get; set; }

    /// <inheritdoc />
    public LanguageLevel Level { get; set; }
}
