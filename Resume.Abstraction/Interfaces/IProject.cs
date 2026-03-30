namespace Resume.Entities.Abstractions.Interfaces;

public interface IProject : IImportance
{
    public string Name { get; set; }
    public string Description { get; set; }
}
