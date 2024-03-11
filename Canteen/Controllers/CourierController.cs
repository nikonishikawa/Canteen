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
    public class CourierController : ControllerBase
    {
        private readonly ICourierService _courierService;

        public CourierController(ICourierService courierService)
        {
            _courierService = courierService;
        }
        [HttpPost("InsertCourier")]
        public async Task<ActionResult<ApiResponseMessage<string>>> InsertCourier(CourierDto dto)
        {
            try
            {
                var res = await _courierService.InsertCourier(dto);
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
        [HttpGet("GetCourier")]
        public async Task<ActionResult<ApiResponseMessage<IList<TblCourier>>>> GetCourier(long courierId)
        {
            try
            {
                var res = await _courierService.GetCourier(courierId);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblCourier>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }
        [HttpPut("UpdateCourier")]
        public async Task<ApiResponseMessage<string>> UpdateCourier(CourierDto dto)
        {
            try
            {
                var res = await _courierService.UpdateCourier(dto);
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
        [HttpDelete("DeleteCourier")]
        public async Task<ApiResponseMessage<string>> DeleteCourier(CourierDto dto)
        {
            try
            {
                var res = await _courierService.DeleteCourier(dto);
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
    }
}
