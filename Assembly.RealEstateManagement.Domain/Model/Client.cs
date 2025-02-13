using Assembly.RealEstateManagement.Domain.Common;
using Assembly.RealEstateManagement.Domain.Interfaces;

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

    private Client(int id, Name name, Account account, Address address, bool isRegistered,
        List<FavoriteProperties> favoriteProperties,
        List<Rating> ratings,
        List<Comment> comments)
    {
        ValidateClient(id, name, account, address, favoriteProperties, ratings, comments);
        Id = id;
        Name = name;
        Account = account;
        Address = address;
        IsRegistered = isRegistered;
        FavoriteProperties = favoriteProperties;
        Ratings = ratings;
        Comments = comments;
    }


    private void ValidateClient(int  id, Name name, Account account, Address address,
        List<FavoriteProperties> favoriteProperties, List<Rating> ratings, List<Comment> comments)
    {
        if (id <= 0)
        {
            throw new ArgumentException(nameof(id), "Id must be greater than zero.");
        }
        if (name == null)
        {
            throw new ArgumentException(nameof(name), "Name is required.");
        }
        if (account == null)
        {
            throw new ArgumentNullException(nameof(account), "Account is required.");
        }
        if (address == null)
        {
            throw new ArgumentNullException(nameof(address), "Address is required.");
        }
        if (favoriteProperties == null || favoriteProperties.Count == 0)
        {
            throw new ArgumentNullException(nameof(favoriteProperties), "Favorite Properties list is required.");
        }
        if (ratings == null || ratings.Count == 0)
        {
            throw new ArgumentNullException(nameof(ratings), "Ratings list is required.");
        }
        if (comments == null || comments.Count == 0)
        {
            throw new ArgumentNullException(nameof(comments), "Comments list is required.");
        }
    }
}


