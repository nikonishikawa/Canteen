using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;
using CanteenClassLibrary.Entities;

namespace CanteenClassLibrary.Services
{
    public interface IGeneralAddressService
    {
        Task<ApiResponseMessage<string>> InsertGeneralAddressWithAddress(CombinedAddressGeneralDto combinedDto);
        Task<ApiResponseMessage<IList<TblAddressGeneral>>> GetGeneralAddress(long genAddressId);
        //Task<ApiResponseMessage<string>> InsertGeneralAddress(AddressGeneralDto dto);
        Task<ApiResponseMessage<string>> UpdateGenralAddress(AddressGeneralDto dto);
        Task<ApiResponseMessage<string>> DeleteGenralAddress(AddressGeneralDto dto);
    }
}