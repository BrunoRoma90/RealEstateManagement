
using Assembly.RealEstateManagement.Data;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;

Console.WriteLine("Hello, World!");


var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // Define diretório base
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) // Lê connection string
            .Build();

// 🔹 Configuração dos serviços (DI)
var services = new ServiceCollection();

// Adiciona a camada de Data (já inclui ApplicationDbContext e os Repositórios)
services.AddData(configuration);

// 🔹 Construir o ServiceProvider
using var serviceProvider = services.BuildServiceProvider();

// 🔹 Obter o repositório e inserir um Agent
var managerRepository = serviceProvider.GetRequiredService<IManagerRepository>();
var agentRepository = serviceProvider.GetRequiredService<IAgentRepository>();



//Console.Write("Input First Name: ");
//var firstNameManager = Console.ReadLine();

//Console.Write("Input Middle Names (comma separated, or leave empty): ");
//var middleNamesManager = Console.ReadLine()?.Split(',') ?? Array.Empty<string>();

//Console.Write("Input Last Name: ");
//var lastNameManager = Console.ReadLine();

//// Criar o objeto Name
//var nameManager = Name.Create(firstNameManager, middleNamesManager, lastNameManager);

//Console.Write("Input Email: ");
//var emailManager = Console.ReadLine();

//Console.Write("Input Password: ");
//var passwordManager = Console.ReadLine();

//// Criar a conta
//var accountManager = Account.Create(emailManager, passwordManager);

//Console.Write("Input street: ");
//var streetManager = Console.ReadLine();

//Console.Write("Input number: ");
//int numberManager = Convert.ToInt32(Console.ReadLine());

//Console.Write("Input postalCode: ");
//var postaCodeManager = Console.ReadLine();

//Console.Write("Input City: ");
//var cityManager = Console.ReadLine();

//Console.Write("Input Country: ");
//var countryManager = Console.ReadLine();


//var addressManager = Address.Create(streetManager, numberManager, postaCodeManager, cityManager, countryManager);





//Console.Write("Input Manager Number: ");
//if (!int.TryParse(Console.ReadLine(), out int managerNumber))
//{
//    Console.WriteLine("Invalid number. Operation cancelled.");
//    return;
//}

//Console.Write("Input Employee Number: ");
//if (!int.TryParse(Console.ReadLine(), out int employeeNumber2))
//{
//    Console.WriteLine("Invalid number. Operation cancelled.");
//    return;
//}


//var newManager = Manager.Create(employeeNumber2, nameManager, accountManager, addressManager, managerNumber,
//    new List<ManagerAllContact>(), new List<ManagerPersonalContact>(), new List<Agent>());

//managerRepository.Add(newManager);

//Console.Write("Input First Name: ");
//var firstName = Console.ReadLine();

//Console.Write("Input Middle Names (comma separated, or leave empty): ");
//var middleNames = Console.ReadLine()?.Split(',') ?? Array.Empty<string>();

//Console.Write("Input Last Name: ");
//var lastName = Console.ReadLine();

//// Criar o objeto Name
//var name = Name.Create(firstName, middleNames, lastName);

//Console.Write("Input Email: ");
//var email = Console.ReadLine();

//Console.Write("Input Password: ");
//var password = Console.ReadLine();

//// Criar a conta
//var account = Account.Create(email, password);

//Console.Write("Input street: ");
//var street = Console.ReadLine();

//Console.Write("Input number: ");
//int number = Convert.ToInt32(Console.ReadLine());

//Console.Write("Input postalCode: ");
//var postaCode = Console.ReadLine();

//Console.Write("Input City: ");
//var city = Console.ReadLine();

//Console.Write("Input Country: ");
//var country = Console.ReadLine();


//var address = Address.Create(street, number, postaCode, city, country);





//Console.Write("Input Agent Number: ");
//if (!int.TryParse(Console.ReadLine(), out int agentNumber))
//{
//    Console.WriteLine("Invalid number. Operation cancelled.");
//    return;
//}

//Console.Write("Input Employee Number: ");
//if (!int.TryParse(Console.ReadLine(), out int employeeNumber))
//{
//    Console.WriteLine("Invalid number. Operation cancelled.");
//    return;
//}

//// Criar o agente
//var newAgent = Agent.Create(
//    name,
//    account,
//   address,
//     agentNumber,
//    employeeNumber,
//    new List<AgentPersonalContact>(),
//    new List<Property>(),
//    new List<AgentAllContact>(),
//    newManager // Caso não tenha um Manager, pode ser null
//);

//// Adicionar o agente ao repositório
//agentRepository.Add(newAgent);


//Console.WriteLine($"✅ Agente {newAgent.Name.FullName} (Agente {newAgent.AgentNumber}) adicionado com sucesso!");

////Update
//Console.Write("Input AccountId: ");
//int accountId = Convert.ToInt32(Console.ReadLine());
//var account = accountRepository.GetById(accountId);

//Console.WriteLine("Dados atuais:");
//Console.WriteLine($"Account: {account.Id} {account.Email}");


//Console.Write("Input Address: ");
//int addressId = Convert.ToInt32(Console.ReadLine());
//var address = addressRepository.GetById(addressId);
//Console.WriteLine("Dados atuais:");
//Console.WriteLine($"Address: {address.Id} {address.Street}");


//Console.Write("Input MangerId: ");
//int managerId = Convert.ToInt32(Console.ReadLine());
//var manager = managerRepository.GetById(managerId);
//Console.WriteLine("Dados atuais:");
//Console.WriteLine($"Manager: {manager.Id} {manager.Name.FullName}");

//Console.Write("Input AgentId: ");
//int agentId = Convert.ToInt32(Console.ReadLine());

//var agent = agentRepository.GetById(agentId);

//if (agent == null)
//{
//    Console.WriteLine($"Agente com ID {agentId} não encontrado.");
//    return;
//}

//// Exibe os dados atuais
//Console.WriteLine("Dados atuais:");
//Console.WriteLine($"Name: {agent.Name.FirstName} {agent.Name.LastName}");
//Console.WriteLine($"Agent Number: {agent.AgentNumber}");
//Console.WriteLine($"Email: {agent.Account.Email}");

//// Solicita os novos dados
//Console.Write("Input First Name: ");
//var firstName = Console.ReadLine();

//Console.Write("Input Middle Names (comma separated, or leave empty): ");
//var middleNames = Console.ReadLine()?.Split(',') ?? Array.Empty<string>();

//Console.Write("Input Last Name: ");
//var lastName = Console.ReadLine();

//var newName = Name.UpdateName(firstName, middleNames, lastName);

//// Agora, atualiza o nome diretamente no agente
//agent.UpdateName(newName);  // Atualiza o nome do agente com o novo nome

//// Agora, atualize diretamente o agente no repositório
//agentRepository.Update(agent);  // Atualiza o agente no banco de dados


//// Exibe a mensagem de sucesso
//Console.WriteLine($"✅ Agente {agent.Name.FirstName} {agent.Name.LastName} atualizado com sucesso!");



Console.Write("Input AgentId: ");
int agentId = Convert.ToInt32(Console.ReadLine());

var account = agentRepository.GetAgentAccount(agentId);

if (account == null)
{
    Console.WriteLine($"Nenhuma conta encontrada para o agente com ID {agentId}.");
}
else
{
    Console.WriteLine($"Conta encontrada: Email -> {account.Email}, Id -> {account.Id}");
}


var manager = agentRepository.GetManagerByAgentId(agentId);

if (manager == null)
{
    Console.WriteLine($"O agente com ID {agentId} não tem um gerente associado.");
}
else
{
    Console.WriteLine($"O gerente do agente {agentId} é {manager.Name.FullName}, ID: {manager.Id}");
}




