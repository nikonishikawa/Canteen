using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;
using CanteenClassLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CanteenClassLibrary.Services
{
    public class VendorService : IVendorService
    {
        private readonly CanteenContext _dbContext;

        public VendorService(CanteenContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<VendorDto> GetVendorById(long vendorId)
        {
            var vendor = await _dbContext.TblVendors.FirstOrDefaultAsync(x => x.VendorId == vendorId);

            if (vendor != null)
            {
                var vendorDto = new VendorDto
                {
                    VendCredentials = vendor.VendCredentials,
                    VendName = vendor.VendName,
                    VendAddress = vendor.VendAddress,
                    Position = vendor.Position
                };

                return vendorDto;
            }

            return null;
        }

        public async Task<List<TblVendor>> GetAllVendors()
        {
            return await _dbContext.TblVendors.ToListAsync();
        }

        public async Task<ApiResponseMessage<string>> InsertCombinedVendor(CombinedVendorDto combinedDto)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    var credential = new TblCredential
                    {
                        Username = combinedDto.Username,
                        Password = combinedDto.Password
                    };

                    _dbContext.TblCredentials.Add(credential);
                    await _dbContext.SaveChangesAsync();

                    var name = new TblName
                    {
                        FirstName = combinedDto.FirstName,
                        MiddleName = combinedDto.MiddleName,
                        LastName = combinedDto.LastName
                    };

                    _dbContext.TblNames.Add(name);
                    await _dbContext.SaveChangesAsync();

                    var address = new TblAddress
                    {
                        Barangay = combinedDto.Barangay,
                        Region = combinedDto.Region,
                        PostalCode = combinedDto.PostalCode
                    };

                    _dbContext.TblAddresses.Add(address);
                    await _dbContext.SaveChangesAsync();

                    var generatedAddressId = address.AddressId;

                    var addressGeneral = new TblAddressGeneral
                    {
                        AddressId = generatedAddressId,
                        Email = combinedDto.Email,
                        ContactNumber = combinedDto.ContactNumber
                    };

                    _dbContext.TblAddressGenerals.Add(addressGeneral);
                    await _dbContext.SaveChangesAsync();

                    var position = new TblPosition
                    {
                        Position = combinedDto.Position
                    };

                    _dbContext.TblPositions.Add(position);
                    await _dbContext.SaveChangesAsync();

                    var generatedAddressGeneralId = addressGeneral.GenAddressId;
                    var generatedCredentialsId = credential.CredentialsId;
                    var generatedNameId = name.NameId;
                    var generatedPositionId = position.PositionId;

                    var vendor = new TblVendor
                    {
                        VendCredentials = generatedCredentialsId,
                        VendName = generatedNameId,
                        VendAddress = generatedAddressGeneralId,
                        Position = generatedPositionId,
                        Status = combinedDto.Status
                    };

                    _dbContext.TblVendors.Add(vendor);
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
        //public async Task<ApiResponseMessage<IList<VendorDto>>> AddVendor(VendorDto dto)
        //{
        //    try
        //    {
        //        var newVendor = new TblVendor
        //        {
        //            VendCredentials = dto.VendCredentials,
        //            VendName = dto.VendName,
        //            VendAddress = dto.VendAddress,
        //            Position = dto.Position
        //        };

        //        _dbContext.TblVendors.Add(newVendor);
        //        await _dbContext.SaveChangesAsync();

        //        var addVendor = await (from vend in _dbContext.TblVendors
        //                               join name in _dbContext.TblNames
        //                               on vend.VendName equals name.NameId
        //                               select new VendorDto
        //                               {
        //                                   VendName = name.NameId
        //                               }).ToListAsync();

        //        var res = new ApiResponseMessage<IList<VendorDto>>
        //        {
        //            Data = addVendor,
        //            IsSuccess = true,
        //            Message = "Vendor added successfully"
        //        };

        //        return res;
        //    }
        //    catch (Exception ex)
        //    {
        //        var res = new ApiResponseMessage<IList<VendorDto>>
        //        {
        //            Data = null,
        //            IsSuccess = false,
        //            Message = ex.Message
        //        };

        //        return res;
        //    }
        //}

        public async Task<ApiResponseMessage<string>> InsertVendor(VendorDto dto)
        {
            try
            {
                var _insertVendor = new TblVendor
                {
                    VendCredentials = dto.VendCredentials,
                    VendName = dto.VendName,
                    VendAddress = dto.VendAddress,
                    Position = dto.Position
                };

                await _dbContext.TblVendors.AddAsync(_insertVendor);
                await _dbContext.SaveChangesAsync();

                var res = new ApiResponseMessage<string>
                {
                    Data = "Saved Customer Data",
                    IsSuccess = true,
                    Message = ""
                };

                return res;
            }
            catch (Exception ex)
            {
                while (ex.InnerException != null)
                {
                    ex = ex.InnerException;
                }

                var res = new ApiResponseMessage<string>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }

        public async Task<ApiResponseMessage<string>> UpdateVendor(VendorDto dto)
        {
            try
            {
                var vendor = await _dbContext.TblVendors.FirstOrDefaultAsync(x => x.VendorId == dto.VendorId);

                if (vendor != null && dto != null)
                {
                    vendor.VendName = dto.VendName;
                    vendor.VendCredentials = dto.VendCredentials;
                    vendor.Position = dto.Position;
                    vendor.VendAddress = dto.VendAddress;

                    _dbContext.TblVendors.Update(vendor);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Vendor Data Updated Successfully",
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

        public async Task<ApiResponseMessage<string>> DeleteVendor(VendorDto dto)
        {
            try
            {
                var vendor = await _dbContext.TblVendors.FirstOrDefaultAsync(e => e.VendorId == dto.VendorId);

                if (vendor != null)
                {
                    _dbContext.TblVendors.Remove(vendor);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Vendor Data Removed Successfully",
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
                    Message = "Vendor not found"
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
