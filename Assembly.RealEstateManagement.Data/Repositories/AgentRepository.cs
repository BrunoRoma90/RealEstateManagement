using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.Repositories;

internal class AgentRepository : Repository<Agent, int>, IAgentRepository
{
    public AgentRepository(ApplicationDbContext context) : base(context)
    {

    }

    public void AddContactToMyList(int angentId, Contact contact)
    {
        throw new NotImplementedException();
    }

    public void AddNotes(int visitId, string notes)
    {
        throw new NotImplementedException();
    }

    public void AddPropertyToMyList(int agentId, Property property)
    {
        throw new NotImplementedException();
    }

    public void AddVisitToMyList(int agentId, Visit visit)
    {
        throw new NotImplementedException();
    }

    public Property CreateProperty(Property property)
    {
        throw new NotImplementedException();
    }

    public void DeleteProperty(int propertyId)
    {
        throw new NotImplementedException();
    }

    public void DeleteProperty(Property property)
    {
        throw new NotImplementedException();
    }

    public List<Agent> GetAgentsByManagerId(int managerId)
    {
        return DbSet.Where(a => a.Manager.Id == managerId).ToList();
    }

   

    public List<Property> GetPropertiesByAgentId(int agentId)
    {
        throw new NotImplementedException();
    }

    public Property GetPropertyById(int propertyId)
    {
        throw new NotImplementedException();
    }

    public List<Visit> GetVisitsByAgentId(int agentId)
    {
        throw new NotImplementedException();
    }

    public void RemoveContactFromMyList(int angentId, Contact contact)
    {
        throw new NotImplementedException();
    }

    public void RemovePropertyFromAgent(int agentId, Property property)
    {
        throw new NotImplementedException();
    }

    public void RemoveVisitToMyList(int agentId, Visit visit)
    {
        throw new NotImplementedException();
    }

    public Property UpdateProperty(Property property)
    {
        throw new NotImplementedException();
    }
}
