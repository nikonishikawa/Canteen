using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;
using CanteenClassLibrary.Entities;

namespace CanteenClassLibrary.Services
{
    public interface IUserStatusService
    {
        Task<ApiResponseMessage<TblUserStatus>> ArchiveUserStatus(long cusId);
        Task<ApiResponseMessage<IList<TblUserStatus>>> GetUserStatus(long cusId);
        Task<ApiResponseMessage<string>> InsertUserStatus(UserStatusDto dto);
        Task<ApiResponseMessage<string>> UpdateUserStatus(UserStatusDto dto);
    }
}