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
    public class OrderStatusService : IOrderStatusService
    {
        private readonly CanteenContext _dbContext;

        public OrderStatusService(CanteenContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ApiResponseMessage<string>> InsertOrderStatus(OrderStatusDto dto)
        {
            try
            {
                var _insertOrderStatus = new TblOrderStatus
                {
                    CusId = dto.CusId,
                    OrderStamp = dto.OrderStamp,
                    Cost = dto.Cost
                };

                await _dbContext.TblOrderStatuses.AddAsync(_insertOrderStatus);
                await _dbContext.SaveChangesAsync();

                var res = new ApiResponseMessage<string>
                {
                    Data = "Saved OrderStatus Data",
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

        public async Task<ApiResponseMessage<IList<TblOrderStatus>>> GetOrderStatus(long cusId)
        {
            try
            {
                var _data = await _dbContext.TblOrderStatuses
                    .Where(x => x.OrderId == cusId)
                    .Select(x => new TblOrderStatus
                    {
                        CusId = x.CusId,
                        OrderStamp = x.OrderStamp,
                        Cost = x.Cost,

                    })
                    .ToListAsync();
                var res = new ApiResponseMessage<IList<TblOrderStatus>>
                {
                    Data = _data,
                    IsSuccess = false,
                    Message = "User Found"
                };

                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblOrderStatus>>
                {
                    Data = [],
                    IsSuccess = true,
                    Message = ex.Message
                };

                return res;
            }
        }

        public async Task<ApiResponseMessage<string>> UpdateOrderStatus(OrderStatusDto dto)
        {
            try
            {

                var OrderStatusToUpdate = await _dbContext.TblOrderStatuses.FirstOrDefaultAsync(x => x.OrderId == dto.OrderId);

                if (OrderStatusToUpdate != null)
                {
                    OrderStatusToUpdate.CusId = dto.CusId;
                    OrderStatusToUpdate.OrderStamp = dto.OrderStamp;
                    OrderStatusToUpdate.Cost = dto.Cost;

                    _dbContext.TblOrderStatuses.Update(OrderStatusToUpdate);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Order Status Data Updated Successfully",
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

        //public async Task<ApiResponseMessage<TblOrderStatus>> DeleteOrderStatus(long cusId)
        //{
        //    try
        //    {

        //        var OrderStatusToUpdate = await _dbContext.TblOrderStatuses.FirstOrDefaultAsync(x => x.OrderId == cusId);

        //        if (OrderStatusToUpdate != null)
        //        {

        //            OrderStatusToUpdate.Status = 0;


        //            await _dbContext.SaveChangesAsync();

        //            var res = new ApiResponseMessage<TblOrderStatus>
        //            {
        //                Data = OrderStatusToUpdate,
        //                IsSuccess = true,
        //                Message = ""
        //            };

        //            return res;
        //        }
        //        else
        //        {
        //            var res = new ApiResponseMessage<TblOrderStatus>
        //            {
        //                Data = null,
        //                IsSuccess = false,
        //                Message = $"OrderStatus with ID {cusId} not found"
        //            };

        //            return res;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var res = new ApiResponseMessage<TblOrderStatus>
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
