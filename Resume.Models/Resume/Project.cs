using Resume.Abstraction.Interfaces.Resume;

namespace Resume.Entities.Resume;

public class Project : IProject
{
    /// <inheritdoc />
    public int Importance { get; set; }

    /// <inheritdoc />
    public string Name { get; set; }

    /// <inheritdoc />
    public string Description { get; set; }
}
