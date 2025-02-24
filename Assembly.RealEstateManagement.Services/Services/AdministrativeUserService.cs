using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Interfaces;
using Assembly.RealEstateManagement.Domain.Core.Repositories;

namespace Assembly.RealEstateManagement.Services.Services;

public class AdministrativeUserService : IAdministrativeUserService
{
    private IAdministrativeUsersRepository _administrativesUserRepository;

    public AdministrativeUserService(IAdministrativeUsersRepository administrativesUserRepository)
    {
        _administrativesUserRepository = administrativesUserRepository;
    }

    //public void AddNotes(int visitId, string notes)
    //{
    //    _administrativesUserRepository.AddNotes(visitId, notes);
    //}

    //public void AddVisit(Visit visit)
    //{
    //    _administrativesUserRepository.AddVisit(visit);
    //}

    //public void AddVisitToAgent(Visit visit)
    //{
    //    _administrativesUserRepository.AddVisitToAgent(visit);
    //}

    //public void AddVisitToClient(Visit visit)
    //{
    //    _administrativesUserRepository.AddVisitToClient(visit);
    //}

    //public Client CreateClient(Client client)
    //{
    //    return _administrativesUserRepository.CreateClient(client);
    //}

    //public List<Client> GetAllClients()
    //{
    //    return _administrativesUserRepository.GetClients();
    //}

    //public List<Visit> GetAllVisitsByAgentId(int agentId)
    //{
    //    return _administrativesUserRepository.GetVisitsByAgentId(agentId);
    //}

    //public List<Visit> GetAllVisitsByClientId(int clientId)
    //{
    //    return _administrativesUserRepository.GetVisitsByClientId(clientId);
    //}

    //public Visit GetVisitByAgentId(int agentId)
    //{
    //    return _administrativesUserRepository.GetVisitByAgentId(agentId);
    //}

    //public Visit GetVisitByClientId(int clientId)
    //{
    //    return _administrativesUserRepository.GetVisitByClientId(clientId);
    //}

    //public Visit UpdateVisit(Visit visit)
    //{
    //    return _administrativesUserRepository.UpdateVisit(visit);
    //}

}
