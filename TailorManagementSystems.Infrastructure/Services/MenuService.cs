using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorManagementSystems.Application.Common;
using TailorManagementSystems.Application.Common.Pagination;
using TailorManagementSystems.Application.DTO.Customers;
using TailorManagementSystems.Application.DTO.Menus;
using TailorManagementSystems.Application.Interfaces.Menus;
using TailorManagementSystems.Application.Models.Menus;
using TailorManagementSystems.Infrastructure.Persistence.Scaffold;

namespace TailorManagementSystems.Infrastructure.Services
{
    public class MenuService : IMenu
    {
        private readonly IDbContextFactory<AppDbContext> _factory;
        public MenuService(IDbContextFactory<AppDbContext> factory) {
            _factory = factory;
        }
        public async Task<Response<bool>> CreateAsync(MenusModel customer)
        {
            if (customer is null)
            {
                return Response<bool>.Fail("Menu model cannot be null", new List<string> { "MenusModel is null" });
            }

            try
            {
                using var context = _factory.CreateDbContext();

                var entity = new Menu
                {
                    // Map fields that are typically present based on the rest of the service.
                    // Adjust property names if your MenusModel differs.
                    Name = customer.GetType().GetProperty("Name") != null ? (string?)customer.GetType().GetProperty("Name")!.GetValue(customer) : null,
                    Slug = customer.GetType().GetProperty("Slug") != null ? (string?)customer.GetType().GetProperty("Slug")!.GetValue(customer) : null,
                    Url = customer.Url,
                    Icon = customer.Icon,
                    OrderPosition = customer.GetType().GetProperty("OrderPosition") != null ? (int?)customer.GetType().GetProperty("OrderPosition")!.GetValue(customer) : null,
                    RowStatus = true,
                    CreatedAt = DateTime.UtcNow
                };

                // Try to set ParentId from either a direct property or from Parent.Id if available
                var parentIdProp = customer.GetType().GetProperty("ParentId");
                if (parentIdProp != null)
                {
                    var value = parentIdProp.GetValue(customer);
                    if (value is int pid)
                        entity.ParentId = pid;
                    else if (value is int?)
                        entity.ParentId = (int?)value;
                }
                else
                {
                    var parentProp = customer.GetType().GetProperty("Parent");
                    if (parentProp != null)
                    {
                        var parentObj = parentProp.GetValue(customer);
                        if (parentObj != null)
                        {
                            var idProp = parentObj.GetType().GetProperty("Id");
                            if (idProp != null)
                            {
                                var idVal = idProp.GetValue(parentObj);
                                if (idVal is int pid2)
                                    entity.ParentId = pid2;
                            }
                        }
                    }
                }

                context.Menus.Add(entity);
                await context.SaveChangesAsync();

                return Response<bool>.Ok(true);
            }
            catch (Exception ex)
            {
                return Response<bool>.Fail("Failed to create menu", new List<string> { ex.Message });
            }
        }

        public Task<Response<bool>> DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<MenuDTO>> GetAllAsync()
        {
            using var context = _factory.CreateDbContext();
            var menus = await context.Menus.AsNoTracking()
                .Select(m => new MenuDTO
                {
                    Id = m.Id,
                    Name = m.Name,
                    ParentId = m.ParentId,
                    Slug = m.Slug,
                    Url = m.Url,
                    Icon = m.Icon,
                    OrderPosition = m.OrderPosition,
                    RowStatus = m.RowStatus,
                    CreatedAt = m.CreatedAt,
                    UpdatedAt = m.UpdatedAt,
                    InverseParent = new List<MenuDTO>() // or map children if needed
                }).ToListAsync();

                var lookup = menus.ToDictionary(x => x.Id);
                var roots = new List<MenuDTO>();

                foreach (var menu in menus)
                {
                    if (menu.ParentId == null)
                    {
                        roots.Add(menu);
                    }
                    else if (lookup.TryGetValue(menu.ParentId.Value, out var parent))
                    {
                        parent?.Parent?.Add(menu);
                    }
                }
                return roots;
        }

        public Task<Response<MenuDTO?>> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> UpdateAsync(int Id, MenusModel customer)
        {
            throw new NotImplementedException();
        }
    }
}
