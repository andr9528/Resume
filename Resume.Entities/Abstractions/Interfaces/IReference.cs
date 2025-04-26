namespace Resume.Entities.Abstractions.Interfaces;

public interface IReference : IImportance, IVisibility
{
    public string Name { get; set; }
    public string Company { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string LinkedIn { get; set; }
}
