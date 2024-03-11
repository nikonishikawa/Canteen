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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("InsertCustomer")]
        public async Task<ActionResult<ApiResponseMessage<string>>> InsertCustomer(CustomerDto dto)
        {
            try
            {
                var res = await _customerService.InsertCustomer(dto);
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

        [HttpGet("GetCustomer")]
        public async Task<ActionResult<ApiResponseMessage<IList<TblCustomer>>>> GetCustomer(long cusId)
        {
            try
            {
                var res = await _customerService.GetCustomer(cusId);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblCustomer>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }

        [HttpPut("UpdateCustomer")]
        public async Task<ApiResponseMessage<string>> UpdateCustomer(CustomerDto dto)
        {
            try
            {
                var res = await _customerService.UpdateCustomer(dto);
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
        public async Task<ApiResponseMessage<string>> DeleteCustomer(CustomerDto dto)
        {
            try
            {
                var res = await _customerService.DeleteCustomer(dto);
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
