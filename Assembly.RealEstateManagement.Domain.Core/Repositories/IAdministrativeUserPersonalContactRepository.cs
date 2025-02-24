using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Domain.Core.Repositories;

public interface IAdministrativeUserPersonalContactRepository : IRepository<AdministrativeUserPersonalContact, int>
{
    public List<AdministrativeUserPersonalContact> GetMyPersonalContacts(int administrativeUserId);
}
