using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Dtos.AdministrativeUsers;
using Assembly.RealEstateManagement.Services.Dtos.Agent;
using Assembly.RealEstateManagement.Services.Dtos.Manager;
using Assembly.RealEstateManagement.Services.Interfaces;
using Assembly.RealEstateManagement.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assembly_RealEstateManagement.WebAPI.Controllers
{
    [Authorize(Roles = "AdministrativeUser, Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class AdministrativeUserController : BaseController
    {
        private readonly IAdministrativeUserService _administrativeUserService;

        public AdministrativeUserController(IAdministrativeUserService administrativeUserService)
        {
            _administrativeUserService = administrativeUserService;
        }

        [HttpGet]
        public IEnumerable<AdministrativeUserDto> Get()
        {
            return _administrativeUserService.GetAdministrativeUsers();
        }

        [HttpGet]
        [Route("GetById/{id:int}")]

        public ActionResult<AdministrativeUserDto> GetbyId([FromRoute] int id)
        {
            return Ok(_administrativeUserService.GetAdministrativeUserById(id));
        }


        [HttpPost]

        public ActionResult<AdministrativeUserDto> Add(CreateAdministrativeUserDto administrativeUser)
        {
            return Ok(_administrativeUserService.Add(administrativeUser));
        }

        [HttpPut("{id:int}")]
        public ActionResult<AdministrativeUserDto> Update(
        [FromRoute] int id,
        [FromBody] UpdateAdministrativeUserDto administrativeUser)
        {
            if (id != administrativeUser.Id)
            {
                return BadRequest("AdministrativeUser IDs must match");
            }

            return Ok(_administrativeUserService.Update(administrativeUser));
        }

        [HttpDelete]

        public ActionResult<AdministrativeUserDto> Delete(CreateAdministrativeUserDto administrativeUser)
        {
            return Ok();
        }


    }
}

