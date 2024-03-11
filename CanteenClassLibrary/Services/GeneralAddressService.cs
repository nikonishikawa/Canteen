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
    public class GeneralAddressService : IGeneralAddressService
    {
        private readonly CanteenContext _dbContext;

        public GeneralAddressService(CanteenContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ApiResponseMessage<string>> InsertGeneralAddress(AddressGeneralDto dto)
        {
            try
            {
                var _insertGeneralAddress = new TblAddressGeneral
                {
                    AddressId = dto.AddressId,
                    Email = dto.Email,
                    ContactNumber = dto.ContactNumber
                };

                await _dbContext.TblAddressGenerals.AddAsync(_insertGeneralAddress);
                await _dbContext.SaveChangesAsync();

                var res = new ApiResponseMessage<string>
                {
                    Data = "Saved GeneralAddresss Data",
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

        
        public async Task<ApiResponseMessage<IList<TblAddressGeneral>>> GetGeneralAddress(long genAddressId)
        {
            try
            {
                var _data = await _dbContext.TblAddressGenerals.Where(x => x.GenAddressId == genAddressId)
                    .Select(x => new TblAddressGeneral
                    {
                        AddressId = x.AddressId,
                        Email = x.Email,
                        ContactNumber = x.ContactNumber
                    })
                    .ToListAsync();

                var res = new ApiResponseMessage<IList<TblAddressGeneral>>
                {
                    Data = _data,
                    IsSuccess = true,
                    Message = "User Found"
                };

                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblAddressGeneral>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }
        public async Task<ApiResponseMessage<string>> UpdateGenralAddress(AddressGeneralDto dto)
        {
            try
            {
                var genad = await _dbContext.TblAddressGenerals.FirstOrDefaultAsync(x => x.GenAddressId == dto.GenAddressId);

                if (genad != null)
                {
                    genad.AddressId = dto.AddressId;
                    genad.Email = dto.Email;
                    genad.ContactNumber = dto.ContactNumber;

                    _dbContext.TblAddressGenerals.Update(genad);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Vendor updated successfully",
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

        public async Task<ApiResponseMessage<string>> DeleteGenralAddress(AddressGeneralDto dto)
        {
            try
            {
                var genad = await _dbContext.TblAddressGenerals.FirstOrDefaultAsync(e => e.GenAddressId == dto.GenAddressId);

                if (genad != null)
                {
                    _dbContext.TblAddressGenerals.Remove(genad);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "General Address removed successfully",
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
