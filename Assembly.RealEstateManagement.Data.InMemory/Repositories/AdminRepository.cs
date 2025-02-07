
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.InMemory.Repositories;

internal class AdminRepository : IAdminRepository
{
    private readonly Database _db;
    private readonly IAgentRepository _agentRepository;
    private readonly IManagerRepository _managerRepository;
    private readonly IAdministrativeUsersRepository _administrativeUserRepository;
    private readonly IClientRepository _clientRepository;



    public AdminRepository(Database database, IAgentRepository agentRepository, IManagerRepository managerRepository,
        IAdministrativeUsersRepository administrativeUserRepository, IClientRepository clientRepository)
    {
        _db = database;
        _agentRepository = agentRepository;
        _managerRepository = managerRepository;
        _administrativeUserRepository = administrativeUserRepository;
        _clientRepository = clientRepository;
    }


    public Admin Add(Admin admin)
    {
        _db.Admins.Add(admin);
        return admin;
    }
    public Admin Delete(Admin admin)
    {
        var admins = _db.Admins.ToList();
        foreach (var existingAdmin in admins)
        {
            if (existingAdmin.Id == admin.Id)
            {
                _db.Admins.Remove(existingAdmin);
            }
        }
        throw new KeyNotFoundException($"Admin was not found.");
    }
    public Admin Delete(int adminId)
    {
        var admins = _db.Admins.ToList();
        foreach (var admin in admins)
        {
            if (admin.Id == adminId)
            {
                _db.Admins.Remove(admin);

            }
        }
        throw new KeyNotFoundException($"Admin with ID {adminId} was not found.");
    }
    public List<Admin> GetAll()
    {
        var allAdmins = new List<Admin>();
        foreach (var admin in _db.Admins)
        {
            allAdmins.Add(admin);
        }
        return allAdmins;
    }
    public Admin GetById(int id)
    {
        foreach (var admin in _db.Admins)
        {
            if (admin.Id == id)
            {
                return admin;

            }
        }
        throw new KeyNotFoundException($"Admin with ID {id} was not found.");
    }
    public Admin Update(Admin admin)
    {
        var admins = _db.Admins.ToList();
        foreach (var existingAdmin in admins)
        {
            if (existingAdmin.Id == admin.Id)
            {
                existingAdmin.UpdateAdmin(admin);
                return existingAdmin;
            }
        }
        throw new KeyNotFoundException($"Admin was not found.");
    }


    //For Agents
    public List<Agent> GetAgents()
    {
        return _agentRepository.GetAll();

    }
    public Agent GetAgent(int id)
    {

        return _agentRepository.GetById(id);
    }
    public Agent CreateAgent(Agent agent)
    {
        return _agentRepository.Add(agent);
    }
    public Agent UpdateAgent(Agent agent)
    {
        return _agentRepository.Update(agent);
    }
    public Agent DeleteAgent(Agent agent)
    {
        return _agentRepository.Delete(agent);
    }
    public Agent DeleteAgent(int agentId)
    {
        return _agentRepository.Delete(agentId);
    }




    //For Managers
    public List<Manager> GetManagers()
    {
        return _managerRepository.GetAll();
    }
    public Manager GetManager(int id)
    {
        return _managerRepository.GetById(id);
    }
    public Manager CreateManager(Manager manager)
    {
        return _managerRepository.Add(manager);
    }
    public Manager UpdateManager(Manager manager)
    {
        return _managerRepository.Update(manager);
    }
    public Manager DeleteManager(Manager manager)
    {
        return _managerRepository.Delete(manager);
    }
    public Manager DeleteManager(int managerId)
    {
        return _managerRepository.Delete(managerId);
    }


    //For AdministrativeUser
    public List<AdministrativeUser> GetAdministrativeUsers()
    {
        return _administrativeUserRepository.GetAll();
    }
    public AdministrativeUser GetAdministrativeUser(int id)
    {
        return _administrativeUserRepository.GetById(id);
    }
    public AdministrativeUser CreateAdministrativeUser(AdministrativeUser administrativeUser)
    {
        return _administrativeUserRepository.Add(administrativeUser);
    }

    public AdministrativeUser UpdateAdministrativeUser(AdministrativeUser administrativeUser)
    {
        return _administrativeUserRepository.Update(administrativeUser);
    }
    public AdministrativeUser DeleteAdministrativeUser(AdministrativeUser administrativeUser)
    {
        return _administrativeUserRepository.Delete(administrativeUser);
    }

    public AdministrativeUser DeleteAdministrativeUser(int administrativeUserId)
    {
        return _administrativeUserRepository.Delete(administrativeUserId);
    }

    //For Clients
    public List<Client> GetClients()
    {
        return _clientRepository.GetAll();
    }
    public Client GetClient(int id)
    {
        return _clientRepository.GetById(id);
    }
    public Client CreateClient(Client client)
    {
        return _clientRepository.Add(client);
    }
    public Client UpdateClient(Client client)
    {
        return _clientRepository.Update(client);
    }

    public Client DeleteClient(Client client)
    {
        return _clientRepository.Delete(client);
    }
    public Client DeleteClient(int clientId)
    {
        return _clientRepository.Delete(clientId);
    }

    
}

   
