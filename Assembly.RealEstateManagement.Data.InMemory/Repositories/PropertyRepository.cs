

using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Data.InMemory.Repositories;

internal class PropertyRepository : IPropertyRepository
{
    private readonly Database _db;
    public PropertyRepository(Database database)
    {
        _db = database;

    }
    public Property Add(Property property)
    {
        _db.Properties.Add(property);
        return property;
    }

    public List<Property> GetAll()
    {
        var allProperties = new List<Property>();
        foreach (var property in _db.Properties)
        {
            allProperties.Add(property);
        }
        return allProperties;
    }

    public Property GetById(int id)
    {
        foreach (var property in _db.Properties)
        {
            if (property.Id == id)
            {
                return property;

            }
        }
        throw new KeyNotFoundException($"Property with ID {id} was not found.");
    }

    public Property Update(Property property)
    {
        var properties = _db.Properties.ToList();
        foreach (var existingProperty in properties)
        {
            if (existingProperty.Id == property.Id)
            {
                existingProperty.UpdateProperty(property);
                return existingProperty;
            }
        }
        throw new KeyNotFoundException($"Property was not found.");
    }
    public Property Delete(Property property)
    {
        var properties = _db.Properties.ToList();
        foreach (var existingProperty in properties)
        {
            if (existingProperty.Id == property.Id)
            {
                _db.Properties.Remove(existingProperty);
            }
        }
        throw new KeyNotFoundException($"Property was not found.");
    }

    public Property Delete(int id)
    {
        var properties = _db.Properties.ToList();
        foreach (var property in properties)
        {
            if (property.Id == id)
            {
                _db.Properties.Remove(property);

            }
        }
        throw new KeyNotFoundException($"Property with ID {id} was not found.");
    }

   
}
