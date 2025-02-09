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
        return services;
    }
}
