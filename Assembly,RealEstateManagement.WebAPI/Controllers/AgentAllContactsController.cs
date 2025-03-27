using Assembly.RealEstateManagement.Services.Dtos.Agent;
using Assembly.RealEstateManagement.Services.Dtos.Manager;
using Assembly.RealEstateManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Assembly_RealEstateManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgentAllContactsController : BaseController
    {
        private readonly IAgentAllContactsServices _agentAllContactsServices;

        private AgentAllContactsController(IAgentAllContactsServices agentAllContactsServices)
        {
            _agentAllContactsServices = agentAllContactsServices;
        }

        [HttpGet]
        public IEnumerable<AgentAllContactsDto> Get()
        {
            return _agentAllContactsServices.GetAgentAllContacts();
        }
        [HttpPost]

        public ActionResult<AgentAllContactsDto> Add(CreateAgentAllContactsDto agentAllContact)
        {
            return Ok(_agentAllContactsServices.Add(agentAllContact));
        }

        [HttpPut]

        public ActionResult<AgentAllContactsDto> Update(CreateAgentAllContactsDto agentAllContact)
        {
            return BadRequest();
        }

        [HttpDelete]

        public ActionResult<AgentAllContactsDto> Delete(CreateAgentAllContactsDto agentAllContact)
        {
            return Ok();
        }
    }
}
