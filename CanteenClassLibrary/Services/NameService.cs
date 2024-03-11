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
    public class NameService : INameService
    {
        private readonly CanteenContext _dbContext;

        public NameService(CanteenContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponseMessage<string>> InsertName(NameDto dto)
        {
            try
            {
                var _insertName = new TblName
                {
                    FirstName = dto.FirstName,
                    MiddleName = dto.MiddleName,
                    LastName = dto.LastName
                };

                await _dbContext.TblNames.AddAsync(_insertName);
                await _dbContext.SaveChangesAsync();

                var addedNameDto = new List<NameDto>
                {
                    new NameDto
                    {
                        FirstName = _insertName.FirstName,
                        MiddleName = _insertName.MiddleName,
                        LastName = _insertName.LastName
                     }
                 };

                var res = new ApiResponseMessage<string>
                {
                    Data = "Name Data Added Successfully",
                    IsSuccess = true,
                    Message = ""
                };
                return res;
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

        public async Task<ApiResponseMessage<IList<TblName>>> GetName(long nameId)
        {
            try
            {
                var _data = await _dbContext.TblNames.Where(x => x.NameId == nameId)
                    .Select(x => new TblName
                    {
                        NameId = x.NameId,
                        FirstName = x.FirstName,
                        MiddleName = x.MiddleName,
                        LastName = x.LastName
                    })
                    .ToListAsync();

                var res = new ApiResponseMessage<IList<TblName>>
                {
                    Data = _data,
                    IsSuccess = true,
                    Message = "User Found"
                };
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblName>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };
                return res;
            }
        }

        public async Task<ApiResponseMessage<string>> UpdateName(NameDto dto)
        {
            try
            {
                var names = await _dbContext.TblNames.FirstOrDefaultAsync(x => x.NameId == dto.NameId);

                if (names != null && dto != null)
                {
                    names.FirstName = dto.FirstName;
                    names.MiddleName = dto.MiddleName;
                    names.LastName = dto.LastName;

                    _dbContext.TblNames.Update(names);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Name Data Updated Successfully",
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
                    Message = "Vendor or DTO is null"
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

        public async Task<ApiResponseMessage<string>> DeleteName(NameDto dto)
        {
            try
            {
                var name = await _dbContext.TblNames.FirstOrDefaultAsync(e => e.NameId == dto.NameId);

                if (name != null)
                {
                    _dbContext.TblNames.Remove(name);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Name Data Removed Successfully",
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
                    Message = "name not found"
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
