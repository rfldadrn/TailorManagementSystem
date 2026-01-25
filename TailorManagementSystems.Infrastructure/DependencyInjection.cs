using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TailorManagementSystems.Application.Interfaces.Agency;
using TailorManagementSystems.Application.Interfaces.Customers;
using TailorManagementSystems.Application.Interfaces.ItemManagement;
using TailorManagementSystems.Application.Interfaces.Menus;
using TailorManagementSystems.Infrastructure.Persistence.Scaffold;
using TailorManagementSystems.Infrastructure.Services;
using TailorManagementSystems.Infrastructure.Services.Sweetalert;
using TailorManagementSystems.Infrastructure.Test;

namespace TailorManagementSystems.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Default");
        services.AddDbContextFactory<AppDbContext>(options =>
            options.UseSqlServer(connectionString)
        );
        // ===============================
        // REGISTRATION SERVICES
        // ===============================
        services.AddScoped<DbHealthCheckService>();
        services.AddScoped<SweetAlertService>();
        services.AddScoped<ICustomerService, CustomerService>();
        services.AddScoped<IMenu, MenuService>();
        services.AddScoped<IAgency, AgencyService>();
        services.AddScoped<I_ItemManagementService, ItemManagementsService>();

        return services;
    }
}
