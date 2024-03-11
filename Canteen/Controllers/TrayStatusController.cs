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
    public class TrayStatusController : ControllerBase
    {
        private readonly ITrayStatusService _TrayStatusService;

        public TrayStatusController(ITrayStatusService TrayStatusService)
        {
            _TrayStatusService = TrayStatusService;
        }
        [HttpPost("InsertTrayStatus")]
        public async Task<ActionResult<ApiResponseMessage<string>>> InsertTrayStatus(TrayStatusDto dto)
        {
            try
            {
                var res = await _TrayStatusService.InsertTrayStatus(dto);
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
        [HttpGet("GetTrayStatus")]
        public async Task<ActionResult<ApiResponseMessage<IList<TblTrayStatus>>>> GetTrayStatus(long trayStatusId)
        {
            try
            {
                var res = await _TrayStatusService.GetTrayStatus(trayStatusId);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblTrayStatus>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }
        [HttpPut("UpdateTrayStatus")]
        public async Task<ApiResponseMessage<string>> UpdateTrayStatus(TrayStatusDto dto)
        {
            try
            {
                var res = await _TrayStatusService.UpdateTrayStatus(dto);
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
        //public async Task<ApiResponseMessage<TblTrayStatus>> DeleteTrayStatus(long trayStatusId)
        //{
        //    try
        //    {
        //        var res = await _TrayStatusService.DeleteTrayStatus(trayStatusId);
        //        return res;
        //    }
        //    catch (Exception ex)
        //    {
        //        var res = new ApiResponseMessage<TblTrayStatus>
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
