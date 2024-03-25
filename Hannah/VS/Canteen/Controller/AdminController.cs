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
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _AdminService;

        public AdminController(IAdminService AdminService)
        {
            _AdminService = AdminService;
        }
        //[HttpPost("InsertAdmin")]
        //public async Task<ActionResult<ApiResponseMessage<string>>> InsertAdmin(AdminDto dto)
        //{
        //    try
        //    {
        //        var res = await _AdminService.InsertAdmin(dto);
        //        return res;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error in InsertName: {ex.Message}");
        //        Console.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
        //        Console.WriteLine($"Stack Trace: {ex.StackTrace}");

        //        var res = new ApiResponseMessage<string>
        //        {
        //            Data = "",
        //            IsSuccess = false,
        //            Message = ex.Message
        //        };

        //        return res;
        //    }
        //}
        
        [HttpPost("InsertAdmin")]
        public async Task<ActionResult<ApiResponseMessage<string>>> InsertCombinedAdmin(CombinedAdminDto dto)
        {
            try
            {
                var res = await _AdminService.InsertCombinedAdmin(dto);
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
        [HttpGet("GetAdmin")]
        public async Task<ApiResponseMessage<IList<AdminDto>>> GetAdminById(long AdminId)
        {
            try
            {
                var res = await _AdminService.GetAdminById(AdminId);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<AdminDto>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }
        [HttpPut("UpdateAdmin")]
        public async Task<ApiResponseMessage<string>> UpdateAdmin(AdminDto dto)
        {
            try
            {
                var res = await _AdminService.UpdateAdmin(dto);
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
        [HttpDelete("DeleteAdmin")]
        public async Task<ApiResponseMessage<string>> DeleteAdmin(AdminDto dto)
        {
            try
            {
                var res = await _AdminService.DeleteAdmin(dto);
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
