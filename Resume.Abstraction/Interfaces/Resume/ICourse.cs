namespace Resume.Abstraction.Interfaces.Resume;

public interface ICourse : IPeriod
{
    public string Name { get; set; }
    public string Description { get; set; }
}
