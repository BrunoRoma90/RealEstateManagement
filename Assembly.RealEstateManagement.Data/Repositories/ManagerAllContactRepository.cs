using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Assembly.RealEstateManagement.Data.Repositories;

internal class ManagerAllContactRepository : Repository<ManagerAllContact, int>, IManagerAllContactRepository
{
    public ManagerAllContactRepository(ApplicationDbContext context) : base(context)
    {

    }

    public ManagerAllContact? GetManagerContactWithManager(int id)
    {
        return DbSet.Include(x => x.Manager)
            .ThenInclude(m => m.Account)
            .Include(m => m.Manager.Address)
            .FirstOrDefault(x => x.Id == id);
    }

    public List<ManagerAllContact> GetManagerContacts(int managerId)
    {
        return DbSet.Where(mac => mac.Manager.Id == managerId).ToList();
    }

    public List<ManagerAllContact> GetAllManagerAllContactWithManager()
    {
        return DbSet.Include(x => x.Manager)
            .ThenInclude(m => m.Account)
            .Include(m => m.Manager.Address)
            .ToList();
    }
}
