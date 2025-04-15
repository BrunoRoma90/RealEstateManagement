using Assembly.RealEstateManagement.Domain.Model;
using System.Collections.Generic;

namespace Assembly.RealEstateManagement.Domain.Core.Repositories;

public interface IManagerAllContactRepository : IRepository<ManagerAllContact, int>
{
    public List<ManagerAllContact> GetManagerContacts(int managerId);

    public List<ManagerAllContact> GetAllManagerAllContactWithManager();

    public ManagerAllContact? GetManagerContactWithManager(int id);

}
