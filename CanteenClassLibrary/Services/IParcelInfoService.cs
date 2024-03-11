using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;
using CanteenClassLibrary.Entities;

namespace CanteenClassLibrary.Services
{
    public interface IParcelInfoService
    {
        Task<ApiResponseMessage<IList<TblParcelInfo>>> GetParcelInfo(long parcelInfoId);
        Task<ApiResponseMessage<string>> InsertParcelInfo(ParcelInfoDto dto);
        Task<ApiResponseMessage<string>> UpdateParcelInfo(ParcelInfoDto dto);
        Task<ApiResponseMessage<string>> DeleteParcelInfo(ParcelInfoDto dto);
    }
}