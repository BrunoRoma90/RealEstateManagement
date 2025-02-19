using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Domain.Core.Repositories;

public interface IPropertyRepository : IRepository<Property, int>
{
    public List<Property> GetPropertiesbyAgentId(int agentId);
}
