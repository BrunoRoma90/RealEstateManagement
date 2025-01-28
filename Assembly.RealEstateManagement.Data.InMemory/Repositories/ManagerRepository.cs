
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.InMemory.Repositories;

internal class ManagerRepository : IManagerRepository
{
    private readonly Database _db;
    private readonly IAgentRepository _agentRepository;
    private readonly IVisitRepository _visitRepository;


    public ManagerRepository(Database database, IAgentRepository agentRepository)
    {
        _db = database;
        _agentRepository = agentRepository;
    }
    public Manager Add(Manager manager)
    {
        _db.Managers.Add(manager);
        return manager;
    }
    public List<Manager> GetAll()
    {
        var allManagers = new List<Manager>();
        foreach (var manager in _db.Managers)
        {
            allManagers.Add(manager);
        }
        return allManagers;
    }

    public Manager GetById(int id)
    {
        foreach (var manager in _db.Managers)
        {
            if (manager.Id == id)
            {
                return manager;

            }
        }
        throw new KeyNotFoundException($"Admin with ID {id} was not found.");
    }

    public Manager Update(Manager manager)
    {
        var allmanagers = _db.Managers.ToList();
        foreach (var existingManager in allmanagers)
        {
            if (existingManager.Id == manager.Id)
            {
                existingManager.UpdateManager(manager);
                return existingManager;
            }
        }
        throw new KeyNotFoundException($"Admin was not found.");
    }
    public Manager Delete(Manager manager)
    {
        var allManagers = _db.Managers.ToList();
        foreach (var existingManager in allManagers)
        {
            if (existingManager.Id == manager.Id)
            {
                _db.Managers.Remove(existingManager);
            }
        }
        throw new KeyNotFoundException($"Admin was not found.");
    }

    public Manager Delete(int id)
    {
        var allManagers = _db.Managers.ToList();
        foreach (var existingManager in allManagers)
        {
            if (existingManager.Id == id)
            {
                _db.Managers.Remove(existingManager);

            }
        }
        throw new KeyNotFoundException($"Manager with ID {id} was not found.");
    }



    public Agent GetAgent(int id)
    {
        return _agentRepository.GetById(id);
    }

    public List<Agent> GetAgents()
    {
        return _agentRepository.GetAll();
    }

    public List<Agent> GetAgentsByManagerId(int managerId)
    {
        return _agentRepository.GetAgentsByManagerId(managerId);
    }

    public void TransferProperty(int managerId, int fromAgentId, int toAgentId, Property property)
    {
        if (property == null)
        {
            throw new ArgumentNullException(nameof(property), "Property cannot be null.");
        }

        var manager = GetById(managerId);
        if (manager == null)
        {
            throw new KeyNotFoundException($"Manager with ID {managerId} not found.");
        }

        var fromAgent = _agentRepository.GetById(fromAgentId);
        if (fromAgent == null)
        {
            throw new KeyNotFoundException($"From Agent with ID {fromAgentId} not found.");
        }

        var toAgent = _agentRepository.GetById(toAgentId);
        if (toAgent == null)
        {
            throw new KeyNotFoundException($"To Agent with ID {toAgentId} not found.");
        }

        manager.ReassignSingleProperty(property, fromAgent, toAgent);


    }

    public void TransferAllProperties(int managerId, int fromAgentId, int toAgentId)
    {
        var manager = GetById(managerId);
        if (manager == null)
        {
            throw new KeyNotFoundException($"Manager with ID {managerId} not found.");
        }

        var fromAgent = _agentRepository.GetById(fromAgentId);
        if (fromAgent == null)
        {
            throw new KeyNotFoundException($"From Agent with ID {fromAgentId} not found.");
        }

        var toAgent = _agentRepository.GetById(toAgentId);
        if (toAgent == null)
        {
            throw new KeyNotFoundException($"To Agent with ID {toAgentId} not found.");
        }

        manager.ReassignAllProperties(fromAgent, toAgent);
    }


    public List<Visit> GetAgentCalendar(int agentId)
    {
        var agent = _agentRepository.GetById(agentId); 
        if (agent == null)
        {
            throw new KeyNotFoundException($"Agent with ID {agentId} was not found.");
        }
        return agent.Visits;
    }

    public void CreateAppointment(int agentId, Visit visit)
    {
        var agent = _agentRepository.GetById(agentId); 
        if (agent == null)
        {
            throw new KeyNotFoundException($"Agent with ID {agentId} was not found.");
        }
        if (visit == null)
        {
            throw new ArgumentNullException(nameof(visit), "Visit cannot be null.");
        }
        agent.AddVisit(visit); 
    }


    public void AddAgent(int managerId, Agent agent)
    {
        if (agent == null)
        {
            throw new ArgumentNullException(nameof(agent), "Agent cannot be null.");
        }

        var manager = GetById(managerId);
        if (manager == null)
        {
            throw new KeyNotFoundException($"Manager with ID {managerId} not found.");
        }

        
        manager.AddAgent(agent);
    }

    public void RemoveAgent(int managerId, Agent agent)
    {
        if (agent == null)
        {
            throw new ArgumentNullException(nameof(agent), "Agent cannot be null.");
        }

        var manager = GetById(managerId);
        if (manager == null)
        {
            throw new KeyNotFoundException($"Manager with ID {managerId} not found.");
        }

        
        manager.RemoveAgent(agent);
    }

    public List<Agent> GetAllManagedAgents(int managerId)
    {
        var manager = GetById(managerId);
        if (manager == null)
        {
            throw new KeyNotFoundException($"Manager with ID {managerId} not found.");
        }

      
        return manager.GetAllManagedAgents();
    }


    public void AddNotes(int visitId, string notes)
    {
        _visitRepository.AddNotes(visitId, notes);
    }
}
