using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorManagementSystems.Application.Common;
using TailorManagementSystems.Application.Common.Pagination;
using TailorManagementSystems.Application.DTO.Menus;
using TailorManagementSystems.Application.Models.Menus;

namespace TailorManagementSystems.Application.Interfaces.Menus
{
    public interface IMenu
    {
        Task<List<MenuDTO>> GetAllAsync();
        Task<Response<MenuDTO?>> GetByIdAsync(int Id);
        Task<Response<bool>> CreateAsync(MenusModel customer);
        Task<Response<bool>> UpdateAsync(int Id, MenusModel customer);
        Task<Response<bool>> DeleteAsync(int Id);
    }
}
