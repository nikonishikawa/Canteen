using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;
using CanteenClassLibrary.Entities;

namespace CanteenClassLibrary.Services
{
    public interface ICourierService
    {
        Task<ApiResponseMessage<IList<TblCourier>>> GetCourier(long cusId);
        Task<ApiResponseMessage<string>> InsertCourier(CourierDto dto);
        Task<ApiResponseMessage<string>> UpdateCourier(CourierDto dto);
        Task<ApiResponseMessage<string>> DeleteCourier(CourierDto dto);
    }
}