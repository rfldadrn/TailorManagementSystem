using Microsoft.EntityFrameworkCore;
using TailorManagementSystems.Application.Common;
using TailorManagementSystems.Application.Common.Pagination;
using TailorManagementSystems.Application.DTO.ItemManagement;
using TailorManagementSystems.Application.Interfaces.ItemManagement;
using TailorManagementSystems.Application.Models.ItemManagement;
using TailorManagementSystems.Infrastructure.Persistence.Scaffold;

namespace TailorManagementSystems.Infrastructure.Services
{
    public class ItemManagementsService : I_ItemManagementService
    {
        private readonly AppDbContext _context;
        public ItemManagementsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Response<bool>> CreateAsync(ItemManagementModel itemManagement)
        {
            if (string.IsNullOrWhiteSpace(itemManagement.Name))
                return Response<bool>.Fail("Item Management name cannot be empty!");

            var entity = new ItemManagement
            {
                Name = itemManagement.Name,
                Description = itemManagement.Description,
                CustomerPrice = itemManagement.CustomerPrice,
                RowStatus = 1
            };

            _context.ItemManagements.Add(entity);
            await _context.SaveChangesAsync();

            return Response<bool>.Ok(true, "Create Item Managements successfully!");
        }

        public async Task<Response<bool>> DeleteAsync(int Id)
        {
            var entity = await _context.ItemManagements.FindAsync(Id);
            if (entity == null)
                return Response<bool>.Fail("Item Managements not found!");

            _context.ItemManagements.Remove(entity);
            await _context.SaveChangesAsync();

            return Response<bool>.Ok(true, "Delete Item Managements sucessfully!");
        }

        public async Task<Response<PagedResult<ItemManagementDTO>>> GetAllAsync(PagedRequest request)
        {
            var query = _context.ItemManagements.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var keyword = request.Search.Trim();
                query = query.Where(c =>
                    c.Name.Contains(keyword) &&
                    c.RowStatus == 1);
            }

            var totalItems = await query.CountAsync();
            var itemManagements = await query.OrderBy(c => c.Name).Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(c => new ItemManagementDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    CustomerPrice = c.CustomerPrice,
                    RowStatus = c.RowStatus
                })
            .ToListAsync();

            var result = new PagedResult<ItemManagementDTO>
            {
                Items = itemManagements,
                Page = request.Page,
                PageSize = request.PageSize,
                TotalItems = totalItems
            };

            return Response<PagedResult<ItemManagementDTO>>.Ok(result);
        }

        public async Task<Response<ItemManagementDTO?>> GetByIdAsync(int Id)
        {
            var entity = await _context.ItemManagements.FindAsync(Id);
            if (entity == null)
                return Response<ItemManagementDTO?>.Fail("Item Management tidak ditemukan");

            return Response<ItemManagementDTO?>.Ok(new ItemManagementDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                CustomerPrice = entity.CustomerPrice,
                RowStatus = entity.RowStatus
            });
        }

        public async Task<Response<bool>> UpdateAsync(int Id, ItemManagementModel item)
        {
            var entity = await _context.ItemManagements.FindAsync(item.Id);
            if (entity == null)
                return Response<bool>.Fail("Item Management tidak ditemukan");

            entity.Name = item.Name;
            entity.Description = item.Description;
            entity.CustomerPrice = item.CustomerPrice;
            entity.RowStatus = (sbyte?)item.RowStatus;
         
            await _context.SaveChangesAsync();

            return Response<bool>.Ok(true, "Update item management successfully!");
        }
    }
}
