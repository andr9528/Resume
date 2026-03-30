using Resume.Abstraction.Enums;

namespace Resume.Abstraction.Interfaces.Resume;

public interface ISkill : IImportance
{
    public string Name { get; set; }
    public SkillLevel Expertise { get; set; }
}
