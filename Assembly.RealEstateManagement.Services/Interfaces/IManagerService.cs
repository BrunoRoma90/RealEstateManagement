using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Services.Interfaces;

public interface IManagerService
{

    public Agent GetAgent(int id);


    public List<Agent> GetAgents();


    public List<Agent> GetAgentsByManagerId(int managerId);


}
