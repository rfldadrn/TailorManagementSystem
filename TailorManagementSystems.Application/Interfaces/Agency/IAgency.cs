using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailorManagementSystems.Application.Common;
using TailorManagementSystems.Application.Common.Pagination;
using TailorManagementSystems.Application.DTO.Agency;
using TailorManagementSystems.Application.Models.Agency;

namespace TailorManagementSystems.Application.Interfaces.Agency
{
    public interface IAgency
    {
        Task<Response<PagedResult<ItemDTO>>> GetAllAsync(PagedRequest request);
        Task<Response<ItemDTO?>> GetByIdAsync(int Id);
        Task<Response<bool>> CreateAsync(AgencyModel agency);
        Task<Response<bool>> UpdateAsync(int Id, AgencyModel agency);
        Task<Response<bool>> DeleteAsync(int Id);
    }
}
