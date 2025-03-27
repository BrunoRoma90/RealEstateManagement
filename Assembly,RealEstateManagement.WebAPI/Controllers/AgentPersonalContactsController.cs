using Assembly.RealEstateManagement.Services.Dtos.Agent;
using Assembly.RealEstateManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Assembly_RealEstateManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgentPersonalContactsController : BaseController
    {
        private readonly IAgentPersonalContactsServices _agentPersonalContactsServices;

        public AgentPersonalContactsController(IAgentPersonalContactsServices agentPersonalContactsServices)
        {
            _agentPersonalContactsServices = agentPersonalContactsServices;
        }


        [HttpGet]
        public IEnumerable<AgentPersonalContactsDto> Get()
        {
            return _agentPersonalContactsServices.GetAgentPersonalsContacts();
        }
        [HttpPost]

        public ActionResult<AgentPersonalContactsDto> Add(CreateAgentPersonalContactsDto agentPersonalContact)
        {
            return Ok(_agentPersonalContactsServices.Add(agentPersonalContact));
        }

        [HttpPut]

        public ActionResult<AgentPersonalContactsDto> Update(CreateAgentPersonalContactsDto agentPersonalContact)
        {
            return BadRequest();
        }

        [HttpDelete]

        public ActionResult<AgentPersonalContactsDto> Delete(CreateAgentPersonalContactsDto agentPersonalContact)
        {
            return Ok();
        }
    }
}
