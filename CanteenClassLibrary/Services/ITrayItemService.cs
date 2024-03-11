using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;
using CanteenClassLibrary.Entities;

namespace CanteenClassLibrary.Services
{
    public interface ITrayItemService
    {
        Task<ApiResponseMessage<string>> InsertTempToNotTemp(TrayCombinedDto combinedDto);
        Task<ApiResponseMessage<string>> InsertData(TrayCombinedDto combinedDto);
        Task<ApiResponseMessage<string>> InsertTrayTemp(TrayItemsTempDto dto);
        Task<ApiResponseMessage<string>> InsertDisData(TrayCombinedDto combinedDto);
        Task<ApiResponseMessage<IList<TblTrayItem>>> GetTrayItem(long trayItemId);
        Task<ApiResponseMessage<string>> InsertTrayItem(TrayItemDto dto);
        Task<ApiResponseMessage<string>> UpdateTrayItem(TrayItemDto dto);
        Task<ApiResponseMessage<string>> DeleteTrayItem(TrayItemDto dto);
      
    }
}