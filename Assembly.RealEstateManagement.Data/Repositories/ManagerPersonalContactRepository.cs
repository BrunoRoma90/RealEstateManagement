using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.Repositories;

internal class ManagerPersonalContactRepository : Repository<ManagerPersonalContact, int>, IManagerPersonalContactRepository
{
    public ManagerPersonalContactRepository(ApplicationDbContext context) : base(context)
    {

    }

    public List<ManagerPersonalContact> GetMyPersonalContacts(int managerId)
    {
        return DbSet.Where(mpc => mpc.Manager.Id == managerId).ToList();
    }
}
