using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.Repositories;

internal class ManagerAllContactRepository : Repository<ManagerAllContact, int>, IManagerAllContactRepository
{
    public ManagerAllContactRepository(ApplicationDbContext context) : base(context)
    {

    }
}
