using Assembly.RealEstateManagement.Services.Dtos.Common;

namespace Assembly.RealEstateManagement.Services.Dtos.AdministrativeUsers;

public class AdministrativeUserDto
{
    public int Id { get; set; }
    public int EmployeeNumber { get; set; }
    public int AdministrativeNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Email { get; set; }
    public AddressDto Address { get; set; }
    public bool IsAdmin { get; set; }

}
