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
    public class MembershipService : IMembershipService
    {
        private readonly CanteenContext _dbContext;

        public MembershipService(CanteenContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponseMessage<string>> InsertMembership(MembershipDto dto)
        {
            try
            {
                var _insertMembership = new TblMembership
                {
                    Membership = dto.Membership,
                    LoyaltyPoints = dto.LoyaltyPoints,
                    Status = dto.Status
                };

                await _dbContext.TblMemberships.AddAsync(_insertMembership);
                await _dbContext.SaveChangesAsync();

                var res = new ApiResponseMessage<string>
                {
                    Data = "Saved Memberships Data",
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


        public async Task<ApiResponseMessage<IList<TblMembership>>> GetMembership(long memberId)
        {
            try
            {
                var _data = await _dbContext.TblMemberships.Where(x => x.MemberShipId == memberId)
                    .Select(x => new TblMembership
                    {
                        Membership = x.Membership,
                        LoyaltyPoints = x.LoyaltyPoints,
                        Status = x.Status
                    })
                    .ToListAsync();

                var res = new ApiResponseMessage<IList<TblMembership>>
                {
                    Data = _data,
                    IsSuccess = true,
                    Message = "User Found"
                };

                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblMembership>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }

        public async Task<ApiResponseMessage<string>> UpdateMembership(MembershipDto dto)
        {
            try
            {
                var membershipstat = await _dbContext.TblMemberships.FirstOrDefaultAsync(x => x.MemberShipId == dto.MemberShipId);

                if (membershipstat != null && dto != null)
                {
                    membershipstat.Membership = dto.Membership;
                    membershipstat.LoyaltyPoints = dto.LoyaltyPoints;
                    membershipstat.Status = dto.Status;

                    _dbContext.TblMemberships.Update(membershipstat);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Membership Status Updated Successfully",
                        IsSuccess = true,
                        Message = ""
                    };

                    return res;
                }
                else 
                { 
                var nullRes = new ApiResponseMessage<string>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Vendor or DTO is null"
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

        public async Task<ApiResponseMessage<string>> DeleteMembership(MembershipDto dto)
        {
            try
            {
                var membershipstat = await _dbContext.TblMemberships.FirstOrDefaultAsync(e => e.MemberShipId == dto.MemberShipId);

                if (membershipstat != null)
                {
                    _dbContext.TblMemberships.Remove(membershipstat);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Membership status removed successfully",
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
