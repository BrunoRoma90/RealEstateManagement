using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Dtos.AdministrativeUsers;
using Assembly.RealEstateManagement.Services.Dtos.Manager;

namespace Assembly.RealEstateManagement.Services.Interfaces;

public interface IAdministrativeUsersAllContactsServices
{
    IEnumerable<AdministrativeUsersAllContactsDto> GetAdministrativeUserAllContacts();

    public List<AdministrativeUsersAllContactsDto> GetContactsByAdministrativeUserId(int administrativeUserId);
    AdministrativeUsersAllContactsDto Add(CreateAdministrativeUserAllContactsDto administrativeUserAllContacts);

    AdministrativeUsersAllContactsDto Update(UpdateAdministrativeUserAllContactsDto administrativeUserAllContacts);
}
