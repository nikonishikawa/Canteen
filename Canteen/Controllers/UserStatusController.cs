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
    public class UserStatusController : ControllerBase
    {
        private readonly IUserStatusService _UserStatusService;

        public UserStatusController(IUserStatusService UserStatusService)
        {
            _UserStatusService = UserStatusService;
        }
        [HttpPost("InsertUserStatus")]
        public async Task<ActionResult<ApiResponseMessage<string>>> InsertUserStatus(UserStatusDto dto)
        {
            try
            {
                var res = await _UserStatusService.InsertUserStatus(dto);
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
        [HttpGet("GetUserStatus")]
        public async Task<ActionResult<ApiResponseMessage<IList<TblUserStatus>>>> GetUserStatus(long cusId)
        {
            try
            {
                var res = await _UserStatusService.GetUserStatus(cusId);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblUserStatus>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }
        [HttpPut("UpdateUserStatus")]
        public async Task<ApiResponseMessage<string>> UpdateUserStatus(UserStatusDto dto)
        {
            try
            {
                var res = await _UserStatusService.UpdateUserStatus(dto);
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
