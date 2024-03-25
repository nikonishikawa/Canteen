using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;
using CanteenClassLibrary.Entities;

namespace CanteenClassLibrary.Services
{
    public interface ICustomerService
    {
        Task<ApiResponseMessage<string>> InsertCombinedCustomer(CombinedCustomerDto combinedDto);

        //Task<ApiResponseMessage<string>> InsertCustomer(CustomerDto dto);
        Task<ApiResponseMessage<IList<TblCustomer>>> GetCustomer(long cusId);
        Task<ApiResponseMessage<string>> UpdateCustomer(CustomerDto dto);
        Task<ApiResponseMessage<string>> DeleteCustomer(CustomerDto dto);
    }
}