using Resume.Entities.Abstractions.Enums;

namespace Resume.Entities.Abstractions.Interfaces;

public interface ILanguage : IImportance
{
    public string Name { get; set; }
    public LanguageLevel Level { get; set; }
}
