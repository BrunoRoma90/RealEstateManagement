using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Interfaces;


namespace Assembly.RealEstateManagement.Services.Services;

public class AdminService : IAdminService
{
    private IAdminRepository _adminRepository;

    public AdminService(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public Admin CreateAdmin(Admin admin)
    {
        return _adminRepository.Add(admin);
    }
    public Admin UpdateAdmin(Admin admin)
    {
        return _adminRepository.Update(admin);
    }
    public void DeleteAdmin(int adminId)
    {
        var admin = _adminRepository.Delete(adminId);

    }
    public void DeleteAdmin(Admin admin)
    {
        _adminRepository.Delete(admin);
    }

    //For AdministrativeUsers
    public AdministrativeUser CreateAdministrativeUser(AdministrativeUser administrativeUser)
    {
        return _adminRepository.CreateAdministrativeUser(administrativeUser);
    }
    public List<AdministrativeUser> GetAdministrativeUsers()
    {
        return _adminRepository.GetAdministrativeUsers();
    }
    public AdministrativeUser GetAdministrativeUser(int administrativeUserId)
    {
        return _adminRepository.GetAdministrativeUser(administrativeUserId);
    }
    public AdministrativeUser UpdateAdministrativeUser(AdministrativeUser administrativeUser)
    {
        return _adminRepository.UpdateAdministrativeUser(administrativeUser);
    }
    public AdministrativeUser DeleteAdministrativeUser(AdministrativeUser administrativeUser)
    {
        return _adminRepository.DeleteAdministrativeUser(administrativeUser);
    }
    public AdministrativeUser DeleteAdministrativeUser(int administrativeUserId)
    {
        return _adminRepository.DeleteAdministrativeUser(administrativeUserId);
    }


    //For Manager
    public Manager CreateManager(Manager manager)
    {
        return _adminRepository.CreateManager(manager);
    }
    public List<Manager> GetManagers()
    {
        return _adminRepository.GetManagers();
    }
    public Manager UpdateManager(Manager manager)
    {
        return _adminRepository.UpdateManager(manager);
    }
    public Manager DeleteManager(Manager manager)
    {
       return _adminRepository.DeleteManager(manager);
    }
    public Manager DeleteManager(int managerId)
    {
        return _adminRepository.DeleteManager(managerId);
    }
    public Manager GetManager(int managerId)
    {
       return _adminRepository.GetManager(managerId);
    }



    //For Agents
    public Agent CreateAgent(Agent agent)
    {
        return _adminRepository.CreateAgent(agent);
    }
    public List<Agent> GetAgents()
    {
        return _adminRepository.GetAgents();
    }
    public Agent UpdateAgent(Agent agent)
    {
        return _adminRepository.UpdateAgent(agent);
    }
    public Agent DeleteAgent(Agent agent)
    {
        return _adminRepository.DeleteAgent(agent);
    }
    public Agent DeleteAgent(int agentId)
    {
       return _adminRepository.DeleteAgent(agentId);
    }
    public Agent GetAgent(int agentId)
    {
        return _adminRepository.GetAgent(agentId);
    }


    // For Clients
    public Client CreateClient(Client client)
    {
        return _adminRepository.CreateClient(client);
    }
    public Client UpdateClient(Client client)
    {
        return _adminRepository.UpdateClient(client);
    }
    public Client DeleteClient(Client client)
    {
        return _adminRepository.DeleteClient(client);
    }
    public Client DeleteClient(int clientId)
    {
        return _adminRepository.DeleteClient(clientId);
    }
    public Client GetClient(int clientId)
    {
        return _adminRepository.GetClient(clientId);
    }


}

  
