namespace Assembly.RealEstateManagement.Services.Dtos;

public class AuthenticatedUserDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Role { get; set; } // "Client", "Agent", "Manager", "Admin"

    public string Token { get; set; }
}
