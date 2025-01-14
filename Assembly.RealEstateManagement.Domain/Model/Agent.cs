using System.Linq.Expressions;
using Assembly.RealEstateManagement.Domain.Enums;

namespace Assembly.RealEstateManagement.Domain.Model;

public class Agent : Employee
{
    public int AgentNumber { get; private set; }
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

  
    private Agent(Name name, Account account, Contact contact, Address address, int employeeNumber) : base(name, account, contact, address, employeeNumber)
    {

        AgentNumber = 0;
        ManagedProperties = new List<Property>();
        Visits = new List<Visit>();
        Contacts = new List<Contact>();
    }

    private Agent(Name name, Account account, Contact contact, Address address, int employeeNumber, int agentNumber) : this(name, account, contact, address, employeeNumber)
    {
        ValidateAgentInfo(agentNumber, name, account, contact, address);

        AgentNumber = agentNumber;

    }
    private Agent(Name name, Account account, Contact contact, Address address, int employeeNumber, int agentNumber, List<Property> managedProperties, List<Visit> visits, List<Contact> contacts) :
        base(name, account, contact, address, employeeNumber)
    {
        ValidateAgentInfo(agentNumber, name, account, contact, address);
        AgentNumber = agentNumber;
        ManagedProperties = managedProperties ?? new List<Property>();
        Visits = visits ?? new List<Visit>();
        Contacts = contacts ?? new List<Contact>();
    }

    public static Agent CreateAgent(Name name, Account account, Contact contact, Address address, int employeeNumber, int agentNumber)
    {
        return new Agent(name, account, contact, address, employeeNumber, agentNumber);
    }

    private void ValidateAgentInfo(int agentNumber, Name name, Account account, Contact contact, Address address /*List<Property> managedProperties, List<Visit> visits, List<Contact> contacts*/)
    {
        if (agentNumber <= 0)
        {
            throw new ArgumentException(nameof(agentNumber), "Agent number must be greater than zero.");
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
        //if (managedProperties == null || managedProperties.Count == 0)
        //{
        //    throw new ArgumentNullException(nameof(managedProperties), "Managed properties list is required.");
        //}
        //if (visits == null || visits.Count == 0)
        //{ 
        //    throw new ArgumentNullException(nameof(visits), "Visits list is required.");
        //}
        //if (contacts == null || contacts.Count == 0)
        //{ 
        //    throw new ArgumentNullException(nameof(contacts), "Contacts list is required.");
        //}
    }

    private void ValidateVisitDate(DateTime visitDate)
    {
        foreach (var exitingVisit in Visits)
        {
            if (exitingVisit.VisitDate == visitDate)
            {
                throw new InvalidOperationException("A visit is already scheduled for this time.");
            }
        }
    }

    private void ValidateContactValue(string value)
    {
        foreach (var exxistingContact in Contacts)
        {
            if(exxistingContact.Value == value)
            {
                throw new InvalidOperationException("This contact already exists.");
            }
        }
    }
 
    public void AddContact(Contact contact)
    {
        if (contact == null)
        {
            throw new ArgumentNullException(nameof(contact), "Visit cannot be null.");
        }
        ValidateContactValue(contact.Value);
        Contacts.Add(contact);
    }
    public void AddVisit(Visit visit)
    {
        if (visit == null)
        {
            throw new ArgumentNullException(nameof(visit), "Visit cannot be null.");
        }
        ValidateVisitDate(visit.VisitDate);
        Visits.Add(visit);
    }
    public void EditProperty(Property property)
    {
        if (property == null)
        {
            throw new ArgumentNullException(nameof(property));
        }

        bool existingProperty = false;

        foreach (var managedProperty in ManagedProperties)
        {
            if (managedProperty.Id == property.Id)
            {
                managedProperty.UpdateProperty(property);
                existingProperty = true;
                break;
            }
        }

        if (!existingProperty)
        {
            throw new InvalidOperationException("Property cannot be edited because it is not managed by this agent.");
        }


    }
    public void AddProperty(Property property)
    {
        if (property == null)
        {
            throw new ArgumentNullException(nameof(property), "Property cannot be null");
        }

        foreach (var managedProperty in ManagedProperties)
        {
            if (managedProperty.Id == property.Id)
            {
                throw new InvalidOperationException("Property is already managed by this agent.");
            }
        }

        ManagedProperties.Add(property);

    }

    public void DeleteProperty(Property property)
    {
        if (property == null)
        {
            throw new ArgumentNullException(nameof(property), "Property cannot be null.");
        }

        bool existingProperty = false;
        foreach (var managedProperty in ManagedProperties)
        {
            if (managedProperty.Id == property.Id)
            {
                ManagedProperties.Remove(managedProperty);
                existingProperty = true;
                break;
            }
        }

        if (!existingProperty)
        {
            throw new InvalidOperationException("Property cannot be deleted because it is not managed by this agent.");
        }

    }

    public void MarkAvailabilityProperty(Property property, Availability availability)
    {
        if (property == null)
        {
            throw new ArgumentNullException(nameof(property), "Property cannot be null.");
        }
        bool existingProperty = false;
        foreach (var managedProperty in ManagedProperties)
        {
            if (managedProperty.Id == property.Id)
            {
                managedProperty.UpdateAvailability(availability);
                existingProperty = true;
                break;
            }
        }
        if (!existingProperty)
        {
            {
                throw new InvalidOperationException("Property cannot be updated because it is not managed by this agent.");
            }
        }

    }

    public void UpdateAgentInfo(int agentNumber, Name name, Account account, Contact contact, Address address)
    {
        ValidateAgentInfo(agentNumber, name, account, contact, address);
        AgentNumber = agentNumber;
        Name.UpdateName(name.FirstName, name.MiddleNames, name.LastName);
        Account.UpdateEmailAndPassword(account.Email, account.Password);
        Contact.UpdateContact(contact);
        Address.UpdateAddress(address.Street, address.Number, address.PostalCode, address.City, address.Country);

    }

    



}


