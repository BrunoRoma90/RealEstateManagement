using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;

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


}
