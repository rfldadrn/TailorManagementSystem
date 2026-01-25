using TailorManagementSystems.Application.Common.Pagination;
using TailorManagementSystems.Application.Common;
using TailorManagementSystems.Application.DTO.Payment_Types;
using TailorManagementSystems.Application.Models.Payment_Types;

namespace TailorManagementSystems.Application.Interfaces.Payment_Types
{
    public interface IPayment_TypeService
    {
        Task<Response<PagedResult<Payment_TypeDTO>>> GetAllAsync(PagedRequest request);
        Task<Response<Payment_TypeDTO?>> GetByIdAsync(int Id);
        Task<Response<bool>> CreateAsync(Payment_TypeFormModel payment_type);
        Task<Response<bool>> UpdateAsync(int Id, Payment_TypeFormModel payment_type);
        Task<Response<bool>> DeleteAsync(int Id);
    }
}
