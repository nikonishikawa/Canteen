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
    public class CourierService : ICourierService
    {
        private readonly CanteenContext _dbContext;

        public CourierService(CanteenContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponseMessage<string>> InsertCourier(CourierDto dto)
        {
            try
            {
                var _insertCourier = new TblCourier
                {
                    Courier = dto.Courier,
                    Status = dto.Status
                };

                await _dbContext.TblCouriers.AddAsync(_insertCourier);
                await _dbContext.SaveChangesAsync();

                var res = new ApiResponseMessage<string>
                {
                    Data = "Saved Couriers Data",
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


        public async Task<ApiResponseMessage<IList<TblCourier>>> GetCourier(long courierId)
        {
            try
            {
                var _data = await _dbContext.TblCouriers.Where(x => x.CourierId == courierId)
                    .Select(x => new TblCourier
                    {
                        Courier = x.Courier,
                        Status = x.Status
                    })
                    .ToListAsync();

                var res = new ApiResponseMessage<IList<TblCourier>>
                {
                    Data = _data,
                    IsSuccess = true,
                    Message = "User Found"
                };

                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblCourier>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }

        public async Task<ApiResponseMessage<string>> UpdateCourier(CourierDto dto)
        {
            try
            {
                var creds = await _dbContext.TblCouriers.FirstOrDefaultAsync(x => x.CourierId == dto.CourierId);

                if (creds != null && dto != null)
                {
                    creds.Courier = dto.Courier;
                    creds.Status = dto.Status;

                    _dbContext.TblCouriers.Update(creds);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Courier data updated successfully",
                        IsSuccess = true,
                        Message = ""
                    };

                    return res;
                }

                var nullRes = new ApiResponseMessage<string>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Courier or DTO is null"
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

        public async Task<ApiResponseMessage<string>> DeleteCourier(CourierDto dto)
        {
            try
            {
                var creds = await _dbContext.TblCouriers.FirstOrDefaultAsync(e => e.CourierId == dto.CourierId);

                if (creds != null)
                {
                    _dbContext.TblCouriers.Remove(creds);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Courier removed successfully!",
                        IsSuccess = true,
                        Message = ""
                    };

                    return res;
                }

                var nullRes = new ApiResponseMessage<string>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Courier not found"
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
