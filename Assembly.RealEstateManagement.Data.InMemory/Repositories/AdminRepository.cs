
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.InMemory.Repositories;

internal class AdminRepository : IAdminRepository
{
    private readonly Database _db;
    private readonly AgentRepository _agentRepository;
    

    public AdminRepository(Database database, AgentRepository agentRepository)
    {
        _db = database;
        _agentRepository = agentRepository;
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

    public List<Agent> GetAgents()
    {
        return _agentRepository.GetAll();

    }
    public List<Manager> GetManagers()
    {
       var allManagers = new List<Manager>();
        foreach (var manager in _db.Managers)
        {
            allManagers.Add(manager);
        }
        return allManagers;
    }
    public List<AdministrativeUsers> GetAdministrativeUsers()
    {
        var allAdministrativeUsers = new List<AdministrativeUsers>();
        foreach (var administrativeUser in _db.AdministrativeUsers)
        {
            allAdministrativeUsers.Add(administrativeUser);
        }
        return allAdministrativeUsers;
    }

    public List<Client> GetClients()
    {
        var allClients = new List<Client>();
        foreach (var client in _db.Clients)
        {
            allClients.Add(client);
            
        }
        return allClients;
    }

    
    
    public Agent GetAgent(int id)
    {
        
        return _agentRepository.GetById(id);
    }

    public Manager GetManager(int id)
    {
        foreach (var manager in _db.Managers)
        {
            if (manager.Id == id)
            {
                return manager;
            }
        }
        return null;
    }

    public AdministrativeUsers GetAdministrativeUser(int id)
    {
        foreach (var administrativeUsers in _db.AdministrativeUsers)
        {
            if (administrativeUsers.Id == id)
            {
                return administrativeUsers;
            }
        }
        return null;
    }

    public Client GetClient(int id)
    {
        
        foreach (var client in _db.Clients)
        {
            if (client.Id == id)
            {
                return client;
            }
        }
        return null;
    }
}
