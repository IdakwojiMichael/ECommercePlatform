using ECommercePlatform.Application.Interfaces;
using ECommercePlatform.Persistence.Context;
using ECommercePlatform.Persistence.Repositories;
using ECommercePlatform.Persistence.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommercePlatform.Persistence.DependencyInjection;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ECommerceDbContext>(options =>
        {
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped<IIdentityService, IdentityService>();

        services.AddScoped<ICustomerRepository, CustomerRepository>();

        services.AddScoped<ITransactionManager, TransactionManager>();

        return services;
    }
}