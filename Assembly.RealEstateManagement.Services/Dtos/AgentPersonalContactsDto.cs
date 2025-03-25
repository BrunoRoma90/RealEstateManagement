namespace Assembly.RealEstateManagement.Services.Dtos;

public class ManagerPersonalContactDto
{
    public string ContactType { get; set; }
    public string Value { get; set; }

    public AgentDto Agent { get; set; }
}
