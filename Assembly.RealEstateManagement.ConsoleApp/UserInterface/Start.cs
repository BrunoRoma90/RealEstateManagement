
using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Services.Interfaces;
using Assembly.RealEstateManagement.Domain.Enums;

namespace Assembly.RealEstateManagement.ConsoleApp.UserInterface;

internal class Start
{
    private readonly IAgentService _agentService;
    private readonly IAgentRepository _agentRepository;

    public Start(IAgentService agentService, IAgentRepository agentRepository)
    {
        _agentService = agentService;
        _agentRepository = agentRepository;
    }


    public void Create()
    {
        var name = Name.CreateName("Bruno", null, "Roma");
        var account = Account.Create("john.doe@example.com", "Password123!");
        var contact = Contact.CreateContact(ContactType.Email, "john.doe@example.com");
        var address = Address.CreateAddress("Rua", 4, "126-528", "Lisboa" , "Portugal");
        var agent = Agent.CreateAgent(name, account, contact, address, 56, 45);

        _agentService.Add(agent);
    }


    public void GetAll()
    {
        var agents = _agentService.GetAgents();
        foreach (var agent in agents)
        {
            Console.WriteLine($" Name: {agent.Name.FirstName} {agent.Name.LastName}");
        }
    }

}
