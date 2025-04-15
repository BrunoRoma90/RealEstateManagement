using Assembly.RealEstateManagement.Services.Dtos.Agent;

namespace Assembly.RealEstateManagement.Services.Interfaces;

public interface IAgentPersonalContactsServices 
{
    IEnumerable<AgentPersonalContactsDto> GetAgentPersonalsContacts();

    public List<AgentPersonalContactsDto> GetPersonalContactsByAgentId(int agentId);
    AgentPersonalContactsDto Add(CreateAgentPersonalContactsDto agentPersonalContacts);
    AgentPersonalContactsDto Update(UpdateAgentPersonalContactsDto agentPersonalContacts);
}

