using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Assembly.RealEstateManagement.Data.Repositories;

internal class AdministrativeUserAllContactRepository : Repository<AdministrativeUserAllContact, int>, IAdministrativeUserAllContactRepository
{
    public AdministrativeUserAllContactRepository(ApplicationDbContext context) : base(context)
    {

    }

    public List<AdministrativeUserAllContact> GetAdministrativeUserContacts(int administrativeUserId)
    {
        return DbSet.Where(auac => auac.AdministrativeUser.Id == administrativeUserId).ToList();
    }

    public List<AdministrativeUserAllContact> GetAllAdministrativeUserAllContactWithAdministrativeUser()
    {
        return DbSet.Include(x => x.AdministrativeUser)
            .ThenInclude(m => m.Account)
            .Include(m => m.AdministrativeUser.Address)
            .ToList();
    }
}
