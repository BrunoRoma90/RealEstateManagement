using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.Repositories;

internal class AdministrativeUserPersonalContactRepository : Repository<AdministrativeUserPersonalContact, int>, IAdministrativeUserPersonalContactRepository
{
    public AdministrativeUserPersonalContactRepository(ApplicationDbContext context) : base(context)
    {

    }

   
}
