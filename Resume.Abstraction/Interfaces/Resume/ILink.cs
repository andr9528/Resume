namespace Resume.Abstraction.Interfaces.Resume;

public interface ILink : IImportance
{
    public string Title { get; set; }
    public string Remark { get; set; }
    public string Url { get; set; }
}
