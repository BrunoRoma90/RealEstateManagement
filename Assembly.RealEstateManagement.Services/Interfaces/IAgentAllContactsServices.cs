using Assembly.RealEstateManagement.Services.Dtos.Agent;
using Assembly.RealEstateManagement.Services.Dtos.Manager;

namespace Assembly.RealEstateManagement.Services.Interfaces;

public interface IAgentAllContactsServices
{
    IEnumerable<AgentAllContactsDto> GetAgentAllContacts();

    public List<AgentAllContactsDto> GetContactsByAgentId(int agentId);
    AgentAllContactsDto Add(CreateAgentAllContactsDto agentAllContacts);
}
