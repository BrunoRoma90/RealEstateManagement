using Assembly.RealEstateManagement.Services.Dtos.Manager;

namespace Assembly.RealEstateManagement.Services.Interfaces;

public interface IManagerPersonalContactsServices
{
    IEnumerable<ManagerPersonalContactDto> GetManagerPersonalsContacts();

    public List<ManagerPersonalContactDto> GetContactsByManagerId(int managerId);
    ManagerPersonalContactDto Add(CreateManagerPersonalContacts managerPersonalContacts);
    ManagerPersonalContactDto Update(UpdateManagerPersonalContactsDto managerPersonalContacts);

}

