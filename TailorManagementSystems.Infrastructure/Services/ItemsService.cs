using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorManagementSystems.Application.Common;
using TailorManagementSystems.Application.Common.Pagination;
using TailorManagementSystems.Application.DTO.Item;
using TailorManagementSystems.Application.Interfaces.Item;
using TailorManagementSystems.Application.Models.Item;
using TailorManagementSystems.Infrastructure.Persistence.Scaffold;

namespace TailorManagementSystems.Infrastructure.Services
{
    public class ItemsService : I_Item
    {
        private readonly AppDbContext _context;
        public ItemsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Response<bool>> CreateAsync(ItemModel item)
        {
            if (string.IsNullOrWhiteSpace(item.Name))
                return Response<bool>.Fail("Item name canot be empty!");

            var entity = new Item
            {
                Name = item.Name,
                Description = item.Description,
                CustomerPrice = item.CustomerPrice,
                RowStatus = 1
            };

            _context.Items.Add(entity);
            await _context.SaveChangesAsync();

            return Response<bool>.Ok(true, "Create Items successfully!");
        }

        public async Task<Response<bool>> DeleteAsync(int Id)
        {
            var entity = await _context.Items.FindAsync(Id);
            if (entity == null)
                return Response<bool>.Fail("Items not found!");

            _context.Items.Remove(entity);
            await _context.SaveChangesAsync();

            return Response<bool>.Ok(true, "Delete Items sucessfully!");
        }

        public async Task<Response<PagedResult<ItemDTO>>> GetAllAsync(PagedRequest request)
        {
            var query = _context.Items.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var keyword = request.Search.Trim();
                query = query.Where(c =>
                    c.Name.Contains(keyword) &&
                    c.RowStatus == 1);
            }

            var totalItems = await query.CountAsync();
            var items = await query.OrderBy(c => c.Name).Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(c => new ItemDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    RowStatus = c.RowStatus
                })
            .ToListAsync();

            var result = new PagedResult<ItemDTO>
            {
                Items = items,
                Page = request.Page,
                PageSize = request.PageSize,
                TotalItems = totalItems
            };

            return Response<PagedResult<ItemDTO>>.Ok(result);
        }

        public async Task<Response<ItemDTO?>> GetByIdAsync(int Id)
        {
            var entity = await _context.Items.FindAsync(Id);
            if (entity == null)
                return Response<ItemDTO?>.Fail("Agency tidak ditemukan");

            return Response<ItemDTO?>.Ok(new ItemDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                CustomerPrice = entity.CustomerPrice,
                RowStatus = entity.RowStatus
            });
        }

        public async Task<Response<bool>> UpdateAsync(int Id, ItemModel item)
        {
            var entity = await _context.Items.FindAsync(item.Id);
            if (entity == null)
                return Response<bool>.Fail("CustomerPrice tidak ditemukan");

            entity.Name = item.Name;
            entity.Description = item.Description;
            entity.CustomerPrice = item.CustomerPrice;
            entity.RowStatus = item.RowStatus;
         
            await _context.SaveChangesAsync();

            return Response<bool>.Ok(true, "Update customer successfully!");
        }
    }
}
