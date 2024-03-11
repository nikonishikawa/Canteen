using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;
using CanteenClassLibrary.Entities;

namespace CanteenClassLibrary.Services
{
    public interface ITrayService
    {
        Task<ApiResponseMessage<string>> InsertTray(TrayDto dto);
        Task<ApiResponseMessage<IList<TblTray>>> GetTray(long cusId);
        Task<ApiResponseMessage<string>> UpdateTray(TrayDto dto);
        Task<ApiResponseMessage<string>> DeleteTray(TrayDto dto);
        Task<ApiResponseMessage<string>> InsertTrayTemp(TrayTempDto dto);
    }
}