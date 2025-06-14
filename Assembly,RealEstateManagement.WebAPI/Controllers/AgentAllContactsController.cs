﻿using Assembly.RealEstateManagement.Services.Dtos.AdministrativeUsers;
using Assembly.RealEstateManagement.Services.Dtos.Agent;
using Assembly.RealEstateManagement.Services.Dtos.Manager;
using Assembly.RealEstateManagement.Services.Interfaces;
using Assembly.RealEstateManagement.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assembly_RealEstateManagement.WebAPI.Controllers
{
    [Authorize(Roles = "Agent")]
    [ApiController]
    [Route("api/[controller]")]
    public class AgentAllContactsController : BaseController
    {
        private readonly IAgentAllContactsServices _agentAllContactsServices;

        public AgentAllContactsController(IAgentAllContactsServices agentAllContactsServices)
        {
            _agentAllContactsServices = agentAllContactsServices;
        }

        [HttpGet]
        public IEnumerable<AgentAllContactsDto> Get()
        {
            return _agentAllContactsServices.GetAgentAllContacts();
        }

        [HttpGet]
        [Route("GetAllContactsByAgentId/{id:int}")]

        public ActionResult<AgentAllContactsDto> GetAllContactsByAgentId([FromRoute] int id)
        {
            return Ok(_agentAllContactsServices.GetContactsByAgentId(id));
        }

        [HttpPost]

        public ActionResult<AgentAllContactsDto> Add(CreateAgentAllContactsDto agentAllContact)
        {
            return Ok(_agentAllContactsServices.Add(agentAllContact));
        }

        [HttpPut("{id:int}")]
        public ActionResult<AgentDto> Update(
        [FromRoute] int id,
        [FromBody] UpdateAgentAllContactsDto agentAllContacts)
        {
            if (id != agentAllContacts.Id)
            {
                return BadRequest("IDs must match");
            }

            return Ok(_agentAllContactsServices.Update(agentAllContacts));
        }

        [HttpDelete]

        public ActionResult<AgentAllContactsDto> Delete(CreateAgentAllContactsDto agentAllContact)
        {
            return Ok();
        }
    }
}
