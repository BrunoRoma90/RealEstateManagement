using Assembly.RealEstateManagement.Domain.Model;


namespace Assembly.RealEstateManagement.Services.Interfaces;

public interface IAdminService
{
    public Admin CreateAdmin(Admin admin);
    public Admin UpdateAdmin(Admin admin);
    public void DeleteAdmin(Admin admin);
    public void DeleteAdmin(int adminId);
    
    
    
    
    List<AdministrativeUser> GetAdministrativeUsers();
    public AdministrativeUser GetAdministrativeUser(int administrativeUserId);
    public AdministrativeUser CreateAdministrativeUser(AdministrativeUser administrativeUser);

    public AdministrativeUser UpdateAdministrativeUser(AdministrativeUser administrativeUser);

    public AdministrativeUser DeleteAdministrativeUser(AdministrativeUser administrativeUser);
    
    public AdministrativeUser DeleteAdministrativeUser(int administrativeUserId);




    //
    List<Agent> GetAgents();
    public Agent CreateAgent(Agent agent);
    public Agent UpdateAgent(Agent agent);
    public Agent DeleteAgent(Agent agent);
    public Agent DeleteAgent(int agentId);
    public Agent GetAgent(int agentId);

    //For Managers
    List<Manager> GetManagers();
    public Manager CreateManager(Manager manager);
    public Manager UpdateManager(Manager manager);
    public Manager DeleteManager(Manager manager);
    public Manager DeleteManager(int managerId);
    public Manager GetManager(int managerId);
  
    
    //For Clients
    public Client CreateClient(Client client);
    public Client UpdateClient(Client client);
    public Client DeleteClient(Client client);
    public Client DeleteClient(int clientId);
    public Client GetClient(int clientId);
    



}
