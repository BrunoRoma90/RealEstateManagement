using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Domain.Core.Repositories;

public interface IAgentRepository : IRepository<Agent, int>
{

    List<Property> GetPropertiesByAgentId(int agentId);
    List<Visit> GetVisitsByAgentId(int agentId);



}
