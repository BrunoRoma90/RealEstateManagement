using Assembly.RealEstateManagement.Domain.Common;

namespace Assembly.RealEstateManagement.Domain.Model;

public class Client : AuditableEntity<int>
{
    public Name Name { get; private set; }
    public Account Account { get; private set; }
    public Address Address { get; private set; }
    public bool IsRegistered { get; private set; }
    public List<FavoriteProperties> FavoriteProperties { get; private set; }
    public List<Rating> Ratings { get; private set; }

    public List<Comment> Comments { get; private set; }

    private Client() { }

}


