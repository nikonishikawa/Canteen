using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;
using CanteenClassLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
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

        public async Task<ApiResponseMessage<string>> InsertGeneralAddressWithAddress(CombinedAddressGeneralDto combinedDto)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    // Insert address into TblAddress
                    var address = new TblAddress
                    {
                        Barangay = combinedDto.Barangay,
                        Region = combinedDto.Region,
                        PostalCode = combinedDto.PostalCode
                    };

                    _dbContext.TblAddresses.Add(address);
                    await _dbContext.SaveChangesAsync(); // SaveChanges to generate AddressID

                    // Retrieve the generated AddressID
                    var generatedAddressId = address.AddressId;

                    // Insert data into TblAddressGeneral using the generated AddressID
                    var insertAddressGeneral = new TblAddressGeneral
                    {
                        GenAddressId = combinedDto.GenAddressId,
                        AddressId = generatedAddressId, // Use the generated AddressID
                        Email = combinedDto.Email,
                        ContactNumber = combinedDto.ContactNumber
                    };

                    await _dbContext.TblAddressGenerals.AddAsync(insertAddressGeneral);
                    await _dbContext.SaveChangesAsync();

                    await transaction.CommitAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Saved data",
                        IsSuccess = true,
                        Message = "Data inserted successfully"
                    };

                    return res;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = $"An error occurred while saving the entity changes. See the inner exception for details. Inner Exception: {ex.InnerException?.Message}"
                    };

                    return res;
                }
            }
        }



        //public async Task<ApiResponseMessage<string>> InsertGeneralAddress(AddressGeneralDto dto)
        //{
        //    try
        //    {
        //        var _insertGeneralAddress = new TblAddressGeneral
        //        {
        //            AddressId = dto.AddressId,
        //            Email = dto.Email,
        //            ContactNumber = dto.ContactNumber
        //        };

        //        await _dbContext.TblAddressGenerals.AddAsync(_insertGeneralAddress);
        //        await _dbContext.SaveChangesAsync();

        //        var res = new ApiResponseMessage<string>
        //        {
        //            Data = "Saved GeneralAddresss Data",
        //            IsSuccess = true,
        //            Message = ""
        //        };

        //        return res;
        //    }
        //    catch (Exception ex)
        //    {
        //        var res = new ApiResponseMessage<string>
        //        {
        //            Data = "",
        //            IsSuccess = false,
        //            Message = ex.Message
        //        };

        //        return res;
        //    }
        //}

        
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
