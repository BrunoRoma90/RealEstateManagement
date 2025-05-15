using Assembly.RealEstateManagement.Services.Dtos;
using Assembly.RealEstateManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Assembly_RealEstateManagement.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : BaseController
{
    private readonly IAuthenticationService _authenticationService;

    public AuthController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [AllowAnonymous]
    [HttpPost("login")]
   
    public IActionResult Login([FromBody] LoginDto loginDto)
    {
        try
        {
            var authenticatedUser = _authenticationService.Authenticate(loginDto.Email, loginDto.Password);
            return Ok(authenticatedUser); // Token, Email, Role, etc.
        }
        catch (UnauthorizedAccessException)
        {
            return Unauthorized("Invalid email or password.");
        }
    }





    //// Login
    //[HttpPost]
    //[AllowAnonymous]
    //public ActionResult Login([FromBody] LoginDto loginDto)
    //{
    //    return Ok("helloo");
    //}

    // Register

    // Logout(?)
}


