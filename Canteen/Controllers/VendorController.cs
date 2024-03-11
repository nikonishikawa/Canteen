using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;
using CanteenClassLibrary.Entities;
using CanteenClassLibrary.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Canteen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendorService _service;

        public VendorController(IVendorService service)
        {
            _service = service;
        }

        [HttpGet("GetVendors")]
        public async Task<ActionResult<ApiResponseMessage<List<TblVendor>>>> GetAllVendors()
        {
            try
            {
                var getVendor = await _service.GetAllVendors();
                return Ok(getVendor);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponseMessage<List<TblVendor>>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message
                };
                return errorResponse;
            }
        }

        [HttpGet("GetVendorById")]
        public async Task<ActionResult<ApiResponseMessage<VendorDto>>> GetVendorById(long vendorId)
        {
            try
            {
                var vendor = await _service.GetVendorById(vendorId);
                if (vendor == null)
                {
                    return NotFound();
                }
                return Ok(vendor);
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponseMessage<VendorDto>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message
                };
                return errorResponse;
            }
        }

        [HttpPost("InsertVendor")]
        public async Task<ApiResponseMessage<string>> InsertVendor(VendorDto dto)
        {
            try
            {
                var res = await _service.InsertVendor(dto);
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

        [HttpPut("UpdateVendor")]
        public async Task<ApiResponseMessage<string>> UpdateVendor(VendorDto dto)
        {
            try
            {
                var updateVendor = await _service.UpdateVendor(dto);
                return updateVendor;
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponseMessage<string>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message
                };
                return errorResponse;
            }
        }

        [HttpDelete("DeleteVendor")]
        public async Task<ApiResponseMessage<string>> DeleteVendor(VendorDto dto)
        {
            try
            {
                var deleteVendor = await _service.DeleteVendor(dto);
                return deleteVendor;
            }
            catch (Exception ex)
            {
                var errorResponse = new ApiResponseMessage<string>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message
                };
                return errorResponse;
            }
        }
    }
}
