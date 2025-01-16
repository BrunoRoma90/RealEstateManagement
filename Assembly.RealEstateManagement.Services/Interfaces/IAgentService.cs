using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Services.Interfaces;

public interface IAgentService
{
    List<Agent> GetAgents();

    public Agent GetAgentById(int id);
    Agent Add(Agent agent);

    Visit AddVisit(Agent agent , Visit visit);

    List<Visit> GetAllVisits(int agentId);
}
