using Assembly.RealEstateManagement.Domain.Enums;
using Assembly.RealEstateManagement.Domain.Model;
using Assembly.RealEstateManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Assembly_RealEstateManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerService;

        public ManagerController(IManagerService managerService) 
        {
            _managerService = managerService;
        }

        [HttpGet]
        public ActionResult<ManagerDto> Get()
        {
            return Ok(_managerService.GetManagers());
        }

      

    }



    public class ManagerDto 
    {
        public int EmployeeNumber { get; set; }
        public int ManagerNumber { get; set; }
        public Name Name { get; set; }
       
        public AddressDto Address { get; set; }

     

       
    }


   
    public class AddressDto
    {
        public string Street { get; private set; }
        public int Number { get; private set; }
        public string PostalCode { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }
    }


}
