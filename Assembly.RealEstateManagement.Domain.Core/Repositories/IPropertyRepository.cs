using System.Collections.Generic;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Domain.Core.Repositories;

public interface IPropertyRepository : IRepository<Property, int>
{
    public List<Property> GetPropertiesbyAgentId(int agentId);
    public Property? GetPropertyByAddressId(int addressId);

    public List<Room> GetRoomsByPropertyId(int propertyId);
    public List<PropertyImage> GetPropertyImagesByPropertyId(int propertyId);

    public List<Property> GetAllPropertiesWithAddress();

    public List<Property> GetAllPropertiesWithAgent();

    public Agent? GetAgentByPropertyId(int propertyId);


    public Address? GetPropertyAddress(int propertyId);


}
