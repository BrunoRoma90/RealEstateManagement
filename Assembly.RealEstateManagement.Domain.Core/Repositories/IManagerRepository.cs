
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Domain.Core.Repositories;

public interface IManagerRepository : IRepository<Manager, int>
{
    public List<Agent> GetAgents();

    public Agent GetAgent(int id);

    public List<Agent> GetAgentsByManagerId(int managerId);


}
