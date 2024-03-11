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
    public class TrayService : ITrayService
    {
        private readonly CanteenContext _dbContext;

        public TrayService(CanteenContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponseMessage<string>> InsertTrayTemp(TrayTempDto dto)
        {
            try
            {
                var newTrayTemp = new TblTrayTemp
                {
                    TrayTempId = dto.TrayTempId,
                    CusId = dto.CusId,
                    Status = dto.Status
                };

                await _dbContext.TblTrayTemps.AddAsync(newTrayTemp);
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


        public async Task<ApiResponseMessage<string>> InsertTray(TrayDto dto)
        {
            try
            {
                var _insertTray = new TblTray
                {
                    CusId = dto.CusId,
                    Status = dto.Status
                };

                await _dbContext.TblTrays.AddAsync(_insertTray);
                await _dbContext.SaveChangesAsync();

                var res = new ApiResponseMessage<string>
                {
                    Data = "Saved Tray Data",
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

        public async Task<ApiResponseMessage<IList<TblTray>>> GetTray(long cusId)
        {
            try
            {
                var _data = await _dbContext.TblTrays
                    .Where(x => x.TrayId == cusId && x.Status != 0)
                    .Select(x => new TblTray
                    {
                        CusId = x.CusId,
                        Status = x.Status
                    })
                    .ToListAsync();
                var res = new ApiResponseMessage<IList<TblTray>>
                {
                    Data = _data,
                    IsSuccess = false,
                    Message = "User Found"
                };

                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblTray>>
                {
                    Data = [],
                    IsSuccess = true,
                    Message = ex.Message
                };

                return res;
            }
        }

        public async Task<ApiResponseMessage<string>> UpdateTray(TrayDto dto)
        {
            try
            {

                var TrayToUpdate = await _dbContext.TblTrays.FirstOrDefaultAsync(x => x.TrayId == dto.TrayId);

                if (TrayToUpdate != null)
                {
                    TrayToUpdate.CusId = dto.CusId;
                    TrayToUpdate.Status = dto.Status;

                    _dbContext.TblTrays.Update(TrayToUpdate);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Tray Data Updated Successfully!",
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
                        Message = ""
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

        public async Task<ApiResponseMessage<string>> DeleteTray(TrayDto dto)
        {
            try
            {
                var TrayToUpdate = await _dbContext.TblTrays.FirstOrDefaultAsync(x => x.TrayId == dto.TrayId);

                if (TrayToUpdate != null)
                {
                    TrayToUpdate.Status = 0;

                    _dbContext.TblTrays.Remove(TrayToUpdate);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Tray Data Removed Successfully!",
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
                        Message = ""
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
