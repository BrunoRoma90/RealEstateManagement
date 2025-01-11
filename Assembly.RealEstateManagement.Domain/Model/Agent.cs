namespace Assembly.RealEstateManagement.Domain.Model;

public class Agent : Employee
{
    public int AgentNumber {  get; private set; }
    public List<Property> ManagedProperties { get; private set; }
    public List<Visit> Visits { get; private set; }

    public List<Contact> Contacts { get; private set; }

    private Agent()
    {
        AgentNumber = 0;
        ManagedProperties = new List<Property>();
        Visits = new List<Visit>();
        Contacts = new List<Contact>();
        
    }
    private Agent(Name name, Account account, Contact contact, Address address , int employeeNumber) : base(name, account, contact, address, employeeNumber) 
    {
        AgentNumber = 0;
        ManagedProperties = new List<Property>();
        Visits = new List<Visit>();
        Contacts = new List<Contact>();
    }

    private Agent(Name name, Account account, Contact contact, Address address, int employeeNumber,int agentNumber) : this(name, account, contact, address, employeeNumber)
    {   
        AgentNumber = agentNumber;
        
    }
    private Agent(Name name, Account account, Contact contact, Address address , int employeeNumber ,int agentNumber, List<Property> managedProperties, List<Visit> visits, List<Contact> contacts):
        base(name, account, contact, address, employeeNumber)
    {
        
        AgentNumber = agentNumber;
        ManagedProperties = managedProperties ?? new List<Property>();
        Visits = visits ?? new List<Visit>();
        Contacts = contacts ?? new List<Contact>();
    }

    public static Agent CreateAgent(Name name, Account account, Contact contact, Address address, int employeeNumber, int agentNumber)
    {
        return new Agent(name, account, contact, address, employeeNumber, agentNumber);
    }

    private void ValidateAgentInfo(int agentNumber, List<Property> managedProperties, List<Visit> visits, List<Contact> contacts) 
    {
        if (agentNumber <= 0)
        { 
            throw new ArgumentException(nameof(agentNumber) ,"Agent number must be greater than zero.");
        }
        if (managedProperties == null || managedProperties.Count == 0)
        {
            throw new ArgumentNullException(nameof(managedProperties), "Managed properties list is required.");
        }
        if (visits == null || visits.Count == 0)
        { 
            throw new ArgumentNullException(nameof(visits), "Visits list is required.");
        }
        if (contacts == null || contacts.Count == 0)
        { 
            throw new ArgumentNullException(nameof(contacts), "Contacts list is required.");
        }
    }



    public void AddProperty(Property property) 
    {
        if (property == null)
        {  
            throw new ArgumentNullException(nameof(property), "Property cannot be null");
        }
        ManagedProperties.Add(property);
          
    }



    

}


