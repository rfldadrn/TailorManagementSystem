using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorManagementSystems.Application.Common;
using TailorManagementSystems.Application.Common.Pagination;
using TailorManagementSystems.Application.DTO.Item;
using TailorManagementSystems.Application.Models.Item;

namespace TailorManagementSystems.Application.Interfaces.Item
{
    public interface I_Item
    {
        Task<Response<PagedResult<ItemDTO>>> GetAllAsync(PagedRequest request);
        Task<Response<ItemDTO?>> GetByIdAsync(int Id);
        Task<Response<bool>> CreateAsync(ItemModel agency);
        Task<Response<bool>> UpdateAsync(int Id, ItemModel agency);
        Task<Response<bool>> DeleteAsync(int Id);
    }
}
