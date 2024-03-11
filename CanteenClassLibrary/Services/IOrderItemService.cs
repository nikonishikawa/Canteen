using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;
using CanteenClassLibrary.Entities;

namespace CanteenClassLibrary.Services
{
    public interface IOrderItemService
    {
        Task<ApiResponseMessage<IList<TblOrderItem>>> GetOrderItem(long orderItemId);
        Task<ApiResponseMessage<string>> InsertOrderItem(OrderItemDto dto);
        Task<ApiResponseMessage<string>> UpdateOrderItem(OrderItemDto dto);
        Task<ApiResponseMessage<string>> DeleteOrderItem(OrderItemDto dto);
    }
}