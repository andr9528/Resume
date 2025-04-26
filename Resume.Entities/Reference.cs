using Resume.Entities.Abstractions.Interfaces;

namespace Resume.Entities;

public class Reference : IReference
{
    /// <inheritdoc />
    public int Importance { get; set; }

    /// <inheritdoc />
    public bool IsShown { get; set; }

    /// <inheritdoc />
    public string Name { get; set; }

    /// <inheritdoc />
    public string Company { get; set; }

    /// <inheritdoc />
    public string Phone { get; set; }

    /// <inheritdoc />
    public string Email { get; set; }

    /// <inheritdoc />
    public string LinkedIn { get; set; }
}
