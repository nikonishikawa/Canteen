using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;
using CanteenClassLibrary.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CanteenClassLibrary.Services
{
    public class AdminService : IAdminService
    {
        private readonly CanteenContext _dbContext;

        public AdminService(CanteenContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponseMessage<IList<AdminDto>>> GetAdminById(long AdminId)
        {
            try
            {
                var Admin = await _dbContext.TblAdmins.FirstOrDefaultAsync(x => x.AdminId == AdminId);

                if (Admin != null)
                {
                    var AdminDtoList = new List<AdminDto>
            {
                new AdminDto
                {
                    AdminId = Admin.AdminId,
                    AdminCredentials = Admin.AdminCredentials,
                    AdminName = Admin.AdminName,
                    Status = Admin.Status
                }
            };

                    var res = new ApiResponseMessage<IList<AdminDto>>
                    {
                        Data = AdminDtoList,
                        IsSuccess = true,
                        Message = "Admin retrieved successfully"
                    };

                    return res;
                }
                else
                {
                    var res = new ApiResponseMessage<IList<AdminDto>>
                    {
                        Data = null,
                        IsSuccess = false,
                        Message = "Admin not found"
                    };

                    return res;
                }
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<AdminDto>>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }


        public async Task<ApiResponseMessage<string>> InsertAdmin(AdminDto dto)
        {
            try
            {
                var newAdmin = new TblAdmin
                {
                    AdminId = dto.AdminId,
                    AdminCredentials = dto.AdminCredentials,
                    AdminName = dto.AdminName,
                    Status = dto.Status
                };

                await _dbContext.TblAdmins.AddAsync(newAdmin);
                await _dbContext.SaveChangesAsync();

                var res = new ApiResponseMessage<string>
                {
                    Data = "Saved Admin Data",
                    IsSuccess = true,
                    Message = "Admin inserted successfully"
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


        public async Task<ApiResponseMessage<string>> UpdateAdmin(AdminDto dto)
        {
            try
            {
                var Admin = await _dbContext.TblAdmins.FirstOrDefaultAsync(x => x.AdminId == dto.AdminId);

                if (Admin != null && dto != null)
                {
                    Admin.AdminId = dto.AdminId;
                    Admin.AdminCredentials = dto.AdminCredentials;
                    Admin.AdminName = dto.AdminName;
                    Admin.Status = dto.Status;

                    _dbContext.TblAdmins.Update(Admin);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "updated Admin successfully",
                        IsSuccess = false,
                        Message = ""
                    };

                    return res;
                }

                var nullRes = new ApiResponseMessage<string>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Admin or DTO is null"
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


        public async Task<ApiResponseMessage<string>> DeleteAdmin(AdminDto dto)
        {
            try
            {
                var Admin = await _dbContext.TblAdmins.FirstOrDefaultAsync(e => e.AdminId == dto.AdminId);

                if (Admin != null)
                {

                    _dbContext.TblAdmins.Remove(Admin);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Deleted Admin successfully!",
                        IsSuccess = true,
                        Message = ""
                    };

                    return res;
                }

                var nullRes = new ApiResponseMessage<string>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Admin not found"
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
