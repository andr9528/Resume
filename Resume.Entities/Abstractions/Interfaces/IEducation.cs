namespace Resume.Entities.Abstractions.Interfaces;

public interface IEducation : IPeriod
{
    public string SchoolName { get; set; }
    public string Description { get; set; }
    public string Grade { get; set; }
    public string City { get; set; }
}
