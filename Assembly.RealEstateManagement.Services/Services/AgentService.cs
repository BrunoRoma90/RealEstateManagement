
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

    public Agent GetAgentById(int id)
    {
        var agent = _agentRepository.GetById(id);
        if (agent == null)
        {
            throw new KeyNotFoundException($"Agent with ID {id} not found.");
        }
        return agent;
    }

    public List<Agent> GetAgents()
    {
        return _agentRepository.GetAll();
    }

    public Agent Add(Agent agent) 
    {
        return _agentRepository.Add(agent);

    }

    public Visit AddVisit(Agent agent, Visit visit)
    {
   
        if (agent == null)
        {
            throw new KeyNotFoundException($"Agent not found.");
        }

        agent.AddVisit(visit);
        //_agentRepository.Update(agent);

        return visit;



    }

    public List<Visit> GetAllVisits(int agentId)
    {
        if (agentId <= 0)
        {
            throw new ArgumentException("Agent ID must be greater than zero.", nameof(agentId));
        }

        
        return _agentRepository.GetVisitsByAgentId(agentId);
    }

    
}
