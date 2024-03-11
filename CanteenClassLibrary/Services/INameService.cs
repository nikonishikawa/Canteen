using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;
using CanteenClassLibrary.Entities;

namespace CanteenClassLibrary.Services
{
    public interface INameService
    {
        Task<ApiResponseMessage<IList<TblName>>> GetName(long credId);
        Task<ApiResponseMessage<string>> InsertName(NameDto dto);
        Task<ApiResponseMessage<string>> UpdateName(NameDto dto);
        Task<ApiResponseMessage<string>> DeleteName(NameDto dto);
    }
}