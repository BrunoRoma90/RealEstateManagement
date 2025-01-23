using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Interfaces;
using Assembly.RealEstateManagement.Domain.Core.Repositories;

namespace Assembly.RealEstateManagement.Services.Services;

internal class AdministrativeUserService : IAdministrativeUserService
{
    private IAdministrativeUsersRepository _administrativesUserRepository;

    public AdministrativeUserService(IAdministrativeUsersRepository administrativesUserRepository)
    {
        _administrativesUserRepository = administrativesUserRepository;
    }

    public List<Visit> GetAllVisitsByClientId(int clientId)
    {
        return _administrativesUserRepository.GetVisitsByClientId(clientId);
    }

    public Visit GetVisitByClientId(int clientId)
    {
        throw new NotImplementedException();
    }
}
