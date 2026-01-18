using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorManagementSystems.Application.Common;
using TailorManagementSystems.Application.Common.Pagination;
using TailorManagementSystems.Application.DTO.ItemManagement;
using TailorManagementSystems.Application.Models.ItemManagement;

namespace TailorManagementSystems.Application.Interfaces.ItemManagement
{
    public interface I_ItemManagementService
    {
        Task<Response<PagedResult<ItemManagementDTO>>> GetAllAsync(PagedRequest request);
        Task<Response<ItemManagementDTO?>> GetByIdAsync(int Id);
        Task<Response<bool>> CreateAsync(ItemManagementModel agency);
        Task<Response<bool>> UpdateAsync(int Id, ItemManagementModel agency);
        Task<Response<bool>> DeleteAsync(int Id);
    }
}
