using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.Repositories;

internal class RatingRepository : Repository<Rating, int> , IRatingRepository
{
    public RatingRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public List<Rating> GetRatingsByPropertyId(int propertyId)
    {
        return DbSet.Where(r => r.Property.Id == propertyId).ToList();
    }
}
