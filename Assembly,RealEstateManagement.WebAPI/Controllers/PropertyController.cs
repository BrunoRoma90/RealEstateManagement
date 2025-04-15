using Assembly.RealEstateManagement.Services.Dtos.Manager;
using Assembly.RealEstateManagement.Services.Dtos.Property;
using Assembly.RealEstateManagement.Services.Interfaces;
using Assembly.RealEstateManagement.Services.Services;
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

        [HttpGet]
        [Route("GetById/{id:int}")]
        public ActionResult<PropertyDto> GetbyId([FromRoute] int id)
        {
            return Ok(_propertyService.GetPropertyById(id));
        }

        [HttpPost]

        public ActionResult<PropertyDto> Add([FromBody]CreatePropertyDto property)
        {
            return Ok(_propertyService.Add(property));
        }

        [HttpPut("{id:int}")]
        public ActionResult<PropertyDto> Update(
         [FromRoute] int id,
         [FromBody] UpdatePropertyDto property)
        {
            if (id != property.Id)
            {
                return BadRequest("Property IDs must match");
            }

            return Ok(_propertyService.Update(property));
        }

        [HttpDelete]

        public ActionResult<PropertyDto> Delete(CreatePropertyDto property)
        {
            return Ok();
        }

    }
}
