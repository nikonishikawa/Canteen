using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;
using CanteenClassLibrary.Entities;
using CanteenClassLibrary.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Canteen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NameController : ControllerBase
    {
        private readonly INameService _nameService;

        public NameController(INameService nameService)
        {
            _nameService = nameService;
        }

        [HttpPost("InsertName")]
        public async Task<ApiResponseMessage<string>> InsertName(NameDto dto)
        {
           try
            {
                var res = await _nameService.InsertName(dto);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<string>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.InnerException!.Message
                };
                return res;
            }
        }

        [HttpGet("GetName/{id}")]
        public async Task<ActionResult<ApiResponseMessage<IList<TblName>>>> GetName(long nameId)
        {
            try
            {
                var res = await _nameService.GetName(nameId);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblName>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.InnerException!.Message
                };

                return res;
            }
        }

        [HttpPut("UpdateName")]
        public async Task<ApiResponseMessage<string>> UpdateName(NameDto dto)
        {
            try
            {
                var res = await _nameService.UpdateName(dto);
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

        [HttpDelete("DeleteName")]
        public async Task<ApiResponseMessage<string>> DeleteName(NameDto dto)
        {
            try
            {
                var res = await _nameService.DeleteName(dto);
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