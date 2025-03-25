using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Dtos;
using Assembly.RealEstateManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Assembly_RealEstateManagement.WebAPI.Controllers
{
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

        [HttpPost]

        public ActionResult<AdministrativeUserDto> Add(CreateAdministrativeUserDto administrativeUser)
        {
            return Ok(_administrativeUserService.Add(administrativeUser));
        }

        [HttpPut]

        public ActionResult<AdministrativeUserDto> Update(CreateAdministrativeUserDto administrativeUser)
        {
            return BadRequest();
        }

        [HttpDelete]

        public ActionResult<AdministrativeUserDto> Delete(CreateAdministrativeUserDto administrativeUser)
        {
            return Ok();
        }


    }
}

