﻿using Assembly.RealEstateManagement.Domain.Core.Repositories;
using Assembly.RealEstateManagement.Services.Interfaces;
using Assembly.RealEstateManagement.Services.Services;
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
        return services;
    }
}
