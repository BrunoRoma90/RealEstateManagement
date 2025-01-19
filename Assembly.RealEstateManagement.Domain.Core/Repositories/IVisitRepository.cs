
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Domain.Core.Repositories;

public interface IVisitRepository : IRepository<Visit, int>
{
    public Client GetVisitByClientId(int clientId);

    public Property GetVisitByProperty(int propertyId);

    public Agent GetPorpertyByAgentId(int AngentId);

    public List<Visit> GetAllVisitByClientId(int clientId);
    public List<Visit> GetAllVisitByPropertyId(int propertyId);
    public List<Visit> GetAllVisitByAngentId(int angentId);


}
