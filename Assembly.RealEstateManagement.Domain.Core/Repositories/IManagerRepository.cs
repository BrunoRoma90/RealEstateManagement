
using System.Collections.Generic;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Domain.Core.Repositories;

public interface IManagerRepository : IRepository<Manager, int>
{
    public List<Manager> GetAllManagersWithAccount();
    public List<Manager> GetAllManagersWithAddress();

    public Account? GetManagerAccount(int managerId);
    public Address? GetManagerAddress(int managerId);
    public Manager? GetManagerByManagerNumber(int managerNumber);

    public Manager? GetManagerByEmployeeNumber(int employeeNumber);

    public Manager? GetByEmail(string email);



    #region
    //public List<Agent> GetAgents();

    //public Agent GetAgent(int id);

    //public List<Agent> GetAgentsByManagerId(int managerId);

    //public void TransferProperty(int managerId, int fromAgentId, int toAgentId, Property property);

    //public void TransferAllProperties(int managerId, int fromAgentId, int toAgentId);


    //public List<Visit> GetAgentCalendar(int agentId);
    //public void CreateAppointment(int agentId, Visit visit);

    //public void AddAgent(int managerId, Agent agent);

    //public void RemoveAgent(int managerId, Agent agent);

    //public List<Agent> GetAllManagedAgents(int managerId);

    //public void AddNotes(int visitId, string notes);
    #endregion
}
