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
    public class ParcelInfoController : ControllerBase
    {
        private readonly IParcelInfoService _ParcelInfoService;

        public ParcelInfoController(IParcelInfoService ParcelInfoService)
        {
            _ParcelInfoService = ParcelInfoService;
        }

        [HttpPost("InsertParcelInfo")]
        public async Task<ActionResult<ApiResponseMessage<string>>> InsertParcelInfo(ParcelInfoDto dto)
        {
            try
            {
                var res = await _ParcelInfoService.InsertParcelInfo(dto);
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

        [HttpGet("GetParcelInfo")]
        public async Task<ActionResult<ApiResponseMessage<IList<TblParcelInfo>>>> GetParcelInfo(long parcelInfoId)
        {
            try
            {
                var res = await _ParcelInfoService.GetParcelInfo(parcelInfoId);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblParcelInfo>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }

        [HttpPut("UpdateParcelInfo")]
        public async Task<ApiResponseMessage<string>> UpdateParcelInfo(ParcelInfoDto dto)
        {
            try
            {
                var res = await _ParcelInfoService.UpdateParcelInfo(dto);
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

        [HttpDelete("DeleteParcelInfo")]
        public async Task<ApiResponseMessage<string>> DeleteParcelInfo(ParcelInfoDto dto)
        { 
                try
                {
                var res = await _ParcelInfoService.DeleteParcelInfo(dto);
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
