namespace Assembly.RealEstateManagement.Services.Dtos;

public class CreateAdministrativeUserDto
{
    public int EmployeeNumber { get; set; }
    public int AdministrativeNumber { get; set; }
    public string FirstName { get; set; }
    public string[] MiddleNames { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public AddressDto Address { get; set; }

    public bool IsAdmin { get; set; }
}
