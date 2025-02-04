﻿
namespace Assembly.RealEstateManagement.Domain.Model;

public class Agent : Employee
{
    public int AgentNumber { get; private set; }
    public List<Property> ManagedProperties { get; private set; }
    public List<Visit> Visits { get; private set; }
    public List<Contact> Contacts { get; private set; }

    public Manager Manager { get; private set; }

    private Agent()
    {
        Id = 0;
        AgentNumber = 0;
        ManagedProperties = new List<Property>();
        Visits = new List<Visit>();
        Contacts = new List<Contact>();
        Manager = Manager.CreateManager(Name.CreateName(string.Empty, Array.Empty<string>(), string.Empty),
            Account.Create(string.Empty, string.Empty),
            Contact.CreateContact(default, string.Empty),
            Address.CreateAddress(string.Empty, 0, string.Empty, string.Empty, string.Empty), 
            0,   0, new List<Agent>());

    }


    private Agent(int id, Name name, Account account, Contact contact, Address address, int employeeNumber, int agentNumber,
        List<Property> managedProperties, List<Visit> visits, List<Contact> contacts, Manager manager)
        : base(name, account, contact, address, employeeNumber)
    {
        ValidateAgent(id ,agentNumber, managedProperties, visits, contacts);
        Id = id;
        AgentNumber = agentNumber;
        ManagedProperties = managedProperties ?? new List<Property>();
        Visits = visits ?? new List<Visit>();
        Contacts = contacts ?? new List<Contact>();
        Manager = manager;
    }
    

    public static Agent CreateAgent(int id, Name name, Account account, Contact contact, Address address, int employeeNumber, int agentNumber,
        List<Property> managedProperties, List<Visit> visits, List<Contact> contacts, Manager manager)
    {
        return new Agent(id ,name, account, contact, address, employeeNumber, agentNumber, managedProperties, visits, contacts, manager);
    }

    public void UpdateAgent(int id, int agentNumber, Name name, Account account, Contact contact, Address address, int employeeNumber, List<Property> managedProperties, List<Visit> visits, List<Contact> contacts)
    {
        ValidateAgent(id, agentNumber, managedProperties, visits, contacts);
        Id = id;
        AgentNumber = agentNumber;
        ManagedProperties = managedProperties;
        EmployeeNumber = employeeNumber;
        Visits = visits;
        Contacts = contacts;
        Name.UpdateName(name.FirstName, name.MiddleNames, name.LastName);
        Account.UpdateEmailAndPassword(account.Email, account.Password);
        Contact.UpdateContact(contact);
        Address.UpdateAddress(address.Street, address.Number, address.PostalCode, address.City, address.Country);

    }

    private void ValidateAgent(int id, int agentNumber, List<Property> managedProperties, List<Visit> visits, List<Contact> contacts)
    {
        if(id <= 0)
        {
            throw new ArgumentException(nameof(agentNumber), "Id must be greater than zero.");
        }
        if (agentNumber <= 0)
        {
            throw new ArgumentException(nameof(agentNumber), "Agent number must be greater than zero.");
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
 

    // Não sei se estes metodos deviam estar nos services
    public void AddContact(Contact contact)
    {
        if (contact == null)
        {
            throw new ArgumentNullException(nameof(contact), "Contact cannot be null.");
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


    public void DeleteVisitToMyList(Visit visit)
    {
        if (visit == null)
        {
            throw new ArgumentNullException(nameof(visit), "Property cannot be null.");
        }

        bool existingVisit = false;
        foreach (var myVisit in Visits)
        {
            if (myVisit.Id == visit.Id)
            {
                Visits.Remove(myVisit);
                existingVisit = true;
                break;
            }
        }

        if (!existingVisit)
        {
            throw new InvalidOperationException("existingVisit cannot be deleted because it is not this agent.");
        }

    }

    public void DeleteContactToMyList(Contact contact)
    {
        if (contact == null)
        {
            throw new ArgumentNullException(nameof(contact), "Contact cannot be null.");
        }

        bool existingContact = false;
        foreach (var listContact in Contacts)
        {
            if (listContact.Id == contact.Id)
            {
                Contacts.Remove(listContact);
                existingContact = true;
                break;
            }
        }

        if (!existingContact)
        {
            throw new InvalidOperationException("Property cannot be deleted because it is not managed by this agent.");
        }
    }








}


