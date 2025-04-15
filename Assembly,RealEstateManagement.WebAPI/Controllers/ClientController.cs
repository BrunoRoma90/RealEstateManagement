using Assembly.RealEstateManagement.Services.Dtos.Client;
using Assembly.RealEstateManagement.Services.Dtos.Manager;
using Assembly.RealEstateManagement.Services.Dtos.Property;
using Assembly.RealEstateManagement.Services.Interfaces;
using Assembly.RealEstateManagement.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assembly_RealEstateManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : BaseController
    {
        private readonly IClientServices _clientServices;

        public ClientController(IClientServices clientServices)
        {
            _clientServices = clientServices;
        }

        [HttpGet]
        public IEnumerable<ClientDto> Get()
        {
            return _clientServices.GetClients();
        }

        [HttpGet]
        [Route("GetById/{id:int}")]
        public ActionResult<ClientDto> GetbyId([FromRoute] int id)
        {
            return Ok(_clientServices.GetClientById(id));
        }
        [HttpPost]

        public ActionResult<ClientDto> Add([FromBody] CreateClientDto client)
        {
            return Ok(_clientServices.Add(client));
        }

        [HttpPut]

        [HttpPut("{id:int}")]
        public ActionResult<ClientDto> Update(
        [FromRoute] int id,
        [FromBody] UpdateClient client)
        {
            if (id != client.Id)
            {
                return BadRequest("Client IDs must match");
            }

            return Ok(_clientServices.Update(client));
        }

        [HttpDelete]

        public ActionResult<ClientDto> Delete(CreateClientDto client)
        {
            return Ok();
        }
    }
}
