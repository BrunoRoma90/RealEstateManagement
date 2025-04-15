using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Domain.Core.Repositories;

public interface IAdministrativeUserPersonalContactRepository : IRepository<AdministrativeUserPersonalContact, int>
{
    public List<AdministrativeUserPersonalContact> GetMyPersonalContacts(int administrativeUserId);

    public List<AdministrativeUserPersonalContact> GetAllAdministrativeUserPersonalContactWithAdministrativeUser();

    public AdministrativeUserPersonalContact? GetAdministrativeUserContactWithAdministrativeUser(int id);
}
