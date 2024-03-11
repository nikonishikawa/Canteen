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
    public class ItemService : IItemService
    {
        private readonly CanteenContext _dbContext;

        public ItemService(CanteenContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponseMessage<string>> InsertItem(ItemDto dto)
        {
            try
            {
                var _insertItem = new TblItem
                {
                    Item = dto.Item,
                    Description = dto.Description,
                    FoodImage = dto.FoodImage,
                    IsHalal = dto.IsHalal,
                    Price = dto.Price,
                    Category = dto.Category
                };

                await _dbContext.TblItems.AddAsync(_insertItem);
                await _dbContext.SaveChangesAsync();

                var res = new ApiResponseMessage<string>
                {
                    Data = "Saved Item Data",
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

        public async Task<ApiResponseMessage<IList<TblItem>>> GetItem(long itemId)
        {
            try
            {
                var _data = await _dbContext.TblItems
                    .Where(x => x.ItemId == itemId)
                    .Select(x => new TblItem
                    {
                        Item = x.Item,
                        Description = x.Description,
                        FoodImage = x.FoodImage,
                        IsHalal = x.IsHalal,
                        Price = x.Price,
                        Category = x.Category
                    })
                    .ToListAsync();
                var res = new ApiResponseMessage<IList<TblItem>>
                {
                    Data = _data,
                    IsSuccess = false,
                    Message = "User Found"
                };

                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblItem>>
                {
                    Data = [],
                    IsSuccess = true,
                    Message = ex.Message
                };
                return res;
            }
        }

        public async Task<ApiResponseMessage<string>> UpdateItem(ItemDto dto)
        {
            try
            {
                var ItemToUpdate = await _dbContext.TblItems.FirstOrDefaultAsync(x => x.ItemId == dto.ItemId);

                if (ItemToUpdate != null)
                {

                    ItemToUpdate.Description = dto.Description;
                    ItemToUpdate.FoodImage = dto.FoodImage;
                    ItemToUpdate.IsHalal = dto.IsHalal;
                    ItemToUpdate.Price = dto.Price;
                    ItemToUpdate.Category = dto.Category;

                    _dbContext.TblItems.Update(ItemToUpdate);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Item data updated successfully!",
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

        public async Task<ApiResponseMessage<string>> DeleteItem(ItemDto dto)
        {
            try
            {

                var ItemToUpdate = await _dbContext.TblItems.FirstOrDefaultAsync(x => x.ItemId == dto.ItemId);

                if (ItemToUpdate != null)
                {

                    ItemToUpdate.Category = 0;

                    _dbContext.TblItems.Remove(ItemToUpdate);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Item Data Removed Successfully!",
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
    }
}
