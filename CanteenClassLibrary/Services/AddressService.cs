using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;
using CanteenClassLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace CanteenClassLibrary.Services
{
    public class AddressService : IAddressService
    {
        private readonly CanteenContext _dbContext;

        public AddressService(CanteenContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponseMessage<IList<AddressDto>>> GetAddressById(long addressId)
        {
            try
            {
                var address = await _dbContext.TblAddresses.FirstOrDefaultAsync(x => x.AddressId == addressId);

                if (address != null)
                {
                    var addressDtoList = new List<AddressDto>
            {
                new AddressDto
                {
                    AddressId = address.AddressId,
                    Barangay = address.Barangay,
                    Region = address.Region,
                    PostalCode = address.PostalCode
                }
            };

                    var res = new ApiResponseMessage<IList<AddressDto>>
                    {
                        Data = addressDtoList,
                        IsSuccess = true,
                        Message = "Address retrieved successfully"
                    };

                    return res;
                }
                else
                {
                    var res = new ApiResponseMessage<IList<AddressDto>>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = "Address not found"
                    };

                    return res;
                }
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<AddressDto>>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }


        public async Task<ApiResponseMessage<string>> InsertAddress(AddressDto dto)
        {
            try
            {
                var newAddress = new TblAddress
                {
                    Barangay = dto.Barangay,
                    Region = dto.Region,
                    PostalCode = dto.PostalCode
                };

                await _dbContext.TblAddresses.AddAsync(newAddress);
                await _dbContext.SaveChangesAsync();

                var res = new ApiResponseMessage<string>
                {
                    Data = "Saved Address Data",
                    IsSuccess = true,
                    Message = "Address inserted successfully"
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


        public async Task<ApiResponseMessage<string>> UpdateAddress(AddressDto dto)
        {
            try
            {
                var address = await _dbContext.TblAddresses.FirstOrDefaultAsync(x => x.AddressId == dto.AddressId);

                if (address != null && dto != null)
                {
                    address.Barangay = dto.Barangay;
                    address.Region = dto.Region;
                    address.PostalCode = dto.PostalCode;

                    _dbContext.TblAddresses.Update(address);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "updated address successfully",
                        IsSuccess = false,
                        Message = ""
                    };

                    return res;
                }

                var nullRes = new ApiResponseMessage<string>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Address or DTO is null"
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


        public async Task<ApiResponseMessage<string>> DeleteAddress(AddressDto dto)
        {
            try
            {
                var address = await _dbContext.TblAddresses.FirstOrDefaultAsync(e => e.AddressId == dto.AddressId);

                if (address != null)
                {

                    _dbContext.TblAddresses.Remove(address);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Deleted address successfully!",
                        IsSuccess = true,
                        Message = ""
                    };

                    return res;
                }

                var nullRes = new ApiResponseMessage<string>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Address not found"
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
