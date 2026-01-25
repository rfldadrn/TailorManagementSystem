using TailorManagementSystems.Application.Common;
using TailorManagementSystems.Application.Common.Pagination;
using TailorManagementSystems.Application.DTO.Agency;
using TailorManagementSystems.Application.Models.Agency;

namespace TailorManagementSystems.Application.Interfaces.Agency
{
        public interface IAgency
        {
                Task<Response<PagedResult<AgencyDTO>>> GetAllAsync(PagedRequest request);
                Task<Response<AgencyDTO?>> GetByIdAsync(int Id);
                Task<Response<bool>> CreateAsync(AgencyModel agency);
                Task<Response<bool>> UpdateAsync(int Id, AgencyModel agency);
                Task<Response<bool>> DeleteAsync(int Id);
        }
}
