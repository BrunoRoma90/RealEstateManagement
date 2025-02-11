using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.Repositories;

internal class VisitRepository : Repository<Visit, int>, IVisitRepository
{
    public VisitRepository(ApplicationDbContext context) : base(context)
    {

    }

    public void AddNotes(int visitId, string notes)
    {
        throw new NotImplementedException();
    }

    public void AddVisitToAgent(Visit visit)
    {
        throw new NotImplementedException();
    }

    public void AddVisitToClient(Visit visit)
    {
        throw new NotImplementedException();
    }

    public List<Visit> GetAllVisitByAngentId(int agentId)
    {
        throw new NotImplementedException();
    }

    public List<Visit> GetAllVisitByClientId(int clientId)
    {
        throw new NotImplementedException();
    }

    public List<Visit> GetAllVisitByPropertyId(int propertyId)
    {
        throw new NotImplementedException();
    }

    public Visit GetVisitByAgentId(int agentId)
    {
        throw new NotImplementedException();
    }

    public Visit GetVisitByClientId(int clientId)
    {
        throw new NotImplementedException();
    }

    public Visit GetVisitByProperty(int propertyId)
    {
        throw new NotImplementedException();
    }
}
