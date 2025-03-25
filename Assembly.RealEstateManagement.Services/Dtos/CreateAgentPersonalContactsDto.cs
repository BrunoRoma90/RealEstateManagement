namespace Assembly.RealEstateManagement.Services.Dtos;

public class CreateAgentPersonalContactsDto 
{
    public string ContactType { get; set; }
    public string Value { get; set; }

    public AgentDto Agent { get; set; }
}
