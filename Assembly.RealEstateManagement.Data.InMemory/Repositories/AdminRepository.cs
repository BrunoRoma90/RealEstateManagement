
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.InMemory.Repositories;

internal class AdminRepository : IAdminRepository
{
    private readonly Database _db;

    public AdminRepository(Database database)
    {
        _db = database;
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
        return null;
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
        return null;
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
        return null;
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
        return null;
    }

    public List<Agent> GetAgents()
    {
        var allAgents = new List<Agent>();
        foreach (var agent in _db.Agents)
        {
            allAgents.Add(agent);
        }
        return allAgents;

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
}
