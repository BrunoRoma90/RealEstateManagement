using Assembly.RealEstateManagement.Domain.Common;
using Assembly.RealEstateManagement.Domain.Interfaces;

namespace Assembly.RealEstateManagement.Domain.Model;

public class Client : AuditableEntity<int>
{
    public Name Name { get; private set; }
    public Account Account { get; private set; }
    public Address Address { get; private set; }
    public bool IsRegistered { get; private set; }
    public List<FavoriteProperty> FavoriteProperties { get; private set; }
    public List<Rating> Ratings { get; private set; }

    public List<Comment> Comments { get; private set; }

    private Client() { }

    private Client(int id, Name name, string email, string password, Address address, bool isRegistered,
        List<FavoriteProperty> favoriteProperties,
        List<Rating> ratings,
        List<Comment> comments)
    {
        ValidateClient(name, email, password, address, favoriteProperties, ratings, comments);
        Id = id;
        Name = name;
        Account = Account.Create(email, password);
        Address = address;
        IsRegistered = isRegistered;
        FavoriteProperties = favoriteProperties;
        Ratings = ratings;
        Comments = comments;

    }

    private Client(Name name, string email, string password, Address address, bool isRegistered,
        List<FavoriteProperty> favoriteProperties,
        List<Rating> ratings,
        List<Comment> comments)
    {   
        
        ValidateClient(name, email, password, address, favoriteProperties, ratings, comments);
        Name = Name.Create(name.FirstName, name.MiddleNames, name.LastName);
        Account = Account.Create(email, password);
        Address = Address.Create(address.Street, address.Number, address.PostalCode, address.City, address.Country);
        IsRegistered = isRegistered;
        FavoriteProperties = favoriteProperties;
        Ratings = ratings;
        Comments = comments;
    
    }

    public static Client Create(Name name, string email, string password, Address address, List<FavoriteProperty> favoriteProperties,
        List<Rating> ratings, List<Comment> comments)
    {
        
        return new Client(name, email, password, address, true, favoriteProperties, ratings, comments);
    }

    //public static Client Update(Name newName, Account newAccount, Address newAddress, List<FavoriteProperties> newFavoriteProperties,
    //List<Rating> newRatings, List<Comment> newComments)
    //{
    //    return new Client(newName, newAccount, newAddress, true, newFavoriteProperties, newRatings, newComments);
    //}

    public void Update(int id,Name newName, string newEmail, string newPassword, Address newAddress, List<FavoriteProperty> newFavoriteProperties,
   List<Rating> newRatings, List<Comment> newComments)
    {
        Id = id;
        Name = newName;
        Account.Update(newEmail, newPassword);
        Address = newAddress;
        FavoriteProperties = newFavoriteProperties;
        Ratings= newRatings;
        FavoriteProperties = newFavoriteProperties;
    }


    public static void Restore(Client client)
    {
        client.IsDeleted = false;
    }

    public void AddFavoriteProperty(Property property)
    {
        if (property == null)
            throw new ArgumentNullException(nameof(property));

        if (FavoriteProperties.Any(fp => fp.PropertyId == property.Id))
            throw new InvalidOperationException("Property is already in favorites.");

        var favorite = FavoriteProperty.Create(this.Id, property.Id);
        FavoriteProperties.Add(favorite);
    }

    public void RemoveFavoriteProperty(int propertyId)
    {
        var favorite = FavoriteProperties.FirstOrDefault(fp => fp.PropertyId == propertyId);

        if (favorite == null)
            throw new InvalidOperationException("Property not found in favorites.");

        FavoriteProperties.Remove(favorite);
    }


    private void ValidateClient(Name name, string email, string password, Address address,
        List<FavoriteProperty> favoriteProperties, List<Rating> ratings, List<Comment> comments)
    {
        
        if (name == null)
        {
            throw new ArgumentException(nameof(name), "Name is required.");
        }
        if (email == null)
        {
            throw new ArgumentNullException(nameof(email), "Email is required.");
        }
        if (password == null)
        {
            throw new ArgumentNullException(nameof(password), "Password is required.");
        }
        if (address == null)
        {
            throw new ArgumentNullException(nameof(address), "Address is required.");
        }
        //if (favoriteProperties == null || favoriteProperties.Count == 0)
        //{
        //    throw new ArgumentNullException(nameof(favoriteProperties), "Favorite Properties list is required.");
        //}
        //if (ratings == null || ratings.Count == 0)
        //{
        //    throw new ArgumentNullException(nameof(ratings), "Ratings list is required.");
        //}
        //if (comments == null || comments.Count == 0)
        //{
        //    throw new ArgumentNullException(nameof(comments), "Comments list is required.");
        //}
    }
}


