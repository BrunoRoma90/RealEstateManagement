namespace Assembly.RealStateManagement.Security.Interfaces;

public interface ITokenService
{
    string GenerateToken(int id, string email, string role);
}
