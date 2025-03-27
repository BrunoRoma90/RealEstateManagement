using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Domain.Core.Repositories;

public interface IAgentAllContactRepository : IRepository<AgentAllContact, int> 
{
    public List<AgentAllContact> GetAgentContacts(int agentId);
    public List<AgentAllContact> GetAllAgentAllContactWithAgent();
}
