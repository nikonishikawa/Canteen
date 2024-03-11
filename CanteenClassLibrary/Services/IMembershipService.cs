using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;
using CanteenClassLibrary.Entities;

namespace CanteenClassLibrary.Services
{
    public interface IMembershipService
    {
        Task<ApiResponseMessage<IList<TblMembership>>> GetMembership(long memberId);
        Task<ApiResponseMessage<string>> InsertMembership(MembershipDto dto);
        Task<ApiResponseMessage<string>> UpdateMembership(MembershipDto dto);
        Task<ApiResponseMessage<string>> DeleteMembership(MembershipDto dto);
    }
}