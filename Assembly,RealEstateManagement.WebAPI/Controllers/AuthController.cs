using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assembly_RealEstateManagement.WebAPI.Controllers;

public class AuthController : BaseController
{
    // Login
    [HttpPost]
    [AllowAnonymous]
    public ActionResult Login([FromBody] LoginDto loginDto)
    {
        return Ok("helloo");
    }

    // Register

    // Logout(?)
}

public class LoginDto
{
    public string Username { get; set; }
    public string Password { get; set; }
}
