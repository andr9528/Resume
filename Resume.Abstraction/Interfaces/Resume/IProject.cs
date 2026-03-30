namespace Resume.Abstraction.Interfaces.Resume;

public interface IProject : IImportance
{
    public string Name { get; set; }
    public string Description { get; set; }
}
