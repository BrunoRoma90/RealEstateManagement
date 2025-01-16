using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain.Model;

public class FavoriteProperties : AuditableEntity<int>
{
    public Client Client { get; private set; }
    public Property Property { get; private set; }

    private FavoriteProperties() 
    {
        Client = null;
        Property = null;
    }

    private FavoriteProperties(Client client, Property property)
    {
        Client = client;
        Property = property;
    }
}


