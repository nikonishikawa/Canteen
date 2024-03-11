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
    public class ShippingStatusService : IShippingStatusService
    {
        private readonly CanteenContext _dbContext;

        public ShippingStatusService(CanteenContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponseMessage<string>> InsertShippingStatus(ShippingStatusDto dto)
        {
            try
            {
                var _insertShippingStatus = new TblShippingStatus
                {
                    Status = dto.Status
                };

                await _dbContext.TblShippingStatuses.AddAsync(_insertShippingStatus);
                await _dbContext.SaveChangesAsync();

                var res = new ApiResponseMessage<string>
                {
                    Data = "Saved ShippingStatuss Data",
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


        public async Task<ApiResponseMessage<IList<TblShippingStatus>>> GetShippingStatus(long statusId)
        {
            try
            {
                var _data = await _dbContext.TblShippingStatuses.Where(x => x.StatusId == statusId)
                    .Select(x => new TblShippingStatus
                    {
                        Status = x.Status
                    })
                    .ToListAsync();

                var res = new ApiResponseMessage<IList<TblShippingStatus>>
                {
                    Data = _data,
                    IsSuccess = true,
                    Message = "User Found"
                };

                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblShippingStatus>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }

        public async Task<ApiResponseMessage<string>> UpdateShippingStatus(ShippingStatusDto dto)
        {
            try
            {
                var shippingStatus = await _dbContext.TblShippingStatuses.FirstOrDefaultAsync(x => x.StatusId == dto.StatusId);

                if (shippingStatus != null && dto != null)
                {
                    shippingStatus.Status = dto.Status;

                    _dbContext.TblShippingStatuses.Update(shippingStatus);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "ShippingStatus Data Updated Successfully",
                        IsSuccess = false,
                        Message = ""
                    };

                    return res;
                }
                else { 
                var res = new ApiResponseMessage<string>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "ShippingStatus or DTO is null"
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


        public async Task<ApiResponseMessage<string>> DeleteShippingStatus(ShippingStatusDto dto)
        {
            try
            {
                var shippingStatus = await _dbContext.TblShippingStatuses.FirstOrDefaultAsync(e => e.StatusId == dto.StatusId);

                if (shippingStatus != null)
                {
                    _dbContext.TblShippingStatuses.Remove(shippingStatus);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "ShippingStatus Data Removed Successfully",
                        IsSuccess = true,
                        Message = ""
                    };
                    return res;
                }
                else { 
                var res = new ApiResponseMessage<string>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "ShippingStatus not found"
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
    }
}
