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
    public class PositionService : IPositionService
    {
        private readonly CanteenContext _dbContext;

        public PositionService(CanteenContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponseMessage<string>> InsertPosition(PositionDto dto)
        {
            try
            {
                var _insertPosition = new TblPosition
                {
                    Position = dto.Position
                };

                await _dbContext.TblPositions.AddAsync(_insertPosition);
                await _dbContext.SaveChangesAsync();

                var res = new ApiResponseMessage<string>
                {
                    Data = "Saved Positions Data",
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

        public async Task<ApiResponseMessage<IList<TblPosition>>> GetPosition(long memberId)
        {
            try
            {
                var _data = await _dbContext.TblPositions.Where(x => x.PositionId == memberId)
                    .Select(x => new TblPosition
                    {
                        Position = x.Position
                    })
                    .ToListAsync();

                var res = new ApiResponseMessage<IList<TblPosition>>
                {
                    Data = _data,
                    IsSuccess = true,
                    Message = "User Found"
                };
                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblPosition>>
                {
                    Data = [],
                    IsSuccess = false,
                    Message = ex.Message
                };
                return res;
            }
        }

        public async Task<ApiResponseMessage<string>> UpdatePosition(PositionDto dto)
        {
            try
            {
                var PositionStatus = await _dbContext.TblPositions.FirstOrDefaultAsync(x => x.PositionId == dto.PositionId);

                if (PositionStatus != null && dto != null)
                {
                    PositionStatus.Position = dto.Position;

                    _dbContext.TblPositions.Update(PositionStatus);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "PositionStatus Data Updated Successfully",
                        IsSuccess = false,
                        Message = ""
                    };
                    return res;
                }
                else { 
                var res = new ApiResponseMessage<string>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "PositionStatus or DTO is null"
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

        public async Task<ApiResponseMessage<string>> DeletePosition(PositionDto dto)
        {
            try
            {
                var PositionStatus = await _dbContext.TblPositions.FirstOrDefaultAsync(e => e.PositionId == dto.PositionId);

                if (PositionStatus != null)
                {
                    _dbContext.TblPositions.Remove(PositionStatus);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "PositionStatus Data Removed Successfully",
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
                    Message = "PositionStatus not found"
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
