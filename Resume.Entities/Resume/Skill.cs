using Resume.Abstraction.Enums;
using Resume.Abstraction.Interfaces;

namespace Resume.Entities.Resume;

public class Skill : ISkill
{
    /// <inheritdoc />
    public int Importance { get; set; }

    /// <inheritdoc />
    public string Name { get; set; }

    /// <inheritdoc />
    public SkillLevel Expertise { get; set; }
}
