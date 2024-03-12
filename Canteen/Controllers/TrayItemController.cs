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
    public class TrayItemController : ControllerBase
    {
        private readonly ITrayItemService _customerService;

        public TrayItemController(ITrayItemService customerService)
        {
            _customerService = customerService;
        }



        //[HttpPost("InsertTrayTempToTrayV2")]
        //public async Task<ApiResponseMessage<string>> InsertTrayTempToTray(TrayTempDto dto)

        //{
        //    try
        //    {
        //        var res = await _customerService.InsertTrayTempToTray(dto);
        //        return res;
        //    }
        //    catch (Exception ex)
        //    {
        //        var res = new ApiResponseMessage<string>
        //        {
        //            Data = null,
        //            IsSuccess = true,
        //            Message = ex.Message
        //        };

        //        return res;
        //    }
        //}

        //[HttpPost("InsertTempToTrayAutomatically")]
        //public async Task<ApiResponseMessage<string>> InsertTempToTrayAutomatically()
        //{
        //    try
        //    {
        //        var res = await _customerService.InsertTempToTrayAutomatically();
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

        //[HttpPost("InsertTempToTrayItemAutomatically")]
        //public async Task<ApiResponseMessage<string>> InsertTempToTrayItemAutomatically()
        //{
        //    try
        //    {
        //        var res = await _customerService.InsertTempToTrayItemAutomatically();
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

        [HttpPost("InsertTrayItemTemp")]
        public async Task<ApiResponseMessage<string>> InsertTrayItemTemp(TrayItemsTempDto dto)
        {
            try
            {
                var res = await _customerService.InsertTrayItemTemp(dto);
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

        [HttpPost("TramsferTempToTray")]
        public async Task<ApiResponseMessage<string>> InsertTempToNotTemp(TrayCombinedDto combinedDto)
        {
            try
            {
                var res = await _customerService.InsertTempToNotTemp(combinedDto);
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

        //[HttpPost("HEEEHEEE")]
        //public async Task<ApiResponseMessage<string>> InsertData(TrayCombinedDto combinedDto)
        //{
        //    try
        //    {
        //        var res = await _customerService.InsertData(combinedDto);
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
        //            Message = $"An error occurred: {ex.Message}",
        //        };

        //        return res;
        //    }
        //}

        //[HttpPost("HanTrayItemTemp")]
        //public async Task<ApiResponseMessage<string>> InsertData(TrayCombinedDto combinedDto)
        //{
        //    try
        //    {
        //        var res = await _customerService.InsertData(combinedDto);
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
        //            Message = $"An error occurred: {ex.Message}",
        //        };

        //        return res;
        //    }
        //}

        [HttpPost("InsertTrayItem")]
        public async Task<ActionResult<ApiResponseMessage<string>>> InsertTrayItem(TrayItemDto dto)
        {
            try
            {
                var res = await _customerService.InsertTrayItem(dto);
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
        [HttpGet("GetTrayItem")]
        public async Task<ActionResult<ApiResponseMessage<IList<TblTrayItem>>>> GetTrayItem(long cusId)
        {
            try
            {
                var res = await _customerService.GetTrayItem(cusId);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblTrayItem>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }
        [HttpPut("UpdateTrayItem")]
        public async Task<ApiResponseMessage<string>> UpdateTrayItem(TrayItemDto dto)
        {
            try
            {
                var res = await _customerService.UpdateTrayItem(dto);
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
        [HttpDelete("DeleteTrayItem")]
        public async Task<ApiResponseMessage<string>> DeleteTrayItem(TrayItemDto dto)
        {
            try
            {
                var res = await _customerService.DeleteTrayItem(dto);
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
