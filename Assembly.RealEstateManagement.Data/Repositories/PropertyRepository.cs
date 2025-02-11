using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Assembly.RealEstateManagement.Data.Repositories;

internal class PropertyRepository : Repository<Property, int>, IPropertyRepository
{
    public PropertyRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
