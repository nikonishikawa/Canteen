using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;
using CanteenClassLibrary.Entities;
using CanteenClassLibrary.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Canteen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _OrderItemService;

        public OrderItemController(IOrderItemService OrderItemService)
        {
            _OrderItemService = OrderItemService;
        }
        [HttpPost("InsertOrderItem")]
        public async Task<ActionResult<ApiResponseMessage<string>>> InsertOrderItem(OrderItemDto dto)
        {
            try
            {
                var res = await _OrderItemService.InsertOrderItem(dto);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<string>
                {
                    Data = "",
                    IsSuccess = true,
                    Message = ex.Message
                };

                return res;
            }
        }

        [HttpGet("GetOrderItemById")]
        public async Task<ActionResult<ApiResponseMessage<IList<TblOrderItem>>>> GetOrderItem(long orderItemId)
        {
            try
            {
                var res = await _OrderItemService.GetOrderItem(orderItemId);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblOrderItem>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }

        [HttpPut("UpdateOrderItem")]
        public async Task<ApiResponseMessage<string>> UpdateOrderItem(OrderItemDto dto)
        {
            try
            {
                var res = await _OrderItemService.UpdateOrderItem(dto);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<string>
                {
                    Data = null,
                    IsSuccess = true,
                    Message = ex.Message
                };

                return res;
            }
        }

        [HttpDelete("DeleteOrderItem")]
        public async Task<ApiResponseMessage<string>> DeleteOrderItem(OrderItemDto dto)
        {
            try
            {
                var res = await _OrderItemService.DeleteOrderItem(dto);
                return res;

            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<string>
                {
                    Data = null,
                    IsSuccess = true,
                    Message = ex.Message
                };

                return res;
            }
        }
    }
}
