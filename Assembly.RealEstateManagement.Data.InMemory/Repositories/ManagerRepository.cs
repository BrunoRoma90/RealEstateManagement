
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.InMemory.Repositories;

internal class ManagerRepository : IManagerRepository
{
    private readonly Database _db;
    private readonly IAgentRepository _agentRepository;


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
        var agentsByManager = new List<Agent>();
        foreach (var agent in _db.Agents)
        {
            if (agent.Manager.Id == managerId)
            {
                agentsByManager.Add(agent);
            }
        }
        return agentsByManager;
    }

   
}
