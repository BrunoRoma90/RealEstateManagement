using Assembly.RealEstateManagement.Services.Dtos.AdministrativeUsers;
using Assembly.RealEstateManagement.Services.Dtos.Agent;
using Assembly.RealEstateManagement.Services.Interfaces;
using Assembly.RealEstateManagement.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assembly_RealEstateManagement.WebAPI.Controllers
{
    [Authorize(Roles = "Agent")]
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

        [HttpGet]
        [Route("GetPersonalContactsByAgentId/{id:int}")]

        public ActionResult<AgentPersonalContactsDto> GetPersonalContactsByAgentId([FromRoute] int id)
        {
            return Ok(_agentPersonalContactsServices.GetPersonalContactsByAgentId(id));
        }
        [HttpPost]

        public ActionResult<AgentPersonalContactsDto> Add(CreateAgentPersonalContactsDto agentPersonalContact)
        {
            return Ok(_agentPersonalContactsServices.Add(agentPersonalContact));
        }

        [HttpPut("{id:int}")]
        public ActionResult<AgentDto> Update(
        [FromRoute] int id,
        [FromBody] UpdateAgentPersonalContactsDto agentPersonallContacts)
        {
            if (id != agentPersonallContacts.Id)
            {
                return BadRequest("IDs must match");
            }

            return Ok(_agentPersonalContactsServices.Update(agentPersonallContacts));
        }

        [HttpDelete]

        public ActionResult<AgentPersonalContactsDto> Delete(CreateAgentPersonalContactsDto agentPersonalContact)
        {
            return Ok();
        }
    }
}
