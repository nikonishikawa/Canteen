using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;
using CanteenClassLibrary.Entities;

namespace CanteenClassLibrary.Services
{
    public interface IPositionService
    {
        Task<ApiResponseMessage<IList<TblPosition>>> GetPosition(long memberId);
        Task<ApiResponseMessage<string>> InsertPosition(PositionDto dto);
        Task<ApiResponseMessage<string>> UpdatePosition(PositionDto dto);
        Task<ApiResponseMessage<string>> DeletePosition(PositionDto dto);
        
        }
}