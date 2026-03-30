using Resume.Abstraction.Interfaces;

namespace Resume.Entities.Resume;

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
