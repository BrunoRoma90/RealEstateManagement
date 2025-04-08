using Assembly.RealEstateManagement.Services.Dtos.Common;
using Assembly.RealEstateManagement.Services.Dtos.Manager;

namespace Assembly.RealEstateManagement.Services.Dtos.Agent;

public class UpdateAgentDto
{
    public int Id { get; set; }
    public int EmployeeNumber { get; set; }
    public int AgentNumber { get; set; }
    public string FirstName { get; set; }
    public string[] MiddleNames { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

    public ManagerDto Manager { get; set; }
    public AddressDto Address { get; set; }
}
