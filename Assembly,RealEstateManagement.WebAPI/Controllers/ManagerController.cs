using Assembly.RealEstateManagement.Services.Dtos.Agent;
using Assembly.RealEstateManagement.Services.Dtos.Manager;
using Assembly.RealEstateManagement.Services.Interfaces;
using Assembly.RealEstateManagement.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assembly_RealEstateManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ManagerController : BaseController
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService) 
        {
            _managerService = managerService;
        }

        [HttpGet]
        public IEnumerable<ManagerDto> Get()
        {
            return _managerService.GetManagers();
        }

        [HttpGet]
        [Route("GetById/{id:int}")]
        public ActionResult<ManagerDto> GetbyId([FromRoute] int id)
        {
            return Ok(_managerService.GetManagerById(id));
        }

        [HttpPost]

        public ActionResult<ManagerDto> Add(CreateManagerDto manager) 
        {
            return Ok(_managerService.Add(manager));
        }

        [HttpPut]

        public ActionResult<ManagerDto> Update(CreateManagerDto manager)
        {
            return BadRequest();
        }

        [HttpDelete]

        public ActionResult<ManagerDto> Delete(CreateManagerDto manager)
        {
            return Ok();
        }


    }


}
