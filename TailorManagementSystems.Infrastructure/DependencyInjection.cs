using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TailorManagementSystems.Application.Interfaces.Agency;
using TailorManagementSystems.Application.Interfaces.Customers;
using TailorManagementSystems.Infrastructure.Persistence.Scaffold;
using TailorManagementSystems.Infrastructure.Services;
using TailorManagementSystems.Infrastructure.Test;

namespace TailorManagementSystems.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // ===============================
        // Database (MySQL - XAMPP)
        // ===============================
        var connectionString = configuration.GetConnectionString("Default");

        services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString)
            )
        );

        // ===============================
        // REGISTRATION SERVICES
        // ===============================
        services.AddScoped<DbHealthCheckService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IAgency, AgencyService>();

        return services;
    }
}
