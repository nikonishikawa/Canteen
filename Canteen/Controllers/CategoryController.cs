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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _CategoryService;

        public CategoryController(ICategoryService CategoryService)
        {
            _CategoryService = CategoryService;
        }
        [HttpPost("InsertCategory")]
        public async Task<ActionResult<ApiResponseMessage<string>>> InsertCategory(CategoryDto dto)
        {
            try
            {
                var res = await _CategoryService.InsertCategory(dto);
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
        [HttpGet("GetCategory")]
        public async Task<ActionResult<ApiResponseMessage<IList<TblCategory>>>> GetCategory(long categoryId)
        {
            try
            {
                var res = await _CategoryService.GetCategory(categoryId);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblCategory>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }
        [HttpPut("UpdateCategory")]
        public async Task<ApiResponseMessage<TblCategory>> UpdateCategory(long categoryId, CategoryDto dto)
        {
            try
            {
                var res = await _CategoryService.UpdateCategory(categoryId, dto);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<TblCategory>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }
        [HttpDelete("Credential/DeleteCredential")]
        public async Task<ApiResponseMessage<TblCategory>> DeleteCategory(long categoryId)
        {
            try
            {
                var res = await _CategoryService.DeleteCategory(categoryId);
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<TblCategory>
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
