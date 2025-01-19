
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.InMemory.Repositories;

internal class AdminRepository : IAdminRepository
{
    private readonly Database _db;
    private readonly AgentRepository _agentRepository;
    private readonly ManagerRepository _managerRepository;
    private readonly AdministrativeUserRepository _administrativeUserRepository;
    private readonly ClientRepository _clientRepository;
   
    

    public AdminRepository(Database database, AgentRepository agentRepository, ManagerRepository managerRepository,
        AdministrativeUserRepository administrativeUserRepository, ClientRepository clientRepository)
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

    public List<Agent> GetAgents()
    {
        return _agentRepository.GetAll();

    }
    public List<Manager> GetManagers()
    {
       return _managerRepository.GetAll();
    }
    public List<AdministrativeUsers> GetAdministrativeUsers()
    {
        return _administrativeUserRepository.GetAll();
    }

    public List<Client> GetClients()
    {
        return _clientRepository.GetAll();
    }
    
    public Agent GetAgent(int id)
    {
        
        return _agentRepository.GetById(id);
    }

    public Manager GetManager(int id)
    {
        return _managerRepository.GetById(id);
    }

    public AdministrativeUsers GetAdministrativeUser(int id)
    {
        return _administrativeUserRepository.GetById(id);
    }

    public Client GetClient(int id)
    {
        return _clientRepository.GetById(id);
    }
}
