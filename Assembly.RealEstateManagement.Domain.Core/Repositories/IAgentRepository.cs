using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Domain.Core.Repositories;

public interface IAgentRepository : IRepository<Agent, int>
{
    public Property GetPropertyById(int propertyId);

    public Property CreateProperty(Property property);

    public void DeleteProperty(int propertyId);

    public void DeleteProperty(Property property);
    public Property UpdateProperty(Property property);

    public void AddPropertyToMyList(int agentId,Property property);

    public void RemovePropertyFromAgent(int agentId, Property property);

    List<Property> GetPropertiesByAgentId(int agentId);
    List<Visit> GetVisitsByAgentId(int agentId);

    public List<Agent> GetAgentsByManagerId(int managerId);


    public void AddNotes(int visitId, string notes);

    public void AddContactToMyList(int angentId, Contact contact);

    public void RemoveContactFromMyList(int angentId, Contact contact);


    public void AddVisitToMyList(int agentId,Visit visit);

    public void RemoveVisitToMyList(int agentId, Visit visit);





}
