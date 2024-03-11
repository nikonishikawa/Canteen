using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;
using CanteenClassLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CanteenClassLibrary.Services
{
    public class ArchiveService : IArchiveService
    {
        private readonly CanteenContext _dbContext;

        public ArchiveService(CanteenContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponseMessage<IList<ArchiveDto>>> GetArchiveById(long ArchiveId)
        {
            try
            {
                var Archive = await _dbContext.TblArchives.FirstOrDefaultAsync(x => x.ArchiveId == ArchiveId);

                if (Archive != null)
                {
                    var ArchiveDtoList = new List<ArchiveDto>
            {
                new ArchiveDto
                {
                    ArchiveId = Archive.ArchiveId,
                    ArchivedBy = Archive.ArchivedBy,
                    ArchiveStamp = Archive.ArchiveStamp,
                    Status = Archive.Status
                }
            };

                    var res = new ApiResponseMessage<IList<ArchiveDto>>
                    {
                        Data = ArchiveDtoList,
                        IsSuccess = true,
                        Message = "Archive retrieved successfully"
                    };

                    return res;
                }
                else
                {
                    var res = new ApiResponseMessage<IList<ArchiveDto>>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = "Archive not found"
                    };

                    return res;
                }
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<ArchiveDto>>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }


        public async Task<ApiResponseMessage<string>> InsertArchive(ArchiveDto dto)
        {
            try
            {
                var newArchive = new TblArchive
                {
                    ArchiveId = dto.ArchiveId,
                    ArchivedBy = dto.ArchivedBy,
                    ArchiveStamp = dto.ArchiveStamp,
                    Status = dto.Status
                };

                await _dbContext.TblArchives.AddAsync(newArchive);
                await _dbContext.SaveChangesAsync();

                var res = new ApiResponseMessage<string>
                {
                    Data = "Saved Archive Data",
                    IsSuccess = true,
                    Message = "Archive inserted successfully"
                };

                return res;
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }

                var res = new ApiResponseMessage<string>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }


        public async Task<ApiResponseMessage<string>> UpdateArchive(ArchiveDto dto)
        {
            try
            {
                var Archive = await _dbContext.TblArchives.FirstOrDefaultAsync(x => x.ArchiveId == dto.ArchiveId);

                if (Archive != null && dto != null)
                {
                    Archive.ArchiveId = dto.ArchiveId;
                    Archive.ArchivedBy = dto.ArchivedBy;
                    Archive.ArchiveStamp = dto.ArchiveStamp;
                    Archive.Status = dto.Status;

                    _dbContext.TblArchives.Update(Archive);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "updated Archive successfully",
                        IsSuccess = false,
                        Message = ""
                    };

                    return res;
                }

                var nullRes = new ApiResponseMessage<string>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Archive or DTO is null"
                };

                return nullRes;
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


        public async Task<ApiResponseMessage<string>> DeleteArchive(ArchiveDto dto)
        {
            try
            {
                var Archive = await _dbContext.TblArchives.FirstOrDefaultAsync(e => e.ArchiveId == dto.ArchiveId);

                if (Archive != null)
                {

                    _dbContext.TblArchives.Remove(Archive);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Deleted Archive successfully!",
                        IsSuccess = true,
                        Message = ""
                    };

                    return res;
                }

                var nullRes = new ApiResponseMessage<string>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Archive not found"
                };

                return nullRes;
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
