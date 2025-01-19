
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Domain.Core.Repositories;

public interface IVisitRepository : IRepository<Visit, int>
{
    public Visit GetVisitByClientId(int clientId);

    public Visit GetVisitByProperty(int propertyId);

    public Visit GetVisitByAgentId(int agentId);

    public List<Visit> GetAllVisitByClientId(int clientId);
    public List<Visit> GetAllVisitByPropertyId(int propertyId);
    public List<Visit> GetAllVisitByAngentId(int agentId);


}
