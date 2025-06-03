using Assembly.RealEstateManagement.Domain.Common;
using Assembly.RealEstateManagement.Domain.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace Assembly.RealEstateManagement.Domain.Model;

public class FavoriteProperty : AuditableEntity<int>
{

    public int ClientId { get; private set; }
    public int PropertyId { get; private set; }

    public Property Property { get; private set; }

    public static FavoriteProperty Create(int clientId, int propertyId)
    {
        return new FavoriteProperty
        {
            ClientId = clientId,
            PropertyId = propertyId
        };
    }
    public void Update(int newPropertyId)
    {
        PropertyId = newPropertyId;
    }



    public static void Restore(FavoriteProperty favoriteProperties)
    {
        favoriteProperties.IsDeleted = false;
    }
    

}
