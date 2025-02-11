using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.Repositories;

internal class AdministrativeUserAllContactRepository : Repository<AdministrativeUserAllContact, int>, IAdministrativeUserAllContactRepository
{
    public AdministrativeUserAllContactRepository(ApplicationDbContext context) : base(context)
    {

    }

   
}
