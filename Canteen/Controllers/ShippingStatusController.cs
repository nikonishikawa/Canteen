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
    public class ShippingStatusController : ControllerBase
    {
        private readonly IShippingStatusService _shippingStatusService;

        public ShippingStatusController(IShippingStatusService ShippingStatusService)
        {
            _shippingStatusService = ShippingStatusService;
        }
        [HttpPost("InsertShippingStatus")]
        public async Task<ActionResult<ApiResponseMessage<string>>> InsertShippingStatus(ShippingStatusDto dto)
        {
            try
            {
                var res = await _shippingStatusService.InsertShippingStatus(dto);
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
        [HttpGet("GetShippingStatus")]
        public async Task<ActionResult<ApiResponseMessage<IList<TblShippingStatus>>>> GetShippingStatus(long shipStatusId)
        {
            try
            {
                var res = await _shippingStatusService.GetShippingStatus(shipStatusId);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblShippingStatus>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }

        [HttpPut("UpdateShippingStatus")]
        public async Task<ApiResponseMessage<string>> UpdateShippingStatus(ShippingStatusDto dto)
        {
            try

            {
                var res = await _shippingStatusService.UpdateShippingStatus(dto);
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

        [HttpDelete("DeleteShippingStatus")]
        public async Task<ApiResponseMessage<string>> DeleteShippingStatus(ShippingStatusDto dto)
        {
            try
                {
                var res = await _shippingStatusService.DeleteShippingStatus(dto);
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
