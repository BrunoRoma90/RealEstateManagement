using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Domain.Core.Repositories;

public interface IAgentPersonalContactRepository : IRepository<AgentPersonalContact, int> 
{
    public List<AgentPersonalContact> GetMyPersonalContacts(int agentId);

    public List<AgentPersonalContact> GetAllAgentPersonalContactWithAgent();
}
