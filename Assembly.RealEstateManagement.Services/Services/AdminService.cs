using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;


namespace Assembly.RealEstateManagement.Services.Services;

public class AdminService : IAdminService
{
    private IAdminRepository _adminRepository;

    public AdminService(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public List<AdministrativeUsers> GetAdministrativeUsers()
    {
        return _adminRepository.GetAdministrativeUsers();
    }

    public List<Agent> GetAgents()
    {
        return _adminRepository.GetAgents();
    }

    public List<Manager> GetManagers()
    {
        return _adminRepository.GetManagers();
    }
}

public interface IAdminService
{
    List<Agent> GetAgents();
    List<Manager> GetManagers();
    List<AdministrativeUsers> GetAdministrativeUsers();
}
