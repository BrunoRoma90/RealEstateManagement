namespace Assembly.RealEstateManagement.Domain.Model;

public class AdministrativeUsers : Employee
{
    public int AdminNumber { get;  private set; }

    public List<Client> Clients { get; private set; }

    public List<Employee> Employees { get; private set; }

    private AdministrativeUsers()
    { 
      AdminNumber = 0;
      Clients = new List<Client>();
      Employees = new List<Employee>();
    }

    private AdministrativeUsers(Name name, Account account, Contact contact, Address address, int employeeNumber)
        : base(name , account, contact, address, employeeNumber)
    {
        AdminNumber = 0;
        Clients = new List<Client>();
        Employees = new List<Employee>();
    }
    private AdministrativeUsers(Name name, Account account, Contact contact, Address address, int employeeNumber, int adminNumber) : this(name, account, contact, address, employeeNumber)
    {
        ValidateAdministrativeUsersInfo(adminNumber, name, account, contact, address);

        AdminNumber = adminNumber;

    }




    private AdministrativeUsers(Name name, Account account, Contact contact, Address address, int employeeNumber, int adminNumber,
        List<Client> clients, List<Employee> employees)
        : base(name, account, contact, address, employeeNumber)
    {
        AdminNumber = adminNumber;
        Clients = clients ?? new List<Client>();
        Employees = employees ?? new List<Employee>();
    }

    public static AdministrativeUsers CreateAdministrativeUser(Name name, Account account, Contact contact, Address address, int employeeNumber, int adminNumber)
    { 
        return new AdministrativeUsers(name, account, contact, address, employeeNumber, adminNumber);
    }

    public void UpdateAdministrativeUserInfo(int adminNumber, Name name, Account account, Contact contact, Address address)
    {
        ValidateAdministrativeUsersInfo(adminNumber, name, account, contact, address);
        AdminNumber = adminNumber;
        Name.UpdateName(name.FirstName, name.MiddleNames, name.LastName);
        Account.UpdateEmailAndPassword(account.Email, account.Password);
        Contact.UpdateContact(contact);
        Address.UpdateAddress(address.Street, address.Number, address.PostalCode, address.City, address.Country);

    }

    public void CreateClient(Name name, Account account, Contact contact)
{
    if (name == null || account == null || contact == null)
    {
        throw new ArgumentNullException("All client information is required.");
    }

    var newClient = Client.CreateClient(name, account, contact);
    Clients.Add(newClient);
}

    public void DeleteClient(Client client)
    {
        if (client == null)
        {
            throw new ArgumentNullException(nameof(client), "Client cannot be null.");
        }
        if (!Clients.Contains(client))
        {
            throw new InvalidOperationException("Client is not in the list of managed clients.");
        }

        Clients.Remove(client);
    }

    public Client GetClientProfile(int clientId)
    {
        foreach (var client in Clients)
        {
            if (client.Id == clientId)
            {
                return client;
            }
        }

        throw new InvalidOperationException("Client not found.");
    }

    public List<Visit> GetAllVisits()
    {
        var allAppointments = new List<Visit>();

        foreach (var employee in Employees)
        {
            if (employee is Agent agent)
            {
                allAppointments.AddRange(agent.Visits);
            }
        }

        return allAppointments;
    }
   
    public void ManageClientInfo(Client client, Name newName, Account newAccount, Contact newContact, bool isRegistered)
    {
        if (client == null)
        {
            throw new ArgumentNullException(nameof(client), "Contact is required.");
        }
        client.UpdateClient(newName, newAccount, newContact, isRegistered);

    }

    public List<Visit> GetAgentCalendar(Agent agent)
    {
        if (agent == null) 
        {
            throw new ArgumentNullException(nameof(agent), "Agent is required.");
        }

       return agent.Visits;
    }

    public void CreateAgentAppointment(Agent agent, Visit visit)
    {
        if (agent == null) 
        {
            throw new ArgumentNullException(nameof(agent), "Agent is required.");
        }
        if (visit == null)
        {
            throw new ArgumentNullException(nameof(visit), "Visit is required.");
        }

        agent.AddVisit(visit);
    }

    public void DeleteAgentAppointment(Agent agent, Visit visit)
    {

        if (agent == null)
        {
            throw new ArgumentNullException(nameof(agent), "Agent is required.");
        }
        if (visit == null)
        {
            throw new ArgumentNullException(nameof(visit), "Visit is required.");
        }

        agent.Visits.Remove(visit);
    }


    private void ValidateAdministrativeUsersInfo(int adminNumber, Name name, Account account, Contact contact, Address address)
    {
        if (adminNumber <= 0)
        {
            throw new ArgumentException(nameof(adminNumber), "Agent number must be greater than zero.");
        }
        if (name == null)
        {
            throw new ArgumentNullException(nameof(name), "Name is required.");
        }
        if (account == null)
        {
            throw new ArgumentNullException(nameof(account), "Account is required.");
        }
        if (contact == null)
        {
            throw new ArgumentNullException(nameof(contact), "Contact is required.");
        }
        if (address == null)
        {
            throw new ArgumentNullException(nameof(address), "Address is required.");
        }

    }

}


