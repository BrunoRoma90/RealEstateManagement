using Assembly.RealEstateManagement.Domain.Common;
using Assembly.RealEstateManagement.Domain.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace Assembly.RealEstateManagement.Domain.Model;

public class FavoriteProperties : AuditableEntity<int>
{
    public Property Property { get; private set; }
    
    private FavoriteProperties() { } 
    
    private FavoriteProperties(Property property):this()
    {
        ValidateFavorieProperties(property);
        Property = property;
    }

    private void ValidateFavorieProperties(Property property)
    {
        if (property == null)
        {
            throw new ArgumentNullException(nameof(property), "Property is required.");
        }


    }

}
