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
    public class ArchiveController : ControllerBase
    {
        private readonly IArchiveService _ArchiveService;

        public ArchiveController(IArchiveService ArchiveService)
        {
            _ArchiveService = ArchiveService;
        }
        [HttpPost("InsertArchive")]
        public async Task<ActionResult<ApiResponseMessage<string>>> InsertArchive(ArchiveDto dto)
        {
            try
            {
                var res = await _ArchiveService.InsertArchive(dto);
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
        [HttpGet("GetArchive")]
        public async Task<ApiResponseMessage<IList<ArchiveDto>>> GetArchiveById(long ArchiveId)
        {
            try
            {
                var res = await _ArchiveService.GetArchiveById(ArchiveId);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<ArchiveDto>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }
        [HttpPut("UpdateArchive")]
        public async Task<ApiResponseMessage<string>> UpdateArchive(ArchiveDto dto)
        {
            try
            {
                var res = await _ArchiveService.UpdateArchive(dto);
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
        [HttpDelete("Credential/DeleteCredential")]
        public async Task<ApiResponseMessage<string>> DeleteArchive(ArchiveDto dto)
        {
            try
            {
                var res = await _ArchiveService.DeleteArchive(dto);
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
