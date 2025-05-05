namespace Resume.Entities.Abstractions.Interfaces;

public interface IEmployment : IPeriod
{
    public string Employer { get; set; }
    public string JobTitle { get; set; }
    public string WorkDescription { get; set; }
    public string City { get; set; }
    public IList<string>? Links { get; set; }
}
