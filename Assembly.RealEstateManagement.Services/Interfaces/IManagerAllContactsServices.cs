using Assembly.RealEstateManagement.Services.Dtos.Manager;

namespace Assembly.RealEstateManagement.Services.Interfaces;

public interface IManagerAllContactsServices
{
    IEnumerable<ManagerAllContactsDto> GetManagerAllContacts();

    public List<ManagerAllContactsDto> GetContactsByManagerId(int managerId);
    ManagerAllContactsDto Add(CreateManagerAllContactsDto managerAllContacts);
}
