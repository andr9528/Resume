using Resume.Entities.Abstractions.Interfaces;

namespace Resume.Entities;

public class Project : IProject
{
    /// <inheritdoc />
    public int Importance { get; set; }

    /// <inheritdoc />
    public string Name { get; set; }

    /// <inheritdoc />
    public string Description { get; set; }
}
