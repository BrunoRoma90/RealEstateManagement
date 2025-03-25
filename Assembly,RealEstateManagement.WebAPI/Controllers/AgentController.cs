using Assembly.RealEstateManagement.Services.Dtos;
using Assembly.RealEstateManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Assembly_RealEstateManagement.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AgentController : BaseController
{
    private readonly IAgentService _agentService;

    public AgentController(IAgentService agentService)
    {
        _agentService = agentService;
    }


    [HttpGet]
    public IEnumerable<AgentDto> Get()
    {
        return _agentService.GetAgents();
    }

    [HttpPost]

    public ActionResult<AgentDto> Add(CreateAgentDto agent)
    {
        return Ok(_agentService.Add(agent));
    }

    [HttpPut]

    public ActionResult<ManagerDto> Update(CreateManagerDto manager)
    {
        return BadRequest();
    }

    [HttpDelete]

    public ActionResult<ManagerDto> Delete(CreateManagerDto manager)
    {
        return Ok();
    }
}
