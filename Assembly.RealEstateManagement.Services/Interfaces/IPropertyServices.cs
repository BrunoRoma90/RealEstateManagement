using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Dtos.Agent;
using Assembly.RealEstateManagement.Services.Dtos.Property;

namespace Assembly.RealEstateManagement.Services.Interfaces;

public interface IPropertyServices
{
    IEnumerable<PropertyDto> GetProperties();

    public PropertyDto GetPropertyById(int id);
    PropertyDto Add(CreatePropertyDto property);

    PropertyDto Update(UpdatePropertyDto property);
}
