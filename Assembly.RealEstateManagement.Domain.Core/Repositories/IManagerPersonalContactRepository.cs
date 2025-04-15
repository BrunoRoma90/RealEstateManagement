using System.Collections.Generic;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Domain.Core.Repositories;

public interface IManagerPersonalContactRepository : IRepository<ManagerPersonalContact, int>
{
    public List<ManagerPersonalContact> GetMyPersonalContacts(int managerId);

    public List<ManagerPersonalContact> GetAllManagerPersonalContactWithManager();

    public ManagerPersonalContact? GetManagerContactWithManager(int id);
}

