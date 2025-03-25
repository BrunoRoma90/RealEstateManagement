namespace Assembly.RealEstateManagement.Services.Dtos;

public class CreateAgentDto
{
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
