using Microsoft.EntityFrameworkCore;
using TailorManagementSystems.Application.Common;
using TailorManagementSystems.Application.Common.Pagination;
using TailorManagementSystems.Application.Interfaces.Payment_Types;
using TailorManagementSystems.Application.DTO.Payment_Types;
using TailorManagementSystems.Infrastructure.Persistence.Scaffold;
using TailorManagementSystems.Application.Models.Payment_Types;

namespace TailorManagementSystems.Infrastructure.Services
{
    public class Payment_TypeService : IPayment_TypeService
    {
        private readonly IDbContextFactory<AppDbContext> _factory;

        public Payment_TypeService(IDbContextFactory<AppDbContext> factory)
        {
            _factory = factory;
        }

        public async Task<Response<bool>> CreateAsync(Payment_TypeFormModel payment_type)
        {
            using var _context = _factory.CreateDbContext();
            var existingPayment_Type = await _context.Paymenttypes
                .FirstOrDefaultAsync(c =>
                    c.Name == payment_type.Name && c.RowStatus == true);

            var entity = new Paymenttype
            {
                Name = payment_type.Name,
                Description = payment_type.Description,
                RowStatus = true
            };

            _context.Paymenttypes.Add(entity);
            await _context.SaveChangesAsync();

            return Response<bool>.Ok(true, "Create Payment Type successfully!");
        }

        public async Task<Response<bool>> DeleteAsync(int Id)
        {
            try
            {
                using var _context = _factory.CreateDbContext();
                var entity = await _context.Paymenttypes.FindAsync(Id);
                if (entity == null)
                    return Response<bool>.Fail("Payment Type not found!");

                _context.Paymenttypes.Remove(entity);
                await _context.SaveChangesAsync();


                return Response<bool>.Ok(true, "Delete Payment Type sucessfully!");
            }

            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                return Response<bool>.Fail(e.Message);
            }

        }

        public async Task<Response<PagedResult<Payment_TypeDTO>>> GetAllAsync(PagedRequest request)
        {
            using var _context = _factory.CreateDbContext();
            var query = _context.Paymenttypes.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var keyword = request.Search.Trim();
                query = query.Where(c =>
                    c.Name.Contains(keyword) ||
                    c.Description.Contains(keyword));
            }

            var totalItems = await query.CountAsync();
            var payment_types = await query.OrderBy(c => c.Name).Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(c => new Payment_TypeDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    RowStatus = c.RowStatus
                })
            .ToListAsync();

            var result = new PagedResult<Payment_TypeDTO>
            {
                Items = payment_types,
                Page = request.Page,
                PageSize = request.PageSize,
                TotalItems = totalItems
            };

            return Response<PagedResult<Payment_TypeDTO>>.Ok(result);
        }

        public async Task<Response<Payment_TypeDTO?>> GetByIdAsync(int Id)
        {
            using var _context = _factory.CreateDbContext();
            var entity = await _context.Paymenttypes.FindAsync(Id);
            if (entity == null)
                return Response<Payment_TypeDTO?>.Fail("Payment Type tidak ditemukan");

            return Response<Payment_TypeDTO?>.Ok(new Payment_TypeDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                RowStatus = entity.RowStatus // Map RowStatus here
            });
        }

        public async Task<Response<bool>> UpdateAsync(int Id, Payment_TypeFormModel payment_type)
        {
            using var _context = _factory.CreateDbContext();
            var entity = await _context.Paymenttypes.FindAsync(Id);
            if (entity == null)
                return Response<bool>.Fail("Payment Type tidak ditemukan!");

            var existingPayment_Type = await _context.Paymenttypes
                .FirstOrDefaultAsync(c => c.Id != Id &&
                c.Name == payment_type.Name && c.RowStatus == true);

            if (existingPayment_Type != null)
                return Response<bool>.Fail("Payment_Type sudah digunakan!");


            entity.Name = payment_type.Name;
            entity.Description = payment_type.Description;
            await _context.SaveChangesAsync();

            return Response<bool>.Ok(true, "Update Payment Type successfully!");
        }
    }
}
