using Resume.Entities.Abstractions.Interfaces;

namespace Resume.Entities;

public class Education : IEducation
{
    /// <inheritdoc />
    public DateTime StartDate { get; set; }

    /// <inheritdoc />
    public DateTime? EndDate { get; set; }

    /// <inheritdoc />
    public string SchoolName { get; set; }

    /// <inheritdoc />
    public string Description { get; set; }

    /// <inheritdoc />
    public string Grade { get; set; }

    /// <inheritdoc />
    public string City { get; set; }
}
