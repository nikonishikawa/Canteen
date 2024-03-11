using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;

namespace CanteenClassLibrary.Services
{
    public interface IAdminService
    {
        Task<ApiResponseMessage<string>> DeleteAdmin(AdminDto dto);
        Task<ApiResponseMessage<IList<AdminDto>>> GetAdminById(long AdminId);
        Task<ApiResponseMessage<string>> InsertAdmin(AdminDto dto);
        Task<ApiResponseMessage<string>> UpdateAdmin(AdminDto dto);
    }
}