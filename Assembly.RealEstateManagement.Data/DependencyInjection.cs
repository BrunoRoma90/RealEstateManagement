using Assembly.RealEstateManagement.Data.Context;
using Assembly.RealEstateManagement.Data.Repositories;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Assembly.RealEstateManagement.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddData(this IServiceCollection services, IConfiguration config) 
    {
        services.AddDbContext<ApplicationDbContext>(options => 
        {
            var cs = config.GetConnectionString("RealEstateManagementCS");
            options.UseSqlServer(cs);
        });
        services.AddScoped<IAgentRepository,AgentRepository>();
        services.AddScoped<IAgentPersonalContactRepository, AgentPersonalContactRepository>();
        services.AddScoped<IAgentAllContactRepository, AgentAllContactRepository>();
        services.AddScoped<IManagerRepository, ManagerRepository>();
        services.AddScoped<IManagerPersonalContactRepository, ManagerPersonalContactRepository>();
        services.AddScoped<IManagerAllContactRepository, ManagerAllContactRepository>();
        services.AddScoped<IAdministrativeUsersRepository, AdministrativeUserRepository>();
        services.AddScoped<IAdministrativeUserPersonalContactRepository, AdministrativeUserPersonalContactRepository>();
        services.AddScoped<IAdministrativeUserAllContactRepository, AdministrativeUserAllContactRepository>();
        services.AddScoped<IVisitRepository, VisitRepository>();
        services.AddScoped<IPropertyRepository, PropertyRepository>();
        services.AddScoped<IClientRepository , ClientRepository>();
        services.AddScoped<IAccountRepository, AccountRepository>();
        services.AddScoped<IAddressRepository, AddressRepository>();



        return services;
    }
}
