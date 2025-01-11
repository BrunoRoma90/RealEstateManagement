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

    private Client(Name name, Account account, Contact contact) : base(name, account, contact) 
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
        IsRegistered = isRegistered;
        FavoriteProperties = favoriteProperties ?? new List<FavoriteProperties>();
        Ratings = ratings ?? new List<Rating>();
        Comments = comments ?? new List<Comment>();
    }

    public static Client CreateClient(Name name, Account account, Contact contact)
    {
        return new Client(name, account, contact);
    }

    public void UpdateClient(Name newName, Account newAccount, Contact newCntact, bool isRegistered)
    {
        if(newName != null)
        {
            Name.UpdateName(newName.FirstName,newName.MiddleNames, newName.LastName);
        }
        if(newAccount != null)
        {
            Account.UpdateEmailAndPassword(newAccount.Email, newAccount.Password);
        }
        if(newCntact != null)
        {
            Contact.UpdateContact(newCntact);
        }

        IsRegistered = isRegistered;
    }

  
}


