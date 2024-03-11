using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;

namespace CanteenClassLibrary.Services
{
    public interface IArchiveService
    {
        Task<ApiResponseMessage<string>> DeleteArchive(ArchiveDto dto);
        Task<ApiResponseMessage<IList<ArchiveDto>>> GetArchiveById(long ArchiveId);
        Task<ApiResponseMessage<string>> InsertArchive(ArchiveDto dto);
        Task<ApiResponseMessage<string>> UpdateArchive(ArchiveDto dto);
    }
}