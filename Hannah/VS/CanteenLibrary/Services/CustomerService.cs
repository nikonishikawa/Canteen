using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;
using CanteenClassLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CanteenClassLibrary.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CanteenContext _dbContext;

        public CustomerService(CanteenContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponseMessage<string>> InsertCombinedCustomer(CombinedCustomerDto combinedDto)
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

                    var membership = new TblMembership
                    {
                        Membership = combinedDto.Membership,
                        LoyaltyPoints = combinedDto.LoyaltyPoints,
                        Status = combinedDto.MembershipStatus
                    };

                    _dbContext.TblMemberships.Add(membership);
                    await _dbContext.SaveChangesAsync();

                    var generatedAddressGeneralId = addressGeneral.GenAddressId;
                    var generatedCredentialsId = credential.CredentialsId;
                    var generatedNameId = name.NameId;
                    var generatedMembershipId = membership.MemberShipId;

                    var customer = new TblCustomer
                    {
                        CusCredentials = generatedCredentialsId,
                        CusName = generatedNameId,
                        CusAddress = generatedAddressGeneralId,
                        Membership = generatedMembershipId,
                        Status = combinedDto.Status
                    };

                    _dbContext.TblCustomers.Add(customer);
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

        //public async Task<ApiResponseMessage<string>> InsertCustomer(CustomerDto dto)
        //{
        //    try
        //    {
        //        var _insertCustomer = new TblCustomer
        //        {
        //            CusCredentials = dto.CusCredentials,
        //            CusName = dto.CusName,
        //            CusAddress = dto.CusAddress,
        //            Membership = dto.Membership,
        //            Status = dto.Status
        //        };

        //        await _dbContext.TblCustomers.AddAsync(_insertCustomer);
        //        await _dbContext.SaveChangesAsync();

        //        var res = new ApiResponseMessage<string>
        //        {
        //            Data = "Saved Customer Data",
        //            IsSuccess = true,
        //            Message = ""
        //        };
        //        return res;
        //    }
        //    catch (Exception ex)
        //    {
        //        while (ex.InnerException != null)
        //        {
        //            ex = ex.InnerException;
        //        }

        //        var res = new ApiResponseMessage<string>
        //        {
        //            Data = "",
        //            IsSuccess = false,
        //            Message = ex.Message
        //        };
        //        return res;
        //    }
        //}


        public async Task<ApiResponseMessage<IList<TblCustomer>>> GetCustomer(long cusId)
        {
            try
            {
                var _data = await _dbContext.TblCustomers
                    .Where(x => x.CustomerId == cusId && x.Status != 0)
                    .Select(x => new TblCustomer
                    {
                        CustomerId = x.CustomerId,
                        CusCredentials = x.CusCredentials,
                        CusName = x.CusName,
                        CusAddress = x.CusAddress,
                        Membership = x.Membership,
                        Status = x.Status
                    })
                    .ToListAsync();
                var res = new ApiResponseMessage<IList<TblCustomer>>
                {
                    Data = _data,
                    IsSuccess = false,
                    Message = "User Found"
                };
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblCustomer>>
                {
                    Data = [],
                    IsSuccess = true,
                    Message = ex.Message
                };

                return res;
            }
        }

        public async Task<ApiResponseMessage<string>> UpdateCustomer(CustomerDto dto)
        {
            try
            {
                var customerToUpdate = await _dbContext.TblCustomers.FirstOrDefaultAsync(x => x.CustomerId == dto.CustomerId);

                if (customerToUpdate != null)
                {
                    customerToUpdate.CusCredentials = dto.CusCredentials;
                    customerToUpdate.CusName = dto.CusCredentials;
                    customerToUpdate.CusAddress = dto.CusCredentials;
                    customerToUpdate.Membership = dto.CusCredentials;

                    _dbContext.TblCustomers.Update(customerToUpdate);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Customer Data Updated Succesfully!",
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
                        Message = $"Customer with ID {customerToUpdate} not found"
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

        public async Task<ApiResponseMessage<string>> DeleteCustomer(CustomerDto dto)
        {
            try
            {

                var customerToUpdate = await _dbContext.TblCustomers.FirstOrDefaultAsync(x => x.CustomerId == dto.CustomerId);

                if (customerToUpdate != null)
                {

                    customerToUpdate.Status = 0;

                    _dbContext.TblCustomers.Remove(customerToUpdate);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Customer Data Deleted Successfully!",
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
                        Message = $"Customer with ID {customerToUpdate} not found"
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
