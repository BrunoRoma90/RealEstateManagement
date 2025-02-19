using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Domain.Core.Repositories;

public interface IAgentRepository : IRepository<Agent, int>
{

    public Manager? GetManagerByAgentId(int agentId);
    public Account? GetAgentAccount(int agentId);
    public Agent? GetAgentByAgentNumber(int agentNumber);
    public Address? GetAgentAddress(int agentId);
    public List<Agent> GetAgentsByManagerId(int managerId);
    public Agent? GetAgentByEmployeeNumber(int employeeNumber);

    #region
    //public Property GetPropertyById(int propertyId);

    //public Property CreateProperty(Property property);

    //public void DeleteProperty(int propertyId);

    //public void DeleteProperty(Property property);
    //public Property UpdateProperty(Property property);

    //public void AddPropertyToMyList(int agentId,Property property);

    //public void RemovePropertyFromAgent(int agentId, Property property);

    //List<Property> GetPropertiesByAgentId(int agentId);
    //List<Visit> GetVisitsByAgentId(int agentId);




    //public void AddNotes(int visitId, string notes);

    //public void AddContactToMyList(int angentId, Contact contact);

    //public void RemoveContactFromMyList(int angentId, Contact contact);


    //public void AddVisitToMyList(int agentId,Visit visit);

    //public void RemoveVisitToMyList(int agentId, Visit visit);

    #endregion




}
