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
    public class OrderItemService : IOrderItemService
    {
        private readonly CanteenContext _dbContext;

        public OrderItemService(CanteenContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponseMessage<string>> InsertOrderItem(OrderItemDto dto)
        {
            try
            {
                var _insertOrderItem = new TblOrderItem
                {
                    OrderId = dto.OrderId,
                    Item = dto.Item,
                    Quantity = dto.Quantity,
                    Price = dto.Price
                };

                await _dbContext.TblOrderItems.AddAsync(_insertOrderItem);
                await _dbContext.SaveChangesAsync();

                var res = new ApiResponseMessage<string>
                {
                    Data = "Saved OrderItems Data",
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


        public async Task<ApiResponseMessage<IList<TblOrderItem>>> GetOrderItem(long orderItemId)
        {
            try
            {
                var _data = await _dbContext.TblOrderItems.Where(x => x.OrderItemId == orderItemId)
                    .Select(x => new TblOrderItem
                    {
                        OrderId = x.OrderId,
                        Item = x.Item,
                        Quantity = x.Quantity,
                        Price = x.Price
                    })
                    .ToListAsync();

                var res = new ApiResponseMessage<IList<TblOrderItem>>
                {
                    Data = _data,
                    IsSuccess = true,
                    Message = "User Found"
                };

                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblOrderItem>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }

        public async Task<ApiResponseMessage<string>> UpdateOrderItem(OrderItemDto dto)
        {
            try
            {
                var orderItem = await _dbContext.TblOrderItems.FirstOrDefaultAsync(x => x.OrderItemId == dto.OrderItemId);

                if (orderItem != null && dto != null)
                {
                    orderItem.OrderId = dto.OrderId;
                    orderItem.Item = dto.Item;
                    orderItem.Quantity = dto.Quantity;
                    orderItem.Price = dto.Price;

                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Order Item Data Updated Successfully",
                        IsSuccess = true,
                        Message = ""
                    };
                    return res;
                }
                var nullRes = new ApiResponseMessage<string>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Vendor or DTO is null"
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

        public async Task<ApiResponseMessage<string>> DeleteOrderItem(OrderItemDto dto)
        {
            try
            {
                var orderItem = await _dbContext.TblOrderItems.FirstOrDefaultAsync(e => e.OrderItemId == dto.OrderItemId);

                if (orderItem != null)
                {
                    _dbContext.TblOrderItems.Remove(orderItem);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Order Item Removed Successfully",
                        IsSuccess = true,
                        Message = ""
                    };

                    return res;
                }
                else { 
                var nullRes = new ApiResponseMessage<string>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Vendor not found"
                };
                return nullRes;
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
