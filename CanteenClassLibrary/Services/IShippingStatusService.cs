using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;
using CanteenClassLibrary.Entities;

namespace CanteenClassLibrary.Services
{
    public interface IShippingStatusService
    {
        Task<ApiResponseMessage<IList<TblShippingStatus>>> GetShippingStatus(long genAddressId);
        Task<ApiResponseMessage<string>> InsertShippingStatus(ShippingStatusDto dto);
        Task<ApiResponseMessage<string>> UpdateShippingStatus(ShippingStatusDto dto);
        Task<ApiResponseMessage<string>> DeleteShippingStatus(ShippingStatusDto dto);
    }
}