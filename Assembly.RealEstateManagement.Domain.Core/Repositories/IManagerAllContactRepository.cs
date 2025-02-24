using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Domain.Core.Repositories;

public interface IManagerAllContactRepository : IRepository<ManagerAllContact, int>
{
    public List<ManagerAllContact> GetManagerContacts(int managerId);
}
