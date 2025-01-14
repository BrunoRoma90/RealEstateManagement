
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Interfaces;

namespace Assembly.RealEstateManagement.Services.Services;

public class AgentService : IAgentService
{
    private IAgentRepository _agentRepository;

    public AgentService(IAgentRepository agentRepository)
    {
        _agentRepository = agentRepository;
    }

    public List<Agent> GetAgents()
    {
        return _agentRepository.GetAll();
    }

    public Agent Add(Agent agent) 
    {
        return _agentRepository.Add(agent);

    }
}
