

using Assembly.RealEstateManagement.Data.InMemory.Repositories;
using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Assembly.RealEstateManagement.Data.InMemory
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDataInMemoryServices(this IServiceCollection services)
        {
            services.AddSingleton<Database>();
            services.AddScoped<IAdministrativeUsersRepository, AdministrativeUserRepository>();
            services.AddScoped<IAgentRepository, AgentRepository>();
            services.AddScoped<IManagerRepository, ManagerRepository>();
            services.AddScoped<IVisitRepository, VisitRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IPropertyRepository, PropertyRepository>();

            return services;
        }
    }
}
