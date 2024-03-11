using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;
using CanteenClassLibrary.Entities;

namespace CanteenClassLibrary.Services
{
    public interface ICredentialService
    {
        Task<ApiResponseMessage<IList<TblCredential>>> GetCredential(long credId);
        Task<ApiResponseMessage<string>> InsertCredential(CredentialDto dto);
        Task<ApiResponseMessage<string>> UpdateCredential(CredentialDto dto);
        Task<ApiResponseMessage<string>> DeleteCredential(CredentialDto dto);
    }
}