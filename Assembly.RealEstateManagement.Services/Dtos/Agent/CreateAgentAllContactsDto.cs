namespace Assembly.RealEstateManagement.Services.Dtos.Agent;

public class CreateAgentAllContactsDto
{
    public string FirstName { get; set; }

    public string[] MiddleNames { get; set; }
    public string LastName { get; set; }

    public string ContactType { get; set; }
    public string Value { get; set; }

    public AgentDto Agent { get; set; }
}
