using Assembly.RealEstateManagement.Services.Dtos.AdministrativeUsers;
using Assembly.RealEstateManagement.Services.Dtos.Agent;
using Assembly.RealEstateManagement.Services.Dtos.Manager;
using Assembly.RealEstateManagement.Services.Interfaces;
using Assembly.RealEstateManagement.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assembly_RealEstateManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManagerAllContactsController : BaseController
    {
        private readonly IManagerAllContactsServices _managerAllContactsServices;

        public ManagerAllContactsController(IManagerAllContactsServices managerAllContactsServices) 
        {
            _managerAllContactsServices = managerAllContactsServices;
        }

        [HttpGet]
        public IEnumerable<ManagerAllContactsDto> Get()
        {
            return _managerAllContactsServices.GetManagerAllContacts();
        }

        [HttpGet]
        [Route("GetAllContactsByManagerId/{id:int}")]

        public ActionResult<ManagerAllContactsDto> GetAllContactsByManagerId([FromRoute] int id)
        {
            return Ok(_managerAllContactsServices.GetAllContactsByManagerId(id));
        }

        [HttpPost]

        public ActionResult<ManagerAllContactsDto> Add(CreateManagerAllContactsDto managerAllContact)
        {
            return Ok(_managerAllContactsServices.Add(managerAllContact));
        }

        [HttpPut("{id:int}")]
        public ActionResult<ManagerDto> Update(
        [FromRoute] int id,
        [FromBody] UpdateManagerAllContactsDto managerAllContacts)
        {
            if (id != managerAllContacts.Id)
            {
                return BadRequest("IDs must match");
            }

            return Ok(_managerAllContactsServices.Update(managerAllContacts));
        }

        [HttpDelete]

        public ActionResult<ManagerAllContactsDto> Delete(CreateManagerAllContactsDto managerAllContact)
        {
            return Ok();
        }

    }
}
