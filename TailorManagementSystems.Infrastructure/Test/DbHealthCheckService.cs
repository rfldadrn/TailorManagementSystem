using Microsoft.EntityFrameworkCore;
using TailorManagementSystems.Infrastructure.Persistence.Scaffold;

namespace TailorManagementSystems.Infrastructure.Test;

public class DbHealthCheckService
{
    private readonly AppDbContext _context;

    public DbHealthCheckService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> CustomerCountAsync()
    {
        return await _context.Customers.CountAsync();
    }
}
