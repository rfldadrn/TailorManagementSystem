using TailorManagementSystems.Application.Common.Pagination;
using TailorManagementSystems.Application.Common;
using TailorManagementSystems.Application.DTO.Customers;
using TailorManagementSystems.Application.Models.Customers;

namespace TailorManagementSystems.Application.Interfaces.Customers
{
    public interface ICustomerService
    {
        Task<Response<PagedResult<CustomerDTO>>> GetAllAsync(PagedRequest request);
        Task<Response<CustomerDTO?>> GetByIdAsync(int Id);
        Task<Response<bool>> CreateAsync(CustomerFormModel customer);
        Task<Response<bool>> UpdateAsync(int Id, CustomerFormModel customer);
        Task<Response<bool>> DeleteAsync(int Id);
    }
}
