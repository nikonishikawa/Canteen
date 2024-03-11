using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;
using Microsoft.EntityFrameworkCore;
using CanteenClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CanteenClassLibrary.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly CanteenContext _dbContext;

        public CategoryService(CanteenContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponseMessage<string>> InsertCategory(CategoryDto dto)
        {
            try
            {
                var _insertCategory = new TblCategory
                {
                    Category = dto.Category,
                    Description = dto.Description
                };

                await _dbContext.TblCategories.AddAsync(_insertCategory);
                await _dbContext.SaveChangesAsync();

                var res = new ApiResponseMessage<string>
                {
                    Data = "Saved Categorys Data",
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


        public async Task<ApiResponseMessage<IList<TblCategory>>> GetCategory(long CategoryId)
        {
            try
            {
                var _data = await _dbContext.TblCategories.Where(x => x.CategoryId == CategoryId)
                    .Select(x => new TblCategory
                    {
                        Category = x.Category,
                        Description = x.Description

                    })
                    .ToListAsync();

                var res = new ApiResponseMessage<IList<TblCategory>>
                {
                    Data = _data,
                    IsSuccess = true,
                    Message = "User Found"
                };

                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblCategory>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }

        public async Task<ApiResponseMessage<TblCategory>> UpdateCategory(long CategoryId, CategoryDto dto)
        {
            try
            {
                var categ = await _dbContext.TblCategories.FirstOrDefaultAsync(x => x.CategoryId == CategoryId);
                    categ.Category = dto.Category;
                    categ.Description = dto.Description;

                _dbContext.TblCategories.Update(categ);
                await _dbContext.SaveChangesAsync();

                var nullRes = new ApiResponseMessage<TblCategory>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Category or DTO is null"
                };

                return nullRes;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<TblCategory>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }

        public async Task<ApiResponseMessage<TblCategory>> DeleteCategory(long CategoryId)
        {
            try
            {
                var categ = await _dbContext.TblCategories.FirstOrDefaultAsync(e => e.CategoryId == CategoryId);

                if (categ != null)
                {
                    _dbContext.TblCategories.Remove(categ);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<TblCategory>
                    {
                        Data = categ,
                        IsSuccess = true,
                        Message = "Category deleted successfully"
                    };

                    return res;
                }

                var nullRes = new ApiResponseMessage<TblCategory>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Category not found"
                };

                return nullRes;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<TblCategory>
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
