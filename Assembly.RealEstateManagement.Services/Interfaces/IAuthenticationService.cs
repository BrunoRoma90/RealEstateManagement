using Assembly.RealEstateManagement.Services.Dtos;

namespace Assembly.RealEstateManagement.Services.Interfaces;

public interface IAuthenticationService
{
    AuthenticatedUserDto Authenticate(string email, string password);
}
