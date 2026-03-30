using Resume.Abstraction.Interfaces.Resume;

namespace Resume.Models.Resume;

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
