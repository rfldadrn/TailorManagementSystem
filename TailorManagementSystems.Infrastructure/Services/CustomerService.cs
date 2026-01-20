using Microsoft.EntityFrameworkCore;
using TailorManagementSystems.Application.Common;
using TailorManagementSystems.Application.Common.Pagination;
using TailorManagementSystems.Application.Interfaces.Customers;
using TailorManagementSystems.Application.DTO.Customers;
using TailorManagementSystems.Infrastructure.Persistence.Scaffold;
using TailorManagementSystems.Application.Models.Customers;

namespace TailorManagementSystems.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IDbContextFactory<AppDbContext> _factory;

        public CustomerService(IDbContextFactory<AppDbContext> factory)
        {
            _factory = factory;
        }

        public async Task<Response<bool>> CreateAsync(CustomerFormModel customer)
        {
            using var _context = _factory.CreateDbContext();
            var existingCustomer = await _context.Customers
                .FirstOrDefaultAsync(c =>
                    c.Email == customer.Email && c.RowStatus == true);

            if (existingCustomer != null)
                return Response<bool>.Fail("Email sudah digunakan!");

            var entity = new Customer
            {
                Name = customer.Name,
                Email = customer.Email,
                Gender = customer.Gender,
                PhoneNumber = customer.PhoneNumber,
                RowStatus = true
            };

            _context.Customers.Add(entity);
            await _context.SaveChangesAsync();

            return Response<bool>.Ok(true, "Create customer successfully!");
        }

        public async Task<Response<bool>> DeleteAsync(int Id)
        {
            using var _context = _factory.CreateDbContext();
            var entity = await _context.Customers.FindAsync(Id);
            if (entity == null)
                return Response<bool>.Fail("Customer not found!");

            _context.Customers.Remove(entity);
            await _context.SaveChangesAsync();

            return Response<bool>.Ok(true, "Delete customer sucessfully!");
        }

        public async Task<Response<PagedResult<CustomerDTO>>> GetAllAsync(PagedRequest request)
        {
            using var _context = _factory.CreateDbContext();
            var query = _context.Customers.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var keyword = request.Search.Trim();
                query = query.Where(c => 
                    c.Name.Contains(keyword) ||
                    c.Email.Contains(keyword) ||
                    c.PhoneNumber.Contains(keyword));
            }

            var totalItems = await query.CountAsync();
            var customers = await query.OrderBy(c => c.Name).Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(c => new CustomerDTO
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                Gender = c.Gender,
                PhoneNumber = c.PhoneNumber,
                RowStatus = c.RowStatus // Map RowStatus here
            })
            .ToListAsync();

            var result = new PagedResult<CustomerDTO>
            {
                Items = customers,
                Page = request.Page,
                PageSize = request.PageSize,
                TotalItems = totalItems
            };

            return Response<PagedResult<CustomerDTO>>.Ok(result);
        }

        public async Task<Response<CustomerDTO?>> GetByIdAsync(int Id)
        {
            using var _context = _factory.CreateDbContext();
            var entity = await _context.Customers.FindAsync(Id);
            if (entity == null)
                return Response<CustomerDTO?>.Fail("Customer tidak ditemukan");

            return Response<CustomerDTO?>.Ok(new CustomerDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Gender = entity.Gender,
                PhoneNumber = entity.PhoneNumber,
                RowStatus = entity.RowStatus // Map RowStatus here
            });
        }

        public async Task<Response<bool>> UpdateAsync(int Id,CustomerFormModel customer)
        {
            using var _context = _factory.CreateDbContext();
            var entity = await _context.Customers.FindAsync(Id);
            if (entity == null)
                return Response<bool>.Fail("Customer tidak ditemukan!");
            
            var existingCustomer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Id != Id &&
                c.Email == customer.Email && c.RowStatus == true);
            
            if (existingCustomer != null)
                return Response<bool>.Fail("Email sudah digunakan!");


            entity.Name = customer.Name;
            entity.Email = customer.Email;
            entity.Gender = customer.Gender;
            entity.PhoneNumber = customer.PhoneNumber;
            await _context.SaveChangesAsync();

            return Response<bool>.Ok(true, "Update customer successfully!");
        }
    }
}
