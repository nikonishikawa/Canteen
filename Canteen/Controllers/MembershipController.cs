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
    public class MembershipController : ControllerBase
    {
        private readonly IMembershipService _membershipService;

        public MembershipController(IMembershipService MembershipService)
        {
            _membershipService = MembershipService;
        }

        [HttpPost("InsertMembership")]
        public async Task<ActionResult<ApiResponseMessage<string>>> InsertMembership(MembershipDto dto)
        {
            try
            {
                var res = await _membershipService.InsertMembership(dto);
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

        [HttpGet("GetMembership")]
        public async Task<ActionResult<ApiResponseMessage<IList<TblMembership>>>> GetMembership(long credId)
        {
            try
            {
                var res = await _membershipService.GetMembership(credId);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblMembership>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }

        [HttpPut("UpdateMembership")]
        public async Task<ApiResponseMessage<string>> UpdateMembership(MembershipDto dto)
        {
            try
            {
                var res = await _membershipService.UpdateMembership(dto);
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

        [HttpDelete("DeleteMembership")]
        public async Task<ApiResponseMessage<string>> DeleteMembership(MembershipDto dto)
        {
            try
            {
                var res = await _membershipService.DeleteMembership(dto);
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
