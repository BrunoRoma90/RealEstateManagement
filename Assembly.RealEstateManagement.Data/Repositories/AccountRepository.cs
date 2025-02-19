using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.Repositories;

internal class AccountRepository : Repository<Account, int>, IAccountRepository
{
    public AccountRepository(ApplicationDbContext context) : base(context)
    {

    }
}
