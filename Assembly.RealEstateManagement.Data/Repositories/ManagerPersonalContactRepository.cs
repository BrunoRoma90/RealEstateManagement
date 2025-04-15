using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Assembly.RealEstateManagement.Data.Repositories;

internal class ManagerPersonalContactRepository : Repository<ManagerPersonalContact, int>, IManagerPersonalContactRepository
{
    public ManagerPersonalContactRepository(ApplicationDbContext context) : base(context)
    {

    }

    public ManagerPersonalContact? GetManagerContactWithManager(int id)
    {
        return DbSet.Include(x => x.Manager)
            .ThenInclude(m => m.Account)
            .Include(m => m.Manager.Address)
            .FirstOrDefault(x => x.Id == id);
    }

    public List<ManagerPersonalContact> GetMyPersonalContacts(int managerId)
    {
        return DbSet.Where(mpc => mpc.Manager.Id == managerId).ToList();
    }

    public List<ManagerPersonalContact> GetAllManagerPersonalContactWithManager()
    {
        return DbSet.Include(x => x.Manager)
            .ThenInclude(m => m.Account)
            .Include(m => m.Manager.Address)
            .ToList();
    }

   
}
