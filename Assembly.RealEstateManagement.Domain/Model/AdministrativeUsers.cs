namespace Assembly.RealEstateManagement.Domain.Model;

public class AdministrativeUsers : Employee
{
    public int AdministrativeNumber { get;  private set; }

    public List<Client> Clients { get; private set; }

    public List<Employee> Employees { get; private set; }

    private AdministrativeUsers()
    { 
      AdministrativeNumber = 0;
      Clients = new List<Client>();
      Employees = new List<Employee>();
    }

    private AdministrativeUsers(Name name, Account account, Contact contact, Address address, int employeeNumber , int administrativeNumber, List<Client> clients, 
        List<Employee> employees)
        : base(name , account, contact, address, employeeNumber)
    {
        ValidateAdministrativeUsers(administrativeNumber, clients, employees);
        AdministrativeNumber = administrativeNumber;
        Clients = clients ?? new List<Client>();
        Employees = employees ?? new List<Employee>();
    }
   

    public static AdministrativeUsers CreateAdministrativeUser(Name name, Account account, Contact contact, Address address, int employeeNumber,
        int administrativeNumber, List<Client> clients, List<Employee> employees)
    { 
        return new AdministrativeUsers(name, account, contact, address, employeeNumber, administrativeNumber, clients, employees);
    }

    public void UpdateAdministrativeUser(Name name, Account account, Contact contact, Address address, int employeeNumber,
        int administrativeNumber, List<Client> clients, List<Employee> employees)
    {
        ValidateAdministrativeUsers(administrativeNumber, clients, employees);
        Name.UpdateName(name.FirstName, name.MiddleNames, name.LastName);
        Account.UpdateEmailAndPassword(account.Email, account.Password);
        Contact.UpdateContact(contact);
        Address.UpdateAddress(address.Street, address.Number, address.PostalCode, address.City, address.Country);
        EmployeeNumber = employeeNumber;
        AdministrativeNumber = administrativeNumber;
        Clients = clients;
        Employees = employees;
    }

    public void CreateClient(Client client)
{
    if (client == null)
    {
        throw new ArgumentNullException("All client information is required.");
    }

    var newClient = Client.CreateClient(client.Name, client.Account, client.Contact, client.IsRegistered,
        client.FavoriteProperties, client.Ratings, client.Comments, client.Visits);
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
   
    public void ManageClientInfo(Client client)
    {
        if (client == null)
        {
            throw new ArgumentNullException(nameof(client), "client is required.");
        }
        client.UpdateClient(client.Name, client.Account, client.Contact, client.IsRegistered,
        client.FavoriteProperties, client.Ratings, client.Comments, client.Visits);

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


    private void ValidateAdministrativeUsers(int adminNumber, List<Client> clients, List<Employee> employees)
    {
        if (adminNumber <= 0)
        {
            throw new ArgumentException(nameof(adminNumber), "Agent number must be greater than zero.");
        }
        if (clients == null)
        {
            throw new ArgumentNullException(nameof(clients), "Clients cannot be null.");
        }
        if (employees == null)
        {
            throw new ArgumentNullException(nameof(employees), "Employees cannot be null.");
        }
    }

}


