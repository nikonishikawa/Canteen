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
    public class OrderStatusController : ControllerBase
    {
        private readonly IOrderStatusService _OrderStatusService;

        public OrderStatusController(IOrderStatusService OrderStatusService)
        {
            _OrderStatusService = OrderStatusService;
        }

        [HttpPost("InsertOrderStatus")]
        public async Task<ActionResult<ApiResponseMessage<string>>> InsertOrderStatus(OrderStatusDto dto)
        {
            try
            {
                var res = await _OrderStatusService.InsertOrderStatus(dto);
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in InsertName: {ex.Message}");
                Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");

                var res = new ApiResponseMessage<string>
                {
                    Data = "",
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }

        [HttpGet("GetOrderStatus")]
        public async Task<ActionResult<ApiResponseMessage<IList<TblOrderStatus>>>> GetOrderStatus(long orderId)
        {
            try
            {
                var res = await _OrderStatusService.GetOrderStatus(orderId);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblOrderStatus>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }

        [HttpPut("UpdateOrderStatus")]
        public async Task<ApiResponseMessage<string>> UpdateOrderStatus(OrderStatusDto dto)
        {
            try
            {
                var res = await _OrderStatusService.UpdateOrderStatus(dto);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<string>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }

        //[HttpDelete("Credential/DeleteCredential")]
        //public async Task<ApiResponseMessage<TblOrderStatus>> DeleteOrderStatus(long orderId)
        //{
        //    try
        //    {
        //        var res = await _OrderStatusService.DeleteOrderStatus(orderId);
        //        return res;
        //    }
        //    catch (Exception ex)
        //    {
        //        var res = new ApiResponseMessage<TblOrderStatus>
        //        {
        //            Data = null,
        //            IsSuccess = false,
        //            Message = ex.Message
        //        };

        //        return res;
        //    }
        //}
    }
}
