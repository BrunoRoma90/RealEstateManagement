using Assembly.RealEstateManagement.Domain.Interfaces;

namespace Assembly.RealEstateManagement.Domain.Model;

public class Manager : Employee, IManager
{
    public int ManagerNumber { get; private set; }
    public List<Agent> ManagedAgents { get; private set; }
    private Manager()
    {
        ManagerNumber = 0;
        ManagedAgents = new List<Agent>();
    }
    private Manager(Name name, Account account, Contact contact, Address address, int employeeNumber, int managedNumber, List<Agent> managedAgents)
        : base(name, account, contact, address, employeeNumber)
    {
        ValidateManagerInfo(managedNumber, managedAgents);
        ManagerNumber = managedNumber;
        ManagedAgents = managedAgents;

    }

    

    public static Manager CreateManager(Manager manager)
    {
        return new Manager(manager.Name, manager.Account, manager.Contact, manager.Address, manager.EmployeeNumber, manager.ManagerNumber, manager.ManagedAgents);
    }

    public void UpdateManager(Manager manager)
    {
        ValidateManagerInfo(manager.ManagerNumber, manager.ManagedAgents);
        ManagerNumber = manager.ManagerNumber;
        ManagedAgents = manager.ManagedAgents;
        EmployeeNumber = manager.EmployeeNumber;
        Name.UpdateName(manager.Name.FirstName, manager.Name.MiddleNames, manager.Name.LastName);
        Account.UpdateEmailAndPassword(manager.Account.Email, manager.Account.Password);
        Contact.UpdateContact(manager.Contact);
        Address.UpdateAddress(manager.Address.Street, manager.Address.Number, Address.PostalCode, manager.Address.City, manager.Address.Country);

        
    }


    // Não sei se estes métodos deviam ser nos Services?
    public void ReassignSingleProperty(Property property, Agent fromAgent, Agent toAgent)
    {
        if (property == null)
        {
            throw new ArgumentNullException(nameof(property), "Property cannot be null.");
        }
        if (fromAgent == null)
        {
            throw new ArgumentNullException(nameof(fromAgent), "From Agent cannot be null");
        }
        if (toAgent == null)
        {
            throw new ArgumentNullException(nameof(toAgent), " ToAgent cannot be null");
        }

        ValidateManagedAgent(fromAgent);
        ValidateManagedAgent(toAgent);
        fromAgent.DeleteProperty(property);
        toAgent.AddProperty(property);
    }

    public void ReassignAllProperties(Agent fromAgent, Agent toAgent)
    {
        if (fromAgent == null)
        {
            throw new ArgumentNullException(nameof(fromAgent), "FromAgent cannot be null.");
        }
        if (toAgent == null)
        { 
            throw new ArgumentNullException(nameof(toAgent), "ToAgent cannot be null.");
        }

        ValidateManagedAgent(fromAgent);
        ValidateManagedAgent(toAgent);
        foreach (var property in fromAgent.ManagedProperties.ToList())
        {
            fromAgent.DeleteProperty(property);
            toAgent.AddProperty(property);
        }
    }

    public List<Visit> GetAgentCalendar(Agent agent) 
    { 
        if (agent == null)
        {
             throw new ArgumentNullException(nameof(agent), "Agent cannot be null.");
        }

        ValidateManagedAgent(agent); 
        return agent.Visits;
    }

    public void CreateAppointment(Agent agent, Visit visit)
    {
        if (agent == null)
        { throw new ArgumentNullException(nameof(agent), "Agent cannot be null."); }
        if (visit == null)
        { throw new ArgumentNullException(nameof(visit), "Visit cannot be null."); }
        ValidateManagedAgent(agent);
        agent.AddVisit(visit);
    }

    public void AddAgent(Agent agent)
    {
        if (agent == null)
        {
            throw new ArgumentNullException(nameof(agent), "Agent cannot be null.");
        }

        if (ManagedAgents.Contains(agent))
        {
            throw new InvalidOperationException("This agent is already managed by this manager.");
        }

        ManagedAgents.Add(agent);
    }

    public void RemoveAgent(Agent agent)
    {
        if (agent == null)
        {
            throw new ArgumentNullException(nameof(agent), "Agent cannot be null.");
        }

        if (!ManagedAgents.Contains(agent))
        {
            throw new InvalidOperationException("This agent is not managed by the manager.");
        }

        ManagedAgents.Remove(agent);
    }

    public List<Agent> GetAllManagedAgents()
    {
        return ManagedAgents;
    }





    private void ValidateManagerInfo(int managerNumber, List<Agent> managedAgents)
    {
        if (managedAgents == null)
        {
            throw new ArgumentException(nameof(managedAgents), "Managed Agents cannot be null.");
        }
        if (managerNumber <= 0)
        {
            throw new ArgumentException(nameof(managerNumber), "Agent number must be greater than zero.");
        }
       
    }

    private void ValidateManagedAgent(Agent agent)

    { if (!ManagedAgents.Contains(agent))
        {
            throw new InvalidOperationException("This agent is not managed by the manager.");
        }
    }
}

