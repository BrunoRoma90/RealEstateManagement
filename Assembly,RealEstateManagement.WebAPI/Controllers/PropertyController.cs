using Assembly.RealEstateManagement.Services.Dtos.Manager;
using Assembly.RealEstateManagement.Services.Dtos.Property;
using Assembly.RealEstateManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Assembly_RealEstateManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertyController : BaseController
    {
        private readonly IPropertyServices _propertyService;

        public PropertyController(IPropertyServices propertyServices)
        {
            _propertyService = propertyServices;
        }

        [HttpGet]
        public IEnumerable<PropertyDto> Get()
        {
            return _propertyService.GetProperties();
        }

        [HttpPost]

        public ActionResult<PropertyDto> Add([FromBody]CreatePropertyDto property)
        {
            return Ok(_propertyService.Add(property));
        }

        [HttpPut]

        public ActionResult<PropertyDto> Update(CreatePropertyDto property)
        {
            return BadRequest();
        }

        [HttpDelete]

        public ActionResult<PropertyDto> Delete(CreatePropertyDto property)
        {
            return Ok();
        }

    }
}
