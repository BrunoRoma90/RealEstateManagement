using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Services.Interfaces;

internal interface IAdministrativeUserService
{
    public Visit GetVisitByClientId(int clientId);

    public List<Visit> GetAllVisitsByClientId(int clientId);

    public List<Visit> GetAllVisitsByAgentId(int agentId);

    public Visit GetVisitByAgentId(int agentId);

    public Visit UpdateVisit(Visit visit);

    public void AddVisit(Visit visit);

    public void AddVisitToAgent(Visit visit);

    public void AddVisitToClient(Visit visit);

    
}
