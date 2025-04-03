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
    public class AdministrativeUserAllContactsController : BaseController
    {
        private readonly IAdministrativeUsersAllContactsServices _administrativeUsersAllContactsServices;

        public AdministrativeUserAllContactsController(IAdministrativeUsersAllContactsServices administrativeUsersAllContactsServices)
        {
            _administrativeUsersAllContactsServices = administrativeUsersAllContactsServices;
        }

        [HttpGet]
        public IEnumerable<AdministrativeUsersAllContactsDto> Get()
        {
            return _administrativeUsersAllContactsServices.GetAdministrativeUserAllContacts();
        }

        [HttpGet]
        [Route("GetAllContactsByAdministrativeUserId/{id:int}")]

        public ActionResult<AdministrativeUsersAllContactsDto> GetAllContactsByAdministrativeUserId([FromRoute] int id)
        {
            return Ok(_administrativeUsersAllContactsServices.GetContactsByAdministrativeUserId(id));
        }

        [HttpPost]

        public ActionResult<AdministrativeUsersAllContactsDto> Add(CreateAdministrativeUserAllContactsDto administrativeUsersAllContact)
        {
            return Ok(_administrativeUsersAllContactsServices.Add(administrativeUsersAllContact));
        }

        [HttpPut]

        public ActionResult<AdministrativeUsersAllContactsDto> Update(CreateAdministrativeUserAllContactsDto administrativeUsersAllContact)
        {
            return BadRequest();
        }

        [HttpDelete]

        public ActionResult<AdministrativeUsersAllContactsDto> Delete(CreateAdministrativeUserAllContactsDto administrativeUsersAllContact)
        {
            return Ok();
        }
    }
}
