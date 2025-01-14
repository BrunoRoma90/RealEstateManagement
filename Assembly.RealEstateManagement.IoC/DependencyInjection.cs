

using Assembly.RealEstateManagement.Data.InMemory;
using Assembly.RealEstateManagement.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Assembly.RealEstateManagement.IoC
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services) 
        {
            services.AddApplicationServices();
            services.AddDataInMemoryServices();
        }
    }
}
