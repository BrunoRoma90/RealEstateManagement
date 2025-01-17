namespace Assembly.RealEstateManagement.Domain.Model;

public class Client : Person
{
    public bool IsRegistered { get; private set; }
    public List<FavoriteProperties> FavoriteProperties { get; private set; }

    public List<Rating> Ratings { get; private set; }

    public List<Comment> Comments { get; private set; }

   private Client()
    {
        
        IsRegistered = false;
        FavoriteProperties = new List<FavoriteProperties>();
        Ratings = new List<Rating>(); 
        Comments = new List<Comment>();
        
    }


    private Client(Name name, Account account, Contact contact, bool isRegistered,
        List<FavoriteProperties> favoriteProperties, List<Rating> ratings, List<Comment> comments)
        : base(name, account, contact)
    {
        ValidateClient(isRegistered,favoriteProperties, ratings, comments);
        IsRegistered = isRegistered;
        FavoriteProperties = favoriteProperties ?? new List<FavoriteProperties>();
        Ratings = ratings ?? new List<Rating>();
        Comments = comments ?? new List<Comment>();
    }

    public static Client CreateClient(Name name, Account account, Contact contact, bool isRegistered , List<FavoriteProperties> favoriteProperties,
        List<Rating> ratings, List<Comment> comments)
    {
        return new Client(name, account, contact, isRegistered, favoriteProperties, ratings, comments );
    }

    public void UpdateClient(Name name, Account account, Contact contact, bool isRegistered, List<FavoriteProperties> favoriteProperties,
        List<Rating> ratings, List<Comment> comments)
    {
        ValidateClient(isRegistered, favoriteProperties, ratings, comments);
        Name.UpdateName(name.FirstName, name.MiddleNames, name.LastName);
        Account.UpdateEmailAndPassword(account.Email, account.Password);
        Contact.UpdateContact(contact);
        IsRegistered = isRegistered;
        FavoriteProperties = favoriteProperties;
        Ratings = ratings;
        Comments = comments;


    }

  
    private void ValidateClient( bool isRegistered, List<FavoriteProperties> favoriteProperties, List<Rating> ratings, List<Comment> comments)
    {
        
        if (favoriteProperties == null)
        {
            throw new ArgumentNullException(nameof(favoriteProperties), "Favorite properties list is required.");
        }
        if (ratings == null)
        {
            throw new ArgumentNullException(nameof(ratings), "Ratings list is required.");
        }
        if (comments == null)
        {
            throw new ArgumentNullException(nameof(comments), "Comments list is required.");
        }
        if (isRegistered == false)
        {
            throw new ArgumentNullException(nameof(isRegistered), "Cannot be false.");
        }

    }
}


