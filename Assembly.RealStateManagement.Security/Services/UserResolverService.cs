using System.Security.Claims;
using Assembly.RealStateManagement.Security.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Assembly.RealStateManagement.Security.Services;

public class UserResolverService : IUserResolverService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserResolverService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    private ClaimsPrincipal? CurrentUser => _httpContextAccessor.HttpContext?.User;

    public int GetUserId()
    {
        var userIdClaim = CurrentUser?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return userIdClaim != null ? int.Parse(userIdClaim) : 0;
    }

    public string? GetUserEmail()
    {
        return CurrentUser?.FindFirst(ClaimTypes.Email)?.Value;
    }

    public string? GetUserRole()
    {
        return CurrentUser?.FindFirst(ClaimTypes.Role)?.Value;
    }
}
