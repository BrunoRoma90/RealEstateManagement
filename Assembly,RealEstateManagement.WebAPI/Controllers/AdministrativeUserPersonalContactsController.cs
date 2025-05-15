using Assembly.RealEstateManagement.Services.Dtos.AdministrativeUsers;
using Assembly.RealEstateManagement.Services.Dtos.Manager;
using Assembly.RealEstateManagement.Services.Interfaces;
using Assembly.RealEstateManagement.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assembly_RealEstateManagement.WebAPI.Controllers
{
    [Authorize(Roles = "AdministrativeUser")]
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


        [HttpPut("{id:int}")]
        public ActionResult<AdministrativeUserDto> Update(
        [FromRoute] int id,
        [FromBody] UpdateAdministrativeUserPersonalContactDto administrativeUserPersonallContacts)
        {
            if (id != administrativeUserPersonallContacts.Id)
            {
                return BadRequest("IDs must match");
            }

            return Ok(_administrativeUserPersonalContactsServices.Update(administrativeUserPersonallContacts));
        }


        [HttpDelete]

        public ActionResult<AdministrativeUserPersonalContactDto> Delete(CreateAdministrativeUserPersonalContactDto administrativeUserPersonalContact)
        {
            return Ok();
        }
    }
}
