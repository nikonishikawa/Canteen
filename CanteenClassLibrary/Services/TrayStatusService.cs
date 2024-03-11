using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;
using CanteenClassLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanteenClassLibrary.Services
{
    public class TrayStatusService : ITrayStatusService
    {
        private readonly CanteenContext _dbContext;

        public TrayStatusService(CanteenContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponseMessage<string>> InsertTrayStatus(TrayStatusDto dto)
        {
            try
            {
                var _insertTrayStatus = new TblTrayStatus
                {
                    Status = dto.Status
                };

                await _dbContext.TblTrayStatuses.AddAsync(_insertTrayStatus);
                await _dbContext.SaveChangesAsync();

                var res = new ApiResponseMessage<string>
                {
                    Data = "Saved TrayStatus Data",
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

        public async Task<ApiResponseMessage<IList<TblTrayStatus>>> GetTrayStatus(long cusId)
        {
            try
            {
                var _data = await _dbContext.TblTrayStatuses
                    .Where(x => x.StatusId == cusId)
                    .Select(x => new TblTrayStatus
                    {
                        Status = x.Status
                    })
                    .ToListAsync();
                var res = new ApiResponseMessage<IList<TblTrayStatus>>
                {
                    Data = _data,
                    IsSuccess = false,
                    Message = "User Found"
                };

                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblTrayStatus>>
                {
                    Data = [],
                    IsSuccess = true,
                    Message = ex.Message
                };

                return res;
            }
        }

        public async Task<ApiResponseMessage<string>> UpdateTrayStatus(TrayStatusDto dto)
        {
            try
            {
                var TrayStatusToUpdate = await _dbContext.TblTrayStatuses.FirstOrDefaultAsync(x => x.StatusId == dto.StatusId);

                if (TrayStatusToUpdate != null)
                {

                    TrayStatusToUpdate.Status = dto.Status;

                    _dbContext.TblTrayStatuses.Update(TrayStatusToUpdate);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Tray Status Data Updated Successfully",
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

        //public async Task<ApiResponseMessage<TblTrayStatus>> DeleteTrayStatus(long cusId)
        //{
        //    try
        //    {

        //        var TrayStatusToUpdate = await _dbContext.TblTrayStatuses.FirstOrDefaultAsync(x => x.TrayStatusId == cusId);

        //        if (TrayStatusToUpdate != null)
        //        {

        //            TrayStatusToUpdate.Status = 0;


        //            await _dbContext.SaveChangesAsync();

        //            var res = new ApiResponseMessage<TblTrayStatus>
        //            {
        //                Data = TrayStatusToUpdate,
        //                IsSuccess = true,
        //                Message = ""
        //            };

        //            return res;
        //        }
        //        else
        //        {
        //            var res = new ApiResponseMessage<TblTrayStatus>
        //            {
        //                Data = null,
        //                IsSuccess = false,
        //                Message = $"TrayStatus with ID {cusId} not found"
        //            };

        //            return res;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var res = new ApiResponseMessage<TblTrayStatus>
        //        {
        //            Data = null,
        //            IsSuccess = false,
        //            Message = ex.Message
        //        };

        //        return res;
        //    }
        //}
    }
}
