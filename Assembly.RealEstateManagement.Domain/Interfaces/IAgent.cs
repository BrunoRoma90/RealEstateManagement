using Assembly.RealEstateManagement.Domain.Enums;
using Assembly.RealEstateManagement.Domain.Model;

namespace Assembly.RealEstateManagement.Domain.Interfaces;

public interface IAgent
{
    int AgentNumber { get; }
    List<Property> ManagedProperties { get; }
    List<Visit> Visits { get; }
    List<Contact> Contacts { get; }

    public void AddContact(Contact contact);

    public void AddVisit(Visit visit);

    public void EditProperty(Property property);

    public void AddProperty(Property property);


    public void DeleteProperty(Property property);


    public void MarkAvailabilityProperty(Property property, Availability availability);


    public void UpdateAgentInfo(int agentNumber, Name name, Account account, Contact contact, Address address);



}


