using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Services.Interfaces;
using Assembly.RealEstateManagement.Services.Services;
using Assembly.RealStateManagement.Security.Interfaces;
using Assembly.RealStateManagement.Security.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Assembly.RealEstateManagement.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
       
        services.AddScoped<IAgentService, AgentService>();
        services.AddScoped<IManagerService, ManagerService>();
        services.AddScoped<IAdministrativeUserService, AdministrativeUserService>();
        services.AddScoped<IManagerPersonalContactsServices, ManagerPersonalContactsServices>();
        services.AddScoped<IAgentPersonalContactsServices, AgentPersonalContactsServices>();
        services.AddScoped<IAdministrativeUsersPersonalContactsServices, AdministrativeUsersPersonalContactsServices>();
        services.AddScoped<IManagerAllContactsServices, ManagerAllContactsServices>();
        services.AddScoped<IAgentAllContactsServices, AgentAllContactServices>();
        services.AddScoped<IAdministrativeUsersAllContactsServices, AdministrativeUserAllContactsServices>();
        services.AddScoped<IPropertyServices, PropertyServices>();
        services.AddScoped<IClientServices, ClientServices>();
        services.AddScoped<IVisitServices, VisitServices>();
        services.AddScoped<IFavoritePropertyService, FavoritePropertyService>();

        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}
