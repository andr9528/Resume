using Resume.Entities.Abstractions.Enums;

namespace Resume.Entities.Abstractions.Interfaces;

public interface ISkill : IImportance
{
    public string Name { get; set; }
    public SkillLevel Expertise { get; set; }
}
