using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Enums;
using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Interfaces;
using Assembly.RealEstateManagement.Services.Services;


namespace Assembly.RealEstateManagement.ConsoleApp.UserInterface.BackOffce;

internal class AdministativeUserPanel
{
    
    private readonly IAdministrativeUserService _administrativeUsersServices;

    public AdministativeUserPanel(IAdministrativeUserService administrativeUserService)
    {
        
        _administrativeUsersServices = administrativeUserService;
    }

    public void Run()
    {
        //Console.WriteLine("Welcome to the Administrative User Panel");
        //while (true)
        //{
        //    Console.WriteLine("\nMenu:");
        //    Console.WriteLine("1. Create Client");
        //    Console.WriteLine("2. List All Clients");
        //    Console.WriteLine("3. Exit");
        //    Console.Write("Choose an option: ");

        //    var input = Console.ReadLine();
        //    switch (input)
        //    {
        //        case "1":
        //            CreateClient();
        //            break;
        //        case "2":
        //            GetAllClients();
        //            break;
        //        case "3":
        //            Console.WriteLine("Exiting...");
        //            return;
        //        default:
        //            Console.WriteLine("Invalid option. Try again.");
        //            break;
        //    }
        //}
    }

    //public void CreateClient()
    //{
        
    //    Console.WriteLine("Input FirstName");
    //    var firstName = Console.ReadLine();
    //    Console.WriteLine("Input MiddlleNames");
    //    var middleNames = Console.ReadLine()?.Split(',') ?? Array.Empty<string>();
    //    Console.WriteLine("Input LastName");
    //    var lastName = Console.ReadLine();
    //    var name = Name.CreateName(firstName, middleNames, lastName);

    //    Console.WriteLine("Input Email");
    //    var email = Console.ReadLine();
    //    Console.WriteLine("Input PassWord");
    //    var password = Console.ReadLine();
    //    var account = Account.Create(email, password);

    //    Console.WriteLine("Input Contact Type (Email, Phone, Mobile):");
    //    var contactTypeStr = Console.ReadLine();
    //    ContactType contactType;
    //    if (contactTypeStr == "Email")
    //    {
    //        contactType = ContactType.Email; 
    //    }
    //    if (contactTypeStr == "Phone")
    //    {
    //        contactType = ContactType.Phone;
    //    }
    //    if (contactTypeStr == "Mobile")
    //    {
    //        contactType = ContactType.Mobile;
    //    }
    //    else
    //    {
    //        contactType = ContactType.Email;
    //        Console.WriteLine("Invalid contact type. Defaulting to Email.");
    //    }
    //    Console.WriteLine("Imput contact");
    //    string contactValue = Console.ReadLine();

    //    var contact = Contact.CreateContact(contactType, contactValue);

    //    var client = Client.CreateClient(name, account, contact, true, new List<FavoriteProperties>(), new List<Rating>(), new List<Comment>(), new List<Visit>());

    //    _administrativeUsersServices.CreateClient(client);
    //}


    public void GetAllClients()
    {


        var clients = _administrativeUsersServices.GetAllClients();
        foreach (var client in clients)
        {
            Console.WriteLine($" Name: {client.Id} {client.Name.FirstName} {client.Name.LastName}");
        }
    }
}

