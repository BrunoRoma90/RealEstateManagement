using Assembly.RealEstateManagement.Services.Dtos.Agent;
using Assembly.RealEstateManagement.Services.Dtos.Manager;
using Assembly.RealEstateManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assembly_RealEstateManagement.WebAPI.Controllers;

[Authorize(Roles = "Manager, Agent, AdministrativeUser, Admin")]
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

    [HttpGet]
    [Route("GetById/{id:int}")]

    public ActionResult<AgentDto> GetbyId([FromRoute] int id)
    {
        return Ok(_agentService.GetAgentById(id));
    }

    [HttpPost]

    public ActionResult<AgentDto> Add(CreateAgentDto agent)
    {
        return Ok(_agentService.Add(agent));
    }

    [HttpPut("{id:int}")]
    public ActionResult<AgentDto> Update(
    [FromRoute] int id,
    [FromBody] UpdateAgentDto agent)
    {
        if (id != agent.Id)
        {
            return BadRequest("User IDs must match");
        }

        return Ok(_agentService.Update(agent));
    }

    [HttpDelete]

    public ActionResult<ManagerDto> Delete(CreateManagerDto manager)
    {
        return Ok();
    }
}
