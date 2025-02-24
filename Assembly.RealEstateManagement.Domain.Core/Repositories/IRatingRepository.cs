using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Domain.Core.Repositories;

public interface IRatingRepository : IRepository<Rating, int>
{
    public List<Rating> GetRatingsByPropertyId(int propertyId);
}
