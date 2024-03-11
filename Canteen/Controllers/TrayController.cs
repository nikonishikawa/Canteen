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
    public class TrayController : ControllerBase
    {
        private readonly ITrayService _TrayService;

        public TrayController(ITrayService TrayService)
        {
            _TrayService = TrayService;
        }

        [HttpPost("InsertTrayItemTemp")]
        public async Task<ApiResponseMessage<string>> InsertTrayTemp(TrayTempDto dto)
        {
            try
            {
                var res = await _TrayService.InsertTrayTemp(dto);
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

        [HttpPost("InsertTray")]
        public async Task<ActionResult<ApiResponseMessage<string>>> InsertTray(TrayDto dto)
        {
            try
            {
                var res = await _TrayService.InsertTray(dto);
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

        [HttpGet("GetTray")]
        public async Task<ActionResult<ApiResponseMessage<IList<TblTray>>>> GetTray(long trayId)
        {
            try
            {
                var res = await _TrayService.GetTray(trayId);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblTray>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };
                return res;
            }
        }

        [HttpPut("UpdateTray")]
        public async Task<ApiResponseMessage<string>> UpdateTray(TrayDto dto)
        {
            try
            {
                var res = await _TrayService.UpdateTray(dto);
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

        [HttpDelete("DeleteCredential")]
        public async Task<ApiResponseMessage<string>> DeleteTray(TrayDto dto)
        {
            try
            {
                var res = await _TrayService.DeleteTray(dto);
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
