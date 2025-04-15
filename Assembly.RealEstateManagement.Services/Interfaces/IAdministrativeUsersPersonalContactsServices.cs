using Assembly.RealEstateManagement.Services.Dtos.AdministrativeUsers;

namespace Assembly.RealEstateManagement.Services.Interfaces;

public interface IAdministrativeUsersPersonalContactsServices
{
    IEnumerable<AdministrativeUserPersonalContactDto> GetAdministrativeUsersPersonalsContacts();

    public List<AdministrativeUserPersonalContactDto> GetPersonalContactsByAdministrativeUserId(int administrativeUserId);
    AdministrativeUserPersonalContactDto Add(CreateAdministrativeUserPersonalContactDto administrativeUserPersonalContacts);

    AdministrativeUserPersonalContactDto Update(UpdateAdministrativeUserPersonalContactDto administrativeUserPersonalContacts);
}

