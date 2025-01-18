using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Domain.Core.Repositories;

public interface IAdminRepository : IRepository<Admin, int>
{
    public List<Agent> GetAgents();
    public List<Manager> GetManagers();
    public List<AdministrativeUsers> GetAdministrativeUsers();

}
