using Assembly.RealStateManagement.Security.Interfaces;
using Assembly.RealStateManagement.Security.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Assembly.RealStateManagement.Security;

public static class DependencyInjection
{
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDataProtectionService, DataProtectionService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserResolverService, UserResolverService>();


        return services;
    }
}
