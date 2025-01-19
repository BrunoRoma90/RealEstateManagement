using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Domain.Core.Repositories;

public interface IAdministrativeUsersRepository : IRepository<AdministrativeUsers , int> 
{
    public List<Agent> GetAgents();
    public List<Manager> GetManagers();

    public List<Visit> GetVisits();

    public List<Client> GetClients();

    public Agent GetAgent(int id);

    public Manager GetManager(int id);

    public Client GetClient(int id);

}
