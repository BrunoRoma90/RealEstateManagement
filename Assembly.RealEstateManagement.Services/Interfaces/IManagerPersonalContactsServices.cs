using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Dtos;

namespace Assembly.RealEstateManagement.Services.Interfaces;

public interface IManagerPersonalContactsServices
{
    IEnumerable<ManagerPersonalContactDto> GetManagerPersonalsContacts();

    public List<ManagerPersonalContactDto> GetContactsByManagerId(int managerId);
    ManagerPersonalContactDto Add(CreateManagerPersonalContacts managerPersonalContacts);

}

public interface IAgentPersonalContactsServices 
{
    IEnumerable<ManagerPersonalContactDto> GetAgentPersonalsContacts();

    public AgentPersonalContact GetPersonalContactsByAgentId(int id);
    ManagerPersonalContactDto Add(CreateAgentPersonalContactsDto agentPersonalContacts);
}

public interface IAdministrativeUsersPersonalContactsServices
{
    IEnumerable<AdministrativeUserPersonalContactDto> GetAdministrativeUsersPersonalsContacts();

    public AdministrativeUserPersonalContact GetPersonalContactsByAdministrativeUserId(int id);
    AdministrativeUserPersonalContactDto Add(CreateAdministrativeUserPersonalContactDto administrativeUserPersonalContacts);
}

