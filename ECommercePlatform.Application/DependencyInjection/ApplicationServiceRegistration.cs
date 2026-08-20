using ECommercePlatform.Application.Interfaces;
using ECommercePlatform.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ECommercePlatform.Application.DependencyInjection;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddScoped<IRegistrationService, RegistrationService>();

        return services;
    }
}