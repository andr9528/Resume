using Resume.Abstraction.Interfaces.Resume;

namespace Resume.Models.Resume;

public class Course : ICourse
{
    /// <inheritdoc />
    public DateTime StartDate { get; set; }

    /// <inheritdoc />
    public DateTime? EndDate { get; set; }

    /// <inheritdoc />
    public string Name { get; set; }

    /// <inheritdoc />
    public string Description { get; set; }
}
