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
    public class ItemController : ControllerBase
    {
        private readonly IItemService _ItemService;

        public ItemController(IItemService ItemService)
        {
            _ItemService = ItemService;
        }

        [HttpPost("InsertItem")]
        public async Task<ActionResult<ApiResponseMessage<string>>> InsertItem(ItemDto dto)
        {
            try
            {
                var res = await _ItemService.InsertItem(dto);
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

        [HttpGet("GetItem")]
        public async Task<ActionResult<ApiResponseMessage<IList<TblItem>>>> GetItem(long itemId)
        {
            try
            {
                var res = await _ItemService.GetItem(itemId);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblItem>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }

        [HttpPut("UpdateItem")]
        public async Task<ApiResponseMessage<string>> UpdateItem(ItemDto dto)
        {
            try
            {
                var res = await _ItemService.UpdateItem(dto);
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
        public async Task<ApiResponseMessage<string>> DeleteItem(ItemDto dto)
        {
            try
            {
                var res = await _ItemService.DeleteItem(dto);
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
