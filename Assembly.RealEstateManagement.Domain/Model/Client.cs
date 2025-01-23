namespace Assembly.RealEstateManagement.Domain.Model;

public class Client : Person
{
    public bool IsRegistered { get; private set; }
    public List<FavoriteProperties> FavoriteProperties { get; private set; }

    public List<Visit> Visits { get; private set; }

    public List<Rating> Ratings { get; private set; }

    public List<Comment> Comments { get; private set; }

   private Client()
    {
        
        IsRegistered = false;
        FavoriteProperties = new List<FavoriteProperties>();
        Visits = new List<Visit>();
        Ratings = new List<Rating>(); 
        Comments = new List<Comment>();
        
    }


    private Client(Name name, Account account, Contact contact, bool isRegistered,
        List<FavoriteProperties> favoriteProperties, List<Rating> ratings, List<Comment> comments, List<Visit> visits)
        : base(name, account, contact)
    {
        ValidateClient(isRegistered,favoriteProperties, ratings, comments, visits);
        IsRegistered = isRegistered;
        FavoriteProperties = favoriteProperties ?? new List<FavoriteProperties>();
        Visits = visits ?? new List<Visit>();
        Ratings = ratings ?? new List<Rating>();
        Comments = comments ?? new List<Comment>();
    }

    public static Client CreateClient(Name name, Account account, Contact contact, bool isRegistered , List<FavoriteProperties> favoriteProperties,
        List<Rating> ratings, List<Comment> comments, List<Visit> visits)
    {
        return new Client(name, account, contact, isRegistered, favoriteProperties, ratings, comments, visits);
    }

    public void UpdateClient(Name name, Account account, Contact contact, bool isRegistered, List<FavoriteProperties> favoriteProperties,
        List<Rating> ratings, List<Comment> comments, List<Visit> visits)
    {
        ValidateClient(isRegistered, favoriteProperties, ratings, comments, visits);
        Name.UpdateName(name.FirstName, name.MiddleNames, name.LastName);
        Account.UpdateEmailAndPassword(account.Email, account.Password);
        Contact.UpdateContact(contact);
        IsRegistered = isRegistered;
        FavoriteProperties = favoriteProperties;
        Visits = visits;
        Ratings = ratings;
        Comments = comments;


    }

  
    private void ValidateClient( bool isRegistered, List<FavoriteProperties> favoriteProperties, 
        List<Rating> ratings, List<Comment> comments, List<Visit> visits)
    {
        
        if (favoriteProperties == null)
        {
            throw new ArgumentNullException(nameof(favoriteProperties), "Favorite properties list is required.");
        }
        if (visits == null)
        {
            throw new ArgumentNullException(nameof(visits), "Visits list is required.");
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


