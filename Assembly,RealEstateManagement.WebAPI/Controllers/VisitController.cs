using Assembly.RealEstateManagement.Services.Dtos.Common;
using Assembly.RealEstateManagement.Services.Dtos.Manager;
using Assembly.RealEstateManagement.Services.Dtos.Property;
using Assembly.RealEstateManagement.Services.Interfaces;
using Assembly.RealEstateManagement.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assembly_RealEstateManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitController : BaseController
    {
        private readonly IVisitServices _visitServices;

        public VisitController(IVisitServices visitServices)
        {
            _visitServices = visitServices;
        }

        [HttpGet]
        public IEnumerable<VisitDto> Get()
        {
            return _visitServices.GetVisits();
        }

        [HttpGet]
        [Route("GetById/{id:int}")]
        public ActionResult<VisitDto> GetbyId([FromRoute] int id)
        {
            return Ok(_visitServices.GetVisitById(id));
        }

        [HttpPost]

        public ActionResult<VisitDto> Add([FromBody] CreateVisitDto visit)
        {
            return Ok(_visitServices.Add(visit));
        }

        [HttpPut("{id:int}")]
        public ActionResult<VisitDto> Update(
        [FromRoute] int id,
        [FromBody] UpdateVisitDto visit)
        {
            if (id != visit.Id)
            {
                return BadRequest("Visit IDs must match");
            }

            return Ok(_visitServices.Update(visit));
        }

        [HttpDelete]

        public ActionResult<VisitDto> Delete(CreateVisitDto visit)
        {
            return Ok();
        }
    }
}
