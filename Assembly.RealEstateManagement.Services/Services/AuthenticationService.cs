using Assembly.RealEstateManagement.Domain.Core;
using Assembly.RealEstateManagement.Services.Dtos;
using Assembly.RealEstateManagement.Services.Interfaces;
using Assembly.RealStateManagement.Security.Interfaces;

namespace Assembly.RealEstateManagement.Services.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDataProtectionService _dataProtection;
    private readonly ITokenService _tokenService;

    public AuthenticationService(IUnitOfWork unitOfWork, IDataProtectionService dataProtectionService, ITokenService tokenService)
    {
        _unitOfWork = unitOfWork;
        _dataProtection = dataProtectionService;
        _tokenService = tokenService;
    }

    public AuthenticatedUserDto Authenticate(string email, string password)
    {
        // Agent
        var agent = _unitOfWork.AgentRepository.GetByEmail(email);
        if (agent != null && _dataProtection.VerifyPassword(password, agent.Account.PasswordHash, agent.Account.PasswordSalt))
        {
            var token = _tokenService.GenerateToken(agent.Id, email, "Agent");
            return new AuthenticatedUserDto
            {
                Id = agent.Id,
                Email = email,
                Role = "Agent",
                Token = token
            };
        }

        // Client
        var client = _unitOfWork.ClientRepository.GetByEmail(email);
        if (client != null && _dataProtection.VerifyPassword(password, client.Account.PasswordHash, client.Account.PasswordSalt))
        {
            var token = _tokenService.GenerateToken(client.Id, email, "Client");
            return new AuthenticatedUserDto
            {
                Id = client.Id,
                Email = email,
                Role = "Client",
                Token = token
            };
        }

        // Manager
        var manager = _unitOfWork.ManagerRepository.GetByEmail(email);
        if (manager != null && _dataProtection.VerifyPassword(password, manager.Account.PasswordHash, manager.Account.PasswordSalt))
        {
            var token = _tokenService.GenerateToken(manager.Id, email, "Manager");
            return new AuthenticatedUserDto
            {
                Id = manager.Id,
                Email = email,
                Role = "Manager",
                Token = token
            };
        }

        // Admin / AdministrativeUser
        var admin = _unitOfWork.AdministrativeUsersRepository.GetByEmail(email);
        if (admin != null && _dataProtection.VerifyPassword(password, admin.Account.PasswordHash, admin.Account.PasswordSalt))
        {
            var role = admin.IsAdmin ? "Admin" : "AdministrativeUser";

            var token = _tokenService.GenerateToken(admin.Id, email, role);

            return new AuthenticatedUserDto
            {
                Id = admin.Id,
                Email = email,
                Role = role,
                Token = token
            };
        }

        throw new UnauthorizedAccessException("Invalid email or password.");
    }
}
