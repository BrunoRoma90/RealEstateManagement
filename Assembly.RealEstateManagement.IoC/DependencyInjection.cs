

using Assembly.RealEstateManagement.Data;
using Assembly.RealEstateManagement.Services;
using Assembly.RealStateManagement.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Assembly.RealEstateManagement.IoC
{
    public static class DependencyInjection
    {
        public static void AddServices(this IServiceCollection services, IConfiguration config) 
        {
            services.AddApplicationServices();
            services.AddData(config);
            services.AddJwtAuthentication(config);
        }
    }
}
