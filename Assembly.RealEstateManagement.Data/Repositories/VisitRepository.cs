using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;


namespace Assembly.RealEstateManagement.Data.Repositories;

internal class VisitRepository : Repository<Visit, int>, IVisitRepository
{
    public VisitRepository(ApplicationDbContext context) : base(context)
    {

    }

    //public void AddNotes(int visitId, string notes)
    //{
    //    throw new NotImplementedException();
    //}

    //public void AddVisitToAgent(Visit visit)
    //{
    //    throw new NotImplementedException();
    //}

    //public void AddVisitToClient(Visit visit)
    //{
    //    throw new NotImplementedException();
    //}

    public List<Visit> GetAllVisitByAngentId(int agentId)
    {
        return DbSet.Where(v => v.Agent.Id == agentId).ToList();
    }

    public List<Visit> GetAllVisitByClientId(int clientId)
    {
        return DbSet.Where(v => v.Client.Id == clientId).ToList();
    }

    public List<Visit> GetAllVisitByPropertyId(int propertyId)
    {
        return DbSet.Where(v => v.Property.Id == propertyId).ToList();
    }

    
}
