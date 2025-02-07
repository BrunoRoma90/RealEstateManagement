using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Domain.Core.Repositories;

public interface IAdminRepository : IRepository<Admin, int>
{
    
    public List<Manager> GetManagers();
    public Manager GetManager(int id);
    public Manager CreateManager(Manager manager);
    public Manager UpdateManager(Manager manager);
    public Manager DeleteManager(Manager manager);
    public Manager DeleteManager(int managerId);


    //For Administrative Users
    public List<AdministrativeUser> GetAdministrativeUsers();
    public AdministrativeUser GetAdministrativeUser(int id);
    public AdministrativeUser CreateAdministrativeUser(AdministrativeUser administrativeUser);

    public AdministrativeUser UpdateAdministrativeUser(AdministrativeUser administrativeUser);
    public AdministrativeUser DeleteAdministrativeUser(AdministrativeUser administrativeUser);
    public AdministrativeUser DeleteAdministrativeUser(int administrativeUserId);


    //For Agents
    public Agent CreateAgent(Agent agent);
    public List<Agent> GetAgents();
    public Agent GetAgent(int id);
    public Agent UpdateAgent(Agent agent);
    public Agent DeleteAgent(Agent agent);
    public Agent DeleteAgent(int agentId);

   

    

    //For Clients
    public Client GetClient(int id);
    public List<Client> GetClients();
    public Client CreateClient(Client client);
    public Client UpdateClient(Client client);
    public Client DeleteClient(Client client);
    public Client DeleteClient(int clientId);



}
