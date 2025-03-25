using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Dtos;

namespace Assembly.RealEstateManagement.Services.Interfaces;

public interface IAdministrativeUserService
{

    IEnumerable<AdministrativeUserDto> GetAdministrativeUsers();

    public AdministrativeUser GetAdministrativeUserById(int id);
    AdministrativeUserDto Add(CreateAdministrativeUserDto administrativeUser);


    //public Visit GetVisitByClientId(int clientId);

    //public List<Visit> GetAllVisitsByClientId(int clientId);

    //public List<Visit> GetAllVisitsByAgentId(int agentId);

    //public Visit GetVisitByAgentId(int agentId);

    //public Visit UpdateVisit(Visit visit);

    //public void AddVisit(Visit visit);

    //public void AddVisitToAgent(Visit visit);

    //public void AddVisitToClient(Visit visit);

    //public void AddNotes(int visitId, string notes);

    //public Client CreateClient(Client client);

    //public List<Client> GetAllClients();


}
