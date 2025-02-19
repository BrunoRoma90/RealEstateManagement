using Assembly.RealEstateManagement.Domain.Common;
using Assembly.RealEstateManagement.Domain.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace Assembly.RealEstateManagement.Domain.Model;

public class FavoriteProperties : AuditableEntity<int>
{
    public Property Property { get; private set; }
    
    private FavoriteProperties() { } 
    
    private FavoriteProperties(int id,Property property):this()
    {
        ValidateFavorieProperties(property);
        Property = property;
        Created = DateTime.Now;
        Updated = DateTime.Now;
    }

    private FavoriteProperties(Property property):this()
    {
        ValidateFavorieProperties(property);
        Property = property;
    }

    public static FavoriteProperties Create(Property property)
    {
        return new FavoriteProperties(property);
    }
    public static FavoriteProperties Update(Property newProperty)
    {
        return new FavoriteProperties(newProperty);
    }

    public void Delete()
    {
        IsDeleted = true;
    }

    public static void Restore(FavoriteProperties favoriteProperties)
    {
        favoriteProperties.IsDeleted = false;
    }
    private void ValidateFavorieProperties(Property property)
    {
        if (property == null)
        {
            throw new ArgumentNullException(nameof(property), "Property is required.");
        }


    }

}
