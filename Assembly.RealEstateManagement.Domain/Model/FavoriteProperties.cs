using Assembly.RealEstateManagement.Domain.Common;
using static System.Net.Mime.MediaTypeNames;

namespace Assembly.RealEstateManagement.Domain.Model;

public class FavoriteProperties : AuditableEntity<int>
{
    public Property Property { get; private set; }
    
    private FavoriteProperties() { } 
    
    private FavoriteProperties(Property property):this()
    {
        Property = property;
    }

}
