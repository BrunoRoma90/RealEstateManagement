namespace Assembly.RealEstateManagement.Services.Dtos;

public class AgentDto
{
    public int EmployeeNumber { get; set; }
    public int AgentNumber { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string Email { get; set; }
    public AddressDto Address { get; set; }

    public ManagerDto Manager { get; set; }

}
