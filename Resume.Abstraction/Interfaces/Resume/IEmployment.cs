namespace Resume.Abstraction.Interfaces.Resume;

public interface IEmployment : IPeriod
{
    public string Employer { get; set; }
    public string JobTitle { get; set; }
    public string WorkDescription { get; set; }
    public string City { get; set; }
    public string EmploymentType { get; set; }
    public IList<string>? Links { get; set; }
}
