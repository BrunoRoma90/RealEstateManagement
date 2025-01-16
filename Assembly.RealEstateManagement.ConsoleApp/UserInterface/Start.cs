
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
        var agent = Agent.CreateAgent(1 ,name, account, contact, address, 56, 45);

        _agentService.Add(agent);
    }


    public void GetAll()
    {
        var agents = _agentService.GetAgents();
        foreach (var agent in agents)
        {
            Console.WriteLine($" Name: {agent.Id} {agent.Name.FirstName} {agent.Name.LastName}");
        }
    }

    public void AddVisit(int agentId)
    {
        // Buscar o agente pelo ID
        var agent = _agentService.GetAgentById(agentId);

        if (agent == null)
        {
            Console.WriteLine($"No agent found with ID {agentId}.");
            return;
        }
        var name = Name.CreateName("Ana", null, "Almeida");
        var account = Account.Create("john.doe@example.com", "Password123!");
        var contact = Contact.CreateContact(ContactType.Email, "john.doe@example.com");
        var client = Client.CreateClient(name, account, contact);

        var propertyType = PropertyType.House; // Exemplo de tipo de propriedade
        var price = 10000; // Exemplo de preço
        var priceBySquareMeter = 5000; // Exemplo de preço por metro quadrado
        var sizeBySquareMeters = 200; // Exemplo de tamanho
        var description = "Beautiful 3 bedroom house in the city center.";
        var address = Address.CreateAddress("Rua da Paz", 10, "1000-100", "Lisboa", "Portugal");
        var transactionType = TransactionType.Buy; // Exemplo de transação
        var availability = Availability.ForRent; // Exemplo de disponibilidade
        var rooms = new List<Room>();
        var propertyImages = new List<PropertyImage>(); // Aqui você pode adicionar imagens
        var notes = "Mui";
       
        var createdProperty = Property.CreateProperty(propertyType, price, priceBySquareMeter, sizeBySquareMeters,
            description, address,transactionType,availability, rooms,propertyImages);
        
        // Criar uma nova visita
        var visitDate = DateTime.Now.AddDays(1); // Exemplo: visita para amanhã
        var visit = Visit.CreateVisit(createdProperty, client, agent, visitDate, notes);

        
        _agentService.AddVisit(agent, visit);

        Console.WriteLine($"Visit added for Agent ID {agent.Id} on {visitDate}.");
    }


    public List<Visit> GetMyVisits(int agentId)
    {
        // Obter o agente para recuperar as visitas
        var agent = _agentService.GetAgentById(agentId);
        if (agent == null)
        {
            Console.WriteLine($"No agent found with ID {agentId}.");
            
        }

        // Obter todas as visitas do agente
        var visits = _agentService.GetAllVisits(agent.Id);
        Console.WriteLine($"Visits for Agent ID {agent.Id}:");

        foreach (var visit in visits)
        {
            Console.WriteLine($"- Visit on {visit.VisitDate}, Client: {visit.Client.Name.FirstName}, Purpose: {visit.Agent.Name.FirstName}");
        }

        return visits;
    }

}
