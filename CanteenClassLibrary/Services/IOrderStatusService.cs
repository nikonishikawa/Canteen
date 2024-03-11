using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;
using CanteenClassLibrary.Entities;

namespace CanteenClassLibrary.Services
{
    public interface IOrderStatusService
    {
        Task<ApiResponseMessage<IList<TblOrderStatus>>> GetOrderStatus(long cusId);
        Task<ApiResponseMessage<string>> InsertOrderStatus(OrderStatusDto dto);
        Task<ApiResponseMessage<string>> UpdateOrderStatus(OrderStatusDto dto);
    }
}