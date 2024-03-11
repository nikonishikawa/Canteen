using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;
using CanteenClassLibrary.Entities;

namespace CanteenClassLibrary.Services
{
    public interface IItemService
    {
        Task<ApiResponseMessage<IList<TblItem>>> GetItem(long itemId);
        Task<ApiResponseMessage<string>> InsertItem(ItemDto dto);
        Task<ApiResponseMessage<string>> UpdateItem(ItemDto dto);
        Task<ApiResponseMessage<string>> DeleteItem(ItemDto dto);
    }
}