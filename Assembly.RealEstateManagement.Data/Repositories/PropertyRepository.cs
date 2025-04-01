using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;
using Microsoft.EntityFrameworkCore;


namespace Assembly.RealEstateManagement.Data.Repositories;

internal class PropertyRepository : Repository<Property, int>, IPropertyRepository
{
    public PropertyRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public List<Property> GetPropertiesbyAgentId(int agentId)
    {
        return DbSet.Where(p => p.Agent.Id == agentId).ToList();
    }

    public Property? GetPropertyByAddressId(int addressId)
    {
        return DbSet.FirstOrDefault(p => p.Address.Id == addressId);
    }

    public List<PropertyImage> GetPropertyImagesByPropertyId(int propertyId)
    {
        var property = DbSet
        .Include(p => p.PropertyImages)
        .FirstOrDefault(p => p.Id == propertyId);

        return property?.PropertyImages ?? new List<PropertyImage>();
    }

    public List<Room> GetRoomsByPropertyId(int propertyId)
    {
        var property = DbSet
        .Include(p => p.Rooms)
        .FirstOrDefault(p => p.Id == propertyId);

        return property?.Rooms ?? new List<Room>();
    }
}
