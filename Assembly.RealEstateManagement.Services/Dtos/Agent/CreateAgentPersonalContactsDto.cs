namespace Assembly.RealEstateManagement.Services.Dtos.Agent;

public class CreateAgentPersonalContactsDto
{
    public string ContactType { get; set; }
    public string Value { get; set; }

    public AgentDto Agent { get; set; }
}
