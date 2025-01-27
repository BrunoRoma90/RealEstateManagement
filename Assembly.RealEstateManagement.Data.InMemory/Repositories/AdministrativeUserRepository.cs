
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.InMemory.Repositories;

internal class AdministrativeUserRepository : IAdministrativeUsersRepository
{
    private readonly  Database _db;
    private readonly IAgentRepository _agentRepository;
    private readonly IManagerRepository _managerRepository;
    private readonly IVisitRepository _visitRepository;
    private readonly IClientRepository _clientRepository;
    public AdministrativeUserRepository(Database database, IAgentRepository agentRepository, IManagerRepository managerRepository,
        IVisitRepository visitRepository, IClientRepository clientRepository)
    {
        _db = database;
        _agentRepository = agentRepository;
        _managerRepository = managerRepository;
        _visitRepository = visitRepository;
        _clientRepository = clientRepository;

    }

    public AdministrativeUsers Add(AdministrativeUsers administrativeUser)
    {
        _db.AdministrativeUsers.Add(administrativeUser);
        return administrativeUser;
    }

    public List<AdministrativeUsers> GetAll()
    {
        var allAdministrativeUsers = new List<AdministrativeUsers>();
        foreach (var administrativeUser in _db.AdministrativeUsers)
        {
            allAdministrativeUsers.Add(administrativeUser);
        }
        return allAdministrativeUsers;
    }

    public AdministrativeUsers GetById(int id)
    {
        foreach (var administrativeUser in _db.AdministrativeUsers)
        {
            if (administrativeUser.Id == id)
            {
                return administrativeUser;

            }
        }
        throw new KeyNotFoundException($"Admin with ID {id} was not found.");
    }

    public AdministrativeUsers Delete(AdministrativeUsers administrativeUser)
    {
        var administrativeUsers = _db.AdministrativeUsers.ToList();
        foreach (var existingAdministrativeUser in administrativeUsers)
        { 
            if (existingAdministrativeUser.Id == administrativeUser.Id) 
            { 
                _db.AdministrativeUsers.Remove(existingAdministrativeUser);
            }
        }
        throw new KeyNotFoundException($"Administrative was not found.");
    }

    public AdministrativeUsers Delete(int id)
    {
        var administrativeUsers = _db.AdministrativeUsers.ToList();
        foreach (var administrativeUser in administrativeUsers)
        {
            if (administrativeUser.Id == id)
            {
                _db.AdministrativeUsers.Remove(administrativeUser);

            }
        }
        throw new KeyNotFoundException($"Admin with ID {id} was not found.");
    }

    public AdministrativeUsers Update(AdministrativeUsers administrativeUser)
    {
        var administrativeUsers = _db.AdministrativeUsers.ToList();
        foreach (var existingAdmin in administrativeUsers)
        {
            if (existingAdmin.Id == administrativeUser.Id)
            {
                existingAdmin.UpdateAdministrativeUser(administrativeUser.Name, administrativeUser.Account, administrativeUser.Contact, administrativeUser.Address,
                    administrativeUser.EmployeeNumber, administrativeUser.AdministrativeNumber, administrativeUser.Clients, administrativeUser.Employees);

                return existingAdmin;
            }
        }
        throw new KeyNotFoundException($"(AdministrativeUser was not found.");
    }


    public Agent GetAgent(int id)
    {
        return _agentRepository.GetById(id);
    }

    public List<Agent> GetAgents()
    {
        return _agentRepository.GetAll();
    }

    public Client GetClient(int id)
    {
        return _clientRepository.GetById(id);
    }

    public List<Client> GetClients()
    {
        return _clientRepository.GetAll();
    }

    public Manager GetManager(int id)
    {
        return _managerRepository.GetById(id);
    }

    public List<Manager> GetManagers()
    {
        return _managerRepository.GetAll();
    }

    public List<Visit> GetVisits()
    {
        return _visitRepository.GetAll();
    }


    public List<Visit> GetVisitsByClientId(int clientId)
    {
        return _visitRepository.GetAllVisitByClientId(clientId);
    }

    public List<Visit> GetVisitsByAgentId(int agentId)
    {
        return _visitRepository.GetAllVisitByAngentId(agentId);
    }

    public Visit GetVisitByClientId(int clientId)
    {
        return _visitRepository.GetVisitByClientId(clientId);
    }
    public Visit UpdateVisit(Visit visit)
    {
        return _visitRepository.Update(visit);
    }
    public Visit GetVisitByAgentId(int agentId)
    {
        return _visitRepository.GetVisitByAgentId(agentId);
    }
    public void AddVisit(Visit visit)
    {
        _visitRepository.Add(visit);
    }

    public void AddVisitToAgent(Visit visit)
    {
        _visitRepository.AddVisitToAgent(visit);
    }

    public void AddVisitToClient(Visit visit)
    {
        _visitRepository.AddVisitToClient(visit);
    }

    public void AddNotes(int visitId, string notes)
    {
        _visitRepository.AddNotes(visitId, notes);
    }

    public Client CreateClient(Client client)
    {
        return _clientRepository.Add(client);
    }
}
