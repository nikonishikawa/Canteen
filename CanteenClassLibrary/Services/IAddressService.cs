using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;
using CanteenClassLibrary.Entities;

namespace CanteenClassLibrary.Services
{
    public interface IAddressService
    {
        Task<ApiResponseMessage<IList<AddressDto>>> GetAddressById(long addressId);
        Task<ApiResponseMessage<string>> InsertAddress(AddressDto dto);
        Task<ApiResponseMessage<string>> UpdateAddress(AddressDto dto);
        Task<ApiResponseMessage<string>> DeleteAddress(AddressDto dto);
        //Task<List<TblAddress>> GetAllAddress();
    }
}