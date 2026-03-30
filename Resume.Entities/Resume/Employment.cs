using Resume.Abstraction.Interfaces;

namespace Resume.Entities.Resume;

public class Employment : IEmployment
{
    /// <inheritdoc />
    public string Employer { get; set; }

    /// <inheritdoc />
    public string JobTitle { get; set; }

    /// <inheritdoc />
    public string WorkDescription { get; set; }

    /// <inheritdoc />
    public string City { get; set; }

    /// <inheritdoc />
    public IList<string>? Links { get; set; }

    /// <inheritdoc />
    public DateTime StartDate { get; set; }

    /// <inheritdoc />
    public DateTime? EndDate { get; set; }
}
