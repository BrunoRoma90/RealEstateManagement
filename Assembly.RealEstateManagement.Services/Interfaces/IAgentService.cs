using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Services.Interfaces;

public interface IAgentService
{
    List<Agent> GetAgents();

    Agent Add(Agent agent);
}
