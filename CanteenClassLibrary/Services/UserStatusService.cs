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
    public class UserStatusService : IUserStatusService
    {
        private readonly CanteenContext _dbContext;

        public UserStatusService(CanteenContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponseMessage<string>> InsertUserStatus(UserStatusDto dto)
        {
            try
            {
                var _insertUserStatus = new TblUserStatus
                {
                    Status = dto.Status
                };

                await _dbContext.TblUserStatuses.AddAsync(_insertUserStatus);
                await _dbContext.SaveChangesAsync();

                var res = new ApiResponseMessage<string>
                {
                    Data = "Saved UserStatus Data",
                    IsSuccess = true,
                    Message = ""
                };

                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<string>
                {
                    Data = "",
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }

        public async Task<ApiResponseMessage<IList<TblUserStatus>>> GetUserStatus(long userStatusId)
        {
            try
            {
                var _data = await _dbContext.TblUserStatuses
                    .Where(x => x.UserStatusId == userStatusId)
                    .Select(x => new TblUserStatus
                    {
                        Status = x.Status
                    })
                    .ToListAsync();

                var res = new ApiResponseMessage<IList<TblUserStatus>>
                {
                    Data = _data,
                    IsSuccess = false,
                    Message = "User Found"
                };

                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblUserStatus>>
                {
                    Data = [],
                    IsSuccess = true,
                    Message = ex.Message
                };

                return res;
            }
        }

        public async Task<ApiResponseMessage<string>> UpdateUserStatus(UserStatusDto dto)
        {
            try
            {

                var UserStatusToUpdate = await _dbContext.TblUserStatuses.FirstOrDefaultAsync(x => x.UserStatusId == dto.UserStatusId);

                if (UserStatusToUpdate != null)
                {
                    UserStatusToUpdate.Status = dto.Status;

                    _dbContext.TblUserStatuses.Update(UserStatusToUpdate);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "User Status Data Updated Successfully!",
                        IsSuccess = true,
                        Message = ""
                    };

                    return res;
                }
                else
                {
                    var res = new ApiResponseMessage<string>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = ""
                    };
                    return res;
                }
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

        public Task<ApiResponseMessage<TblUserStatus>> ArchiveUserStatus(long cusId)
        {
            throw new NotImplementedException();
        }
    }
}
