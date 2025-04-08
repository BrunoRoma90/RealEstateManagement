using Assembly.RealEstateManagement.Services.Dtos.Common;
using Assembly.RealEstateManagement.Services.Dtos.Property;
using Assembly.RealEstateManagement.Services.Interfaces;
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

        [HttpPut]

        public ActionResult<VisitDto> Update(CreateVisitDto visit)
        {
            return BadRequest();
        }

        [HttpDelete]

        public ActionResult<VisitDto> Delete(CreateVisitDto visit)
        {
            return Ok();
        }
    }
}
