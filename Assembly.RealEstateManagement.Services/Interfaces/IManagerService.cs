using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Dtos.Manager;

namespace Assembly.RealEstateManagement.Services.Interfaces;

public interface IManagerService
{

    IEnumerable<ManagerDto> GetManagers();

    public ManagerDto GetManagerById(int id);
    ManagerDto Add(CreateManagerDto manager);

    //public Agent GetAgent(int id);


    //public List<Agent> GetAgents();


    //public List<Agent> GetAgentsByManagerId(int managerId);

    //public void TransferProperty(int managerId, int fromAgentId, int toAgentId, Property property);

    //public void TransferAllProperties(int managerId, int fromAgentId, int toAgentId);

    //public List<Visit> GetAgentCalendar(int agentId);


    //public void CreateAppointment(int agentId, Visit visit);


    //public void AddAgent(int managerId, Agent agent);

    //public void RemoveAgent(int managerId, Agent agent);

    //public List<Agent> GetAllManagedAgents(int managerId);

    //public void AddNotes(int visitId, string notes);


}
