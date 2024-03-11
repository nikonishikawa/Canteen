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
    public class CredentialController : ControllerBase
    {
        private readonly ICredentialService _credentialService;

        public CredentialController(ICredentialService CredentialService)
        {
            _credentialService = CredentialService;
        }
        [HttpPost("InsertCredential")]
        public async Task<ActionResult<ApiResponseMessage<string>>> InsertCredential(CredentialDto dto)
        {
            try
            {
                var res = await _credentialService.InsertCredential(dto);
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
        [HttpGet("GetCredential")]
        public async Task<ActionResult<ApiResponseMessage<IList<TblCredential>>>> GetCredential(long credId)
        {
            try
            {
                var res = await _credentialService.GetCredential(credId);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblCredential>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }
        [HttpPut("UpdateCredential")]
        public async Task<ApiResponseMessage<string>> UpdateCredential(CredentialDto dto)
        {
            try
            {
                var res = await _credentialService.UpdateCredential(dto);
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
        public async Task<ApiResponseMessage<string>> DeleteCredential(CredentialDto dto)
        {
            try
            {
                var res = await _credentialService.DeleteCredential(dto);
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
