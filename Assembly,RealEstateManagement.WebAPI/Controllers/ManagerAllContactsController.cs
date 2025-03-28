﻿using Assembly.RealEstateManagement.Services.Dtos.Manager;
using Assembly.RealEstateManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Assembly_RealEstateManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManagerAllContactsController : BaseController
    {
        private readonly IManagerAllContactsServices _managerAllContactsServices;

        private ManagerAllContactsController(IManagerAllContactsServices managerAllContactsServices) 
        {
            _managerAllContactsServices = managerAllContactsServices;
        }

        [HttpGet]
        public IEnumerable<ManagerAllContactsDto> Get()
        {
            return _managerAllContactsServices.GetManagerAllContacts();
        }
        [HttpPost]

        public ActionResult<ManagerAllContactsDto> Add(CreateManagerAllContactsDto managerAllContact)
        {
            return Ok(_managerAllContactsServices.Add(managerAllContact));
        }

        [HttpPut]

        public ActionResult<ManagerAllContactsDto> Update(CreateManagerAllContactsDto managerAllContact)
        {
            return BadRequest();
        }

        [HttpDelete]

        public ActionResult<ManagerAllContactsDto> Delete(CreateManagerAllContactsDto managerAllContact)
        {
            return Ok();
        }

    }
}
