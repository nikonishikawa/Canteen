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
    public class ParcelInfoService : IParcelInfoService
    {
        private readonly CanteenContext _dbContext;

        public ParcelInfoService(CanteenContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponseMessage<string>> InsertParcelInfo(ParcelInfoDto dto)
        {
            try
            {
                var _insertParcelInfo = new TblParcelInfo
                {
                    OrderId = dto.OrderId,
                    ShipStamp = dto.ShipStamp,
                    Location = dto.Location,
                    Courier = dto.Courier,
                    Notes = dto.Notes,
                    Status = dto.Status
                };

                await _dbContext.TblParcelInfos.AddAsync(_insertParcelInfo);
                await _dbContext.SaveChangesAsync();

                var res = new ApiResponseMessage<string>
                {
                    Data = "Saved ParcelInfos Data",
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


        public async Task<ApiResponseMessage<IList<TblParcelInfo>>> GetParcelInfo(long parcelInfoId)
        {
            try
            {
                var _data = await _dbContext.TblParcelInfos.Where(x => x.TrackingId == parcelInfoId)
                    .Select(x => new TblParcelInfo
                    {
                        OrderId = x.OrderId,
                        ShipStamp = x.ShipStamp,
                        Location = x.Location,
                        Courier = x.Courier,
                        Notes = x.Notes,
                        Status = x.Status
                    })
                    .ToListAsync();

                var res = new ApiResponseMessage<IList<TblParcelInfo>>
                {
                    Data = _data,
                    IsSuccess = true,
                    Message = "User Found"
                };

                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblParcelInfo>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }

        public async Task<ApiResponseMessage<string>> UpdateParcelInfo(ParcelInfoDto dto)
        {
            try
            {
                var ParcelInformation = await _dbContext.TblParcelInfos.FirstOrDefaultAsync(x => x.TrackingId == dto.TrackingId);

                if (ParcelInformation != null && dto != null)
                {
                    ParcelInformation.OrderId = dto.OrderId;
                    ParcelInformation.ShipStamp = dto.ShipStamp;
                    ParcelInformation.Location = dto.Location;
                    ParcelInformation.Courier = dto.Courier;
                    ParcelInformation.Notes = dto.Notes;
                    ParcelInformation.Status = dto.Status;

                    _dbContext.TblParcelInfos.Update(ParcelInformation);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Parcel Information Updated successfully",
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
                    Message = "ParcelInformation or DTO is null"
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

        public async Task<ApiResponseMessage<string>> DeleteParcelInfo(ParcelInfoDto dto)
        {
            try
            {
                var ParcelInfo = await _dbContext.TblParcelInfos.FirstOrDefaultAsync(e => e.TrackingId == dto.TrackingId);

                if (ParcelInfo != null)
                {
                    _dbContext.TblParcelInfos.Remove(ParcelInfo);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Parcel Information Removed Successfully",
                        IsSuccess = true,
                        Message = ""
                    };
                    return res;
                }
                var nullRes = new ApiResponseMessage<string>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "ParcelInformation not found"
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
