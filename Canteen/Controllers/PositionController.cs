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
    public class PositionController : ControllerBase
    {
        private readonly IPositionService _positionService;

        public PositionController(IPositionService PositionService)
        {
            _positionService = PositionService;
        }

        [HttpPost("InsertPosition")]
        public async Task<ActionResult<ApiResponseMessage<string>>> InsertPosition(PositionDto dto)
        {
            try
            {
                var res = await _positionService.InsertPosition(dto);
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

        [HttpGet("Position/GetPosition")]
        public async Task<ActionResult<ApiResponseMessage<IList<TblPosition>>>> GetPosition(long credId)
        {
            try
            {
                var res = await _positionService.GetPosition(credId);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblPosition>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };
                return res;
            }
        }

        [HttpPut("UpdatePosition")]
        public async Task<ApiResponseMessage<string>> UpdatePosition(PositionDto dto)
        {
            try
            {
                var res = await _positionService.UpdatePosition(dto);
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
        public async Task<ApiResponseMessage<string>> DeletePosition(PositionDto dto)
        {
            try
            {
                var res = await _positionService.DeletePosition(dto);
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
