using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Services.Interfaces;

internal interface IAdministrativeUserService
{
    public Visit GetVisitByClientId(int clientId); 

    public List<Visit> GetAllVisitsByClientId(int clientId);   
}
