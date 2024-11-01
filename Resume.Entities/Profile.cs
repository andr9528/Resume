using Resume.Entities.Abstractions;

namespace Resume.Entities;

public class Profile : IProfile
{
    /// <inheritdoc />
    public string Description { get; init; }

    /// <inheritdoc />
    public string Name { get; init; }
}
