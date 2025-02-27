using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Interfaces;
using static System.Net.Mime.MediaTypeNames;

namespace Assembly.RealEstateManagement.ConsoleApp.UserInterface;

internal class Start
{
    //private readonly IAgentService _agentService;
    //private readonly IAgentRepository _agentRepository;
    private readonly IManagerService _managerService;
   


    public Start(/*IAgentService agentService, IAgentRepository agentRepository,*/ IManagerService managerService)
    {
        //_agentService = agentService;
        //_agentRepository = agentRepository;
        _managerService = managerService;
       
    }

    public void Run()
    {
        var managerDemo = Manager.Create(100, Name.Create("Bruno", new string[] { "Miguel" }, "Roma"), Account.Create("bruno@gmail.com", "12345"),
           Address.Create("Rua x", 5, "1562-958", "Lisboa", "Portugal"), 25, new List<ManagerAllContact>(), new List<ManagerPersonalContact>(),
           new List<Agent>());

        //var agentDemo = Agent.Create(Name.Create("Bruno", new string[] {"Miguel"}, "Roma"), Account.Create("bruno@gmail.com", "12345"),
        //    Address.Create("Rua x", 5, "1562-958", "Lisboa", "Portugal"), 7, 30, new List<AgentPersonalContact>(), new List<Property>(),
        //    new List<AgentAllContact>())

       

        _managerService.Add(managerDemo);

        foreach (var user in _managerService.GetManagers())
        {
            Console.WriteLine(user.Name.FirstName);
        }

        //// Login

        //Console.WriteLine("1. Admin panel");
        //Console.WriteLine("2. User panel");
        //string choice = Console.ReadLine();

        //switch (choice)
        //{
        //    case "1":
        //        new AdminPanel(_userRepository).Run();
        //        break;
        //    case "2":
        //        new Front(_userRepository).Run();
        //        break;
        //    default:
        //        break;
        //}

    }
}
