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
        private readonly AppDbContext _context;

        public CustomerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Response<bool>> CreateAsync(CustomerFormModel customer)
        {
            if (string.IsNullOrWhiteSpace(customer.Name))
                return Response<bool>.Fail("Customer name canot be empty!");

            var entity = new Customer
            {
                Name = customer.Name,
                Email = customer.Email,
                Gender = customer.Gender,
                PhoneNumber = customer.PhoneNumber,
                RowStatus = 1
            };

            _context.Customers.Add(entity);
            await _context.SaveChangesAsync();

            return Response<bool>.Ok(true, "Create customer successfully!");
        }

        public async Task<Response<bool>> DeleteAsync(int Id)
        {
            var entity = await _context.Customers.FindAsync(Id);
            if (entity == null)
                return Response<bool>.Fail("Customer not found!");

            _context.Customers.Remove(entity);
            await _context.SaveChangesAsync();

            return Response<bool>.Ok(true, "Delete customer sucessfully!");
        }

        public async Task<Response<PagedResult<CustomerDTO>>> GetAllAsync(PagedRequest request)
        {
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
                Gender = (Application.DTO.Customers.Gender)c.Gender,
                PhoneNumber = c.PhoneNumber,
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
            var entity = await _context.Customers.FindAsync(Id);
            if (entity == null)
                return Response<CustomerDTO?>.Fail("Customer tidak ditemukan");

            return Response<CustomerDTO?>.Ok(new CustomerDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Gender = (TailorManagementSystems.Application.DTO.Customers.Gender)entity.Gender,
                PhoneNumber = entity.PhoneNumber,
            });
        }

        public async Task<Response<bool>> UpdateAsync(int Id,CustomerFormModel customer)
        {
            var entity = await _context.Customers.FindAsync(customer.Id);
            if (entity == null)
                return Response<bool>.Fail("Customer tidak ditemukan");

            entity.Name = customer.Name;
            entity.Email = customer.Email;
            entity.Gender = customer.Gender;
            entity.PhoneNumber = customer.PhoneNumber;
            await _context.SaveChangesAsync();

            return Response<bool>.Ok(true, "Update customer successfully!");
        }
    }
}
