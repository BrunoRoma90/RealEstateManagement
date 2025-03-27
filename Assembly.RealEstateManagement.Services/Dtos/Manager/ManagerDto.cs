using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Dtos.Common;

namespace Assembly.RealEstateManagement.Services.Dtos.Manager;

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
