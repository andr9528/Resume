using Resume.Abstraction.Interfaces;

namespace Resume.Entities.Resume;

public class Link : ILink
{
    /// <inheritdoc />
    public int Importance { get; set; }

    /// <inheritdoc />
    public string Title { get; set; }

    /// <inheritdoc />
    public string Remark { get; set; }

    /// <inheritdoc />
    public string Url { get; set; }
}
