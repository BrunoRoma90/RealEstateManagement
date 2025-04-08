
using System.Collections.Generic;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Domain.Core.Repositories;

public interface IVisitRepository : IRepository<Visit, int>
{


    public List<Visit> GetAllVisitByClientId(int clientId);
    public List<Visit> GetAllVisitByPropertyId(int propertyId);
    public List<Visit> GetAllVisitByAngentId(int agentId);

    public List<Visit> GetAllVisitsWithClient();

    public List<Visit> GetAllVisitsWithAgent();
  
    public List<Visit> GetAllVisitsWithProperty();

    public Client? GetClientByVisitId(int visitId);
    public Agent? GetAgentByVisitId(int visitId);

    public Property? GetPropertyByVisitId(int visitId);




    //public void AddVisitToAgent(Visit visit);

    //public void AddVisitToClient(Visit visit);
    //void AddNotes(int visitId, string notes);
}
