using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Services.Dtos;

public class ManagerDto
{    
    public int Id { get; set; } 
    public int EmployeeNumber { get; set; }
    public int ManagerNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Email { get; set; }
    public AddressDto Address { get; set; }
    
}
