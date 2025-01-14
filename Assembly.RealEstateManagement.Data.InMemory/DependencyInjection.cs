

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
            services.AddScoped<IAgentRepository, AgentRepository>();
            return services;
        }
    }
}
