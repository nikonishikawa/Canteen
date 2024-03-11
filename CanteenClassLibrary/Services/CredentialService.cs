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
    public class CredentialService : ICredentialService
    {
        private readonly CanteenContext _dbContext;

        public CredentialService(CanteenContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponseMessage<string>> InsertCredential(CredentialDto dto)
        {
            try
            {
                var _insertCredential = new TblCredential
                {
                    Username = dto.Username,
                    Password = dto.Password
                };

                await _dbContext.TblCredentials.AddAsync(_insertCredential);
                await _dbContext.SaveChangesAsync();

                var res = new ApiResponseMessage<string>
                {
                    Data = "Saved Credentials Data",
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

        public async Task<ApiResponseMessage<IList<TblCredential>>> GetCredential(long credId)
        {
            try
            {
                var _data = await _dbContext.TblCredentials.Where(x => x.CredentialsId == credId)
                    .Select(x => new TblCredential
                    {
                        CredentialsId = x.CredentialsId,
                        Username = x.Username,
                        Password = x.Password
                    })
                    .ToListAsync();

                var res = new ApiResponseMessage<IList<TblCredential>>
                {
                    Data = _data,
                    IsSuccess = true,
                    Message = "User Found"
                };

                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblCredential>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };

                return res;
            }
        }

        public async Task<ApiResponseMessage<string>> UpdateCredential(CredentialDto dto)
        {
            try
            {
                var creds = await _dbContext.TblCredentials.FirstOrDefaultAsync(x => x.CredentialsId == dto.CredentialsId);

                if (creds != null)
                {
                    creds.Username = dto.Username;
                    creds.Password = dto.Password;

                    _dbContext.TblCredentials.Update(creds);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Updated credential successfully",
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
                        Message = "Credential or DTO is null"
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

        public async Task<ApiResponseMessage<string>> DeleteCredential(CredentialDto dto)
        {
            try
            {
                var creds = await _dbContext.TblCredentials.FirstOrDefaultAsync(e => e.CredentialsId == dto.CredentialsId);

                if (creds != null)
                {
                    _dbContext.TblCredentials.Remove(creds);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Credential deleted successfully",
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
                        Message = "Credential not found"
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
