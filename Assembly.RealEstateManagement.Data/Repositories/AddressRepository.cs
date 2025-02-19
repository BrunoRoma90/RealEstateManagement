using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.Repositories;

internal class AddressRepository : Repository<Address, int>, IAddressRepository
{
    public AddressRepository(ApplicationDbContext context) : base(context)
    {

    }
}
