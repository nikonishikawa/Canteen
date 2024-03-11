using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;
using CanteenClassLibrary.Entities;

namespace CanteenClassLibrary.Services
{
    public interface ICategoryService
    {
        Task<ApiResponseMessage<TblCategory>> DeleteCategory(long CategoryId);
        Task<ApiResponseMessage<IList<TblCategory>>> GetCategory(long CategoryId);
        Task<ApiResponseMessage<string>> InsertCategory(CategoryDto dto);
        Task<ApiResponseMessage<TblCategory>> UpdateCategory(long CategoryId, CategoryDto dto);
    }
}