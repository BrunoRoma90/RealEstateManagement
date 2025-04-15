using Assembly.RealEstateManagement.Services.Dtos.Agent;
using Assembly.RealEstateManagement.Services.Dtos.Manager;
using Assembly.RealEstateManagement.Services.Interfaces;
using Assembly.RealEstateManagement.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assembly_RealEstateManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManagerPersonalContactsController : BaseController
    {
        private readonly IManagerPersonalContactsServices _managerPersonalContactsServices;

        public ManagerPersonalContactsController(IManagerPersonalContactsServices managerPersonalContactsServices)
        {
            _managerPersonalContactsServices = managerPersonalContactsServices;
        }


        [HttpGet]
        public IEnumerable<ManagerPersonalContactDto> Get()
        {
            return _managerPersonalContactsServices.GetManagerPersonalsContacts();
        }

        [HttpGet]
        [Route("GetPersonalContactsByManagerId/{id:int}")]

        public ActionResult<ManagerPersonalContactDto> GetPersonalContactsByManagerId([FromRoute] int id)
        {
            return Ok(_managerPersonalContactsServices.GetContactsByManagerId(id));
        }

        [HttpPost]

        public ActionResult<ManagerPersonalContactDto> Add(CreateManagerPersonalContacts managerPersonalContact)
        {
            return Ok(_managerPersonalContactsServices.Add(managerPersonalContact));
        }

        [HttpPut("{id:int}")]
        public ActionResult<ManagerDto> Update(
        [FromRoute] int id,
        [FromBody] UpdateManagerPersonalContactsDto managerPersonallContacts)
        {
            if (id != managerPersonallContacts.Id)
            {
                return BadRequest("IDs must match");
            }

            return Ok(_managerPersonalContactsServices.Update(managerPersonallContacts));
        }

        [HttpDelete]

        public ActionResult<ManagerPersonalContactDto> Delete(CreateManagerPersonalContacts managerPersonalContact)
        {
            return Ok();
        }
    }
}
