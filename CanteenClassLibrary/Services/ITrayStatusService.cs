using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;
using CanteenClassLibrary.Entities;

namespace CanteenClassLibrary.Services
{
    public interface ITrayStatusService
    {
        Task<ApiResponseMessage<string>> InsertTrayStatus(TrayStatusDto dto);
        Task<ApiResponseMessage<IList<TblTrayStatus>>> GetTrayStatus(long cusId);
        Task<ApiResponseMessage<string>> UpdateTrayStatus(TrayStatusDto dto);
        //Task<ApiResponseMessage<TblTrayStatus>> DeleteTrayStatus(long cusId);
    }
}