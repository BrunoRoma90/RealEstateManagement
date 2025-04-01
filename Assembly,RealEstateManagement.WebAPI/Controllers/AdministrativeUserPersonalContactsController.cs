using Assembly.RealEstateManagement.Services.Dtos.AdministrativeUsers;
using Assembly.RealEstateManagement.Services.Dtos.Manager;
using Assembly.RealEstateManagement.Services.Interfaces;
using Assembly.RealEstateManagement.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assembly_RealEstateManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdministrativeUserPersonalContactsController : BaseController
    {
        private readonly IAdministrativeUsersPersonalContactsServices _administrativeUserPersonalContactsServices;

        public AdministrativeUserPersonalContactsController(IAdministrativeUsersPersonalContactsServices administrativeUsersPersonalContactsServices)
        {
            _administrativeUserPersonalContactsServices = administrativeUsersPersonalContactsServices;
        }


        [HttpGet]
        public IEnumerable<AdministrativeUserPersonalContactDto> Get()
        {
            return _administrativeUserPersonalContactsServices.GetAdministrativeUsersPersonalsContacts();
        }

        [HttpGet]
        [Route("GetPersonalContactsByAdministrativeUserId/{id:int}")]

        public ActionResult<AdministrativeUserPersonalContactDto> GetPersonalContactsByAdministrativeUserId([FromRoute] int id)
        {
            return Ok(_administrativeUserPersonalContactsServices.GetPersonalContactsByAdministrativeUserId(id));
        }
        [HttpPost]

        public ActionResult<AdministrativeUserPersonalContactDto> Add(CreateAdministrativeUserPersonalContactDto administrativeUserPersonalContact)
        {
            return Ok(_administrativeUserPersonalContactsServices.Add(administrativeUserPersonalContact));
        }

        [HttpPut]

        public ActionResult<AdministrativeUserPersonalContactDto> Update(CreateAdministrativeUserPersonalContactDto administrativeUserPersonalContact)
        {
            return BadRequest();
        }

        [HttpDelete]

        public ActionResult<AdministrativeUserPersonalContactDto> Delete(CreateAdministrativeUserPersonalContactDto administrativeUserPersonalContact)
        {
            return Ok();
        }
    }
}
