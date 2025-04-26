namespace Resume.Entities.Abstractions.Interfaces;

public interface IGeneralInformation
{
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public string Country { get; set; }
    public int PhoneNumber { get; set; }
    public int PostalCode { get; set; }
    public DateTime DateOfBirth { get; set; }
}
