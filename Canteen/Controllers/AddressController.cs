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
    public class AddressController : ControllerBase

    {
        private readonly IAddressService _service;

        public AddressController(IAddressService service)
        {
            _service = service;
        }

        

        [HttpPost("AddAddress")]
        public async Task<ApiResponseMessage<string>> InsertAddress(AddressDto dto)
        {
            try
            {
                var res = await _service.InsertAddress(dto);
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

        [HttpGet("GetAddressById")]
        public async Task<ApiResponseMessage<IList<AddressDto>>> GetAddressById(long addressId)
        {
            try
            {
                var res = await _service.GetAddressById(addressId);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<AddressDto>>
                {
                    Data = null,
                    IsSuccess = true,
                    Message = ex.Message
                };
                return res;
            }
        }

        [HttpPut("UpdateAddress")]
        public async Task<ApiResponseMessage<string>> UpdateAddress(AddressDto dto)
        {
            try
            {
                var res = await _service.UpdateAddress(dto);
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

        [HttpDelete("DeleteAddress")]
        public async Task<ApiResponseMessage<string>> DeleteAddress(AddressDto dto)
        {
            try
            {
                var res = await _service.DeleteAddress(dto);
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
