using Resume.Abstraction.Enums;

namespace Resume.Abstraction.Interfaces;

public interface ILanguage : IImportance
{
    public string Name { get; set; }
    public LanguageLevel Level { get; set; }
}
