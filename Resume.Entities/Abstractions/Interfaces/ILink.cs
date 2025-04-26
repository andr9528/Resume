namespace Resume.Entities.Abstractions.Interfaces;

public interface ILink : IImportance
{
    public string Title { get; set; }
    public string Remark { get; set; }
    public string Url { get; set; }
}
