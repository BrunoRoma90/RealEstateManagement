using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assembly_RealEstateManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : BaseController
    {
        [Authorize(Roles = "Manager")]
        [HttpGet]
        public IActionResult Secured()
        {
            return Ok("Token válido!");
        }

        [AllowAnonymous]
        [HttpGet("public")]
        public IActionResult Public()
        {
            return Ok("Sem token funciona.");
        }
    }
}
