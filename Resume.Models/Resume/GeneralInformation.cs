using Resume.Abstraction.Interfaces.Resume;

namespace Resume.Models.Resume;

public class GeneralInformation : IGeneralInformation
{
    /// <inheritdoc />
    public string FirstName { get; set; }

    /// <inheritdoc />
    public string MiddleName { get; set; }

    /// <inheritdoc />
    public string LastName { get; set; }

    /// <inheritdoc />
    public string Email { get; set; }

    /// <inheritdoc />
    public string City { get; set; }

    /// <inheritdoc />
    public string Address { get; set; }

    /// <inheritdoc />
    public string Country { get; set; }

    /// <inheritdoc />
    public int PhoneNumber { get; set; }

    /// <inheritdoc />
    public string AreaCode { get; set; }

    /// <inheritdoc />
    public int PostalCode { get; set; }

    /// <inheritdoc />
    public DateTime DateOfBirth { get; set; }

    public string ProfileDescription { get; set; }
}
    
