namespace Assembly.RealEstateManagement.Services.Dtos.Agent;

public class AgentPersonalContactsDto
{
    public string ContactType { get; set; }
    public string Value { get; set; }

    public AgentDto Agent { get; set; }
}
