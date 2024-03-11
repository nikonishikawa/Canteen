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
    public class GeneralAddressController : ControllerBase
    {
        private readonly IGeneralAddressService _generalAddressService;

        public GeneralAddressController(IGeneralAddressService GeneralAddressService)
        {
            _generalAddressService = GeneralAddressService;
        }

        [HttpPost("InsertGeneralAddress")]
        public async Task<ActionResult<ApiResponseMessage<string>>> InsertGeneralAddress(AddressGeneralDto dto)
        {
            try
            {
                var res = await _generalAddressService.InsertGeneralAddress(dto);
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

        [HttpGet("GetGeneralAddress")]
        public async Task<ActionResult<ApiResponseMessage<IList<TblAddressGeneral>>>> GetGeneralAddress(long credId)
        {
            try
            {
                var res = await _generalAddressService.GetGeneralAddress(credId);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblAddressGeneral>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }

        [HttpPut("UpdateGeneralAddress")]
        public async Task<ApiResponseMessage<string>> UpdateGenralAddress(AddressGeneralDto dto)
        {
            try
            {
                var res = await _generalAddressService.UpdateGenralAddress(dto);
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

        [HttpDelete("DeleteGeneralAddress")]
        public async Task<ApiResponseMessage<string>> DeleteGenralAddress(AddressGeneralDto dto)
        {
            try
            {
                var res = await _generalAddressService.DeleteGenralAddress(dto);
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
