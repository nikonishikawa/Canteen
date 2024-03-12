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
    public class TrayItemService : ITrayItemService
    {
        private readonly CanteenContext _dbContext;

       public TrayItemService(CanteenContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApiResponseMessage<string>> InsertTrayItemTemp(TrayItemsTempDto dto)
        {
            try
            {
                var newTrayTemp = new TblTrayItemsTemp
                {
                    TrayTempId = dto.TrayTempId,
                    Item = dto.Item,
                    Quantity = dto.Quantity,
                    AddStamp = dto.AddStamp
                };

                await _dbContext.TblTrayItemsTemps.AddAsync(newTrayTemp);
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

        //public async Task<ApiResponseMessage<string>> InsertData(TrayCombinedDto combinedDto)
        //{
        //    using (var transaction = _dbContext.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            var newEntityForAnotherTable = new TblTrayTemp
        //            {
        //                CusId = combinedDto.CusId,
        //                Status = combinedDto.Status
        //            };

        //            _dbContext.TblTrayTemps.Add(newEntityForAnotherTable);

        //            var newTrayItemTemp = new TblTrayItemsTemp
        //            {
        //                TrayTempId = combinedDto.TrayTempId,
        //                Item = combinedDto.Item,
        //                Quantity = combinedDto.Quantity,
        //                AddStamp = combinedDto.AddStamp
        //            };

        //            var insertedItemTemp = new TblTrayItem
        //            {
        //                TrayId = newTrayItemTemp.TrayTempId,
        //                Item = newTrayItemTemp.Item,
        //                Quantity = newTrayItemTemp.Quantity,
        //                AddStamp = newTrayItemTemp.AddStamp
        //            };

        //            var insertTray = new TblTray
        //            {
        //                CusId = newEntityForAnotherTable.CusId,
        //                Status = newEntityForAnotherTable.Status
        //            };

        //            await _dbContext.TblTrayItemsTemps.AddAsync(newTrayItemTemp);
        //            await _dbContext.TblTrayItems.AddAsync(insertedItemTemp);
        //            await _dbContext.TblTrays.AddAsync(insertTray);

        //            await _dbContext.SaveChangesAsync();

        //            await transaction.CommitAsync();

        //            var res = new ApiResponseMessage<string>
        //            {
        //                Data = "Saved data",
        //                IsSuccess = true,
        //                Message = "Data inserted successfully"
        //            };

        //            return res;
        //        }
        //        catch (Exception ex)
        //        {
        //            await transaction.RollbackAsync();

        //            var res = new ApiResponseMessage<string>
        //            {
        //                Data = null,
        //                IsSuccess = false,
        //                Message = $"An error occurred while saving the entity changes. See the inner exception for details. Inner Exception: {ex.InnerException?.Message}"
        //            };

        //            return res;
        //        }
        //    }
        //}

        //public async task<apiresponsemessage<string>> transferdatafromtemptomain()
        //{
        //    try
        //    {
        //        // retrieve data from the temp table
        //        var tempdata = await _dbcontext.tbltraytemps.tolistasync();

        //        using (var transaction = _dbcontext.database.begintransaction())
        //        {
        //            try
        //            {
        //                // transfer data from temp to main table
        //                foreach (var temprecord in tempdata)
        //                {
        //                    var student = new tbltray
        //                    {
        //                        // populate student properties from temp record
        //                        cusid = temprecord.cusid,
        //                        status = temprecord.status 
        //                        // add other student properties as needed
        //                    };

        //                    var course = new tbltrayitem
        //                    {
        //                        // populate course properties from temp record
        //                        trayid = temprecord.trayid,
        //                        item = temprecord.tbltrayitemstemps,
        //                        quantity = temprecord.quantity,
        //                        addstamp = temprecord.addstamp

        //                        // add other course properties as needed
        //                    };

        //                    var studentcourse = new tblstudentcourse
        //                    {
        //                        student = student,
        //                        course = course,
        //                    };

        //                    // add to the main table
        //                    _dbcontext.tblstudentcourses.add(studentcourse);

        //                    // remove from the temp table
        //                    _dbcontext.tblstudentcoursetemps.remove(temprecord);
        //                }

        //                // save changes to both main and temp tables
        //                await _dbcontext.savechangesasync();

        //                // commit the transaction
        //                await transaction.commitasync();

        //                var response = new apiresponsemessage<string>
        //                {
        //                    data = "data transferred successfully",
        //                    issuccess = true,
        //                    message = ""
        //                };

        //                return response;
        //            }
        //            catch (exception ex)
        //            {
        //                // rollback the transaction in case of an error
        //                await transaction.rollbackasync();

        //                var response = new apiresponsemessage<string>
        //                {
        //                    data = "",
        //                    issuccess = false,
        //                    message = $"an error occurred while transferring data. see the inner exception for details. inner exception: {ex.innerexception?.message}"
        //                };

        //                return response;
        //            }
        //        }
        //    }
        //    catch (exception ex)
        //    {
        //        var response = new apiresponsemessage<string>
        //        {
        //            data = "",
        //            issuccess = false,
        //            message = $"an error occurred while retrieving data from the temp table. see the inner exception for details. inner exception: {ex.innerexception?.message}"
        //        };

        //        return response;
        //    }
        //}

        //public async Task<ApiResponseMessage<string>> InsertTempToTrayAutomatically()
        //{
        //    try
        //    {
        //        // Retrieve data from TblTrayTemp
        //        var trayTempData = await _dbContext.TblTrayTemps.ToListAsync();

        //        // Insert data into TblTray
        //        foreach (var trayTempItem in trayTempData)
        //        {
        //            var newEntityForAnotherTable = new TblTray
        //            {
        //                CusId = trayTempItem.CusId,
        //                Status = trayTempItem.Status,
        //                // Add other properties as needed
        //            };

        //            _dbContext.TblTrays.Add(newEntityForAnotherTable);
        //        }

        //        await _dbContext.SaveChangesAsync();
                

        //        return new ApiResponseMessage<string>
        //        {
        //            Data = "Saved data",
        //            IsSuccess = true,
        //            Message = "Data inserted successfully"
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ApiResponseMessage<string>
        //        {
        //            Data = "",
        //            IsSuccess = false,
        //            Message = $"An error occurred while transferring data. See the inner exception for details. Inner Exception: {ex.InnerException?.Message}"
        //        };
        //    }
        //}

        //public async Task<ApiResponseMessage<string>> InsertTempToTrayItemAutomatically()
        //{
        //    try
        //    {
        //        // Retrieve data from TblTrayItemsTemp
        //        var trayItemsTempData = await _dbContext.TblTrayItemsTemps.ToListAsync();

        //        // Insert data into TblTrayItem
        //        foreach (var trayItemTemp in trayItemsTempData)
        //        {
        //            // Fetch TrayID from TblTray based on TrayTempId
        //            var tray = await _dbContext.TblTrays
        //                .Where(t => t.TrayId == trayItemTemp.TrayTempId)
        //                .FirstOrDefaultAsync();

        //            if (tray != null)
        //            {
        //                var newEntityForAnotherTable = new TblTrayItem
        //                {
        //                    TrayId = tray.TrayId,
        //                    Item = trayItemTemp.Item,
        //                    Quantity = trayItemTemp.Quantity,
        //                    AddStamp = trayItemTemp.AddStamp,
        //                };

        //                _dbContext.TblTrayItems.Add(newEntityForAnotherTable);
        //            }
        //        }

        //        await _dbContext.SaveChangesAsync();


        //        return new ApiResponseMessage<string>
        //        {
        //            Data = "Saved data",
        //            IsSuccess = true,
        //            Message = "Data inserted successfully"
        //        };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ApiResponseMessage<string>
        //        {
        //            Data = "",
        //            IsSuccess = false,
        //            Message = $"An error occurred while transferring data. See the inner exception for details. Inner Exception: {ex.InnerException?.Message}"
        //        };
        //    }
        //}


        public async Task<ApiResponseMessage<string>> InsertTempToNotTemp(TrayCombinedDto combinedDto)
        {
            try
            {
                using (var transaction = _dbContext.Database.BeginTransaction())
                {
                    try
                    {
                        // Insert data into TblTray
                        var newEntityForAnotherTable = new TblTray
                        {
                            CusId = combinedDto.CusId,
                            Status = combinedDto.Status
                        };

                        _dbContext.TblTrays.Add(newEntityForAnotherTable);
                        await _dbContext.SaveChangesAsync(); // Save changes to get the auto-incremented TrayID

                        // Fetch TrayId from the newly inserted TblTray
                        var trayId = newEntityForAnotherTable.TrayId;

                        // Insert data into TblTrayItems
                        var trayItemsTempList = await _dbContext.TblTrayItemsTemps
                            .Where(t => t.TrayTempId == combinedDto.TrayTempId)
                            .ToListAsync();

                        foreach (var trayItemTemp in trayItemsTempList)
                        {
                            var newTrayItem = new TblTrayItem
                            {
                                TrayId = trayId,
                                Item = trayItemTemp.Item,
                                Quantity = trayItemTemp.Quantity,
                                AddStamp = trayItemTemp.AddStamp
                            };

                            _dbContext.TblTrayItems.Add(newTrayItem);
                        }

                        await _dbContext.SaveChangesAsync();

                        // Remove the successfully transferred items from TblTrayItemsTemp
                        _dbContext.TblTrayItemsTemps.RemoveRange(trayItemsTempList);

                        await _dbContext.SaveChangesAsync();
                        await transaction.CommitAsync();

                        var res = new ApiResponseMessage<string>
                        {
                            Data = "Saved data",
                            IsSuccess = true,
                            Message = "Data inserted successfully and removed from temp table"
                        };

                        return res;
                    }
                    catch (Exception)
                    {
                        await transaction.RollbackAsync();
                        throw; // Re-throw the exception after rolling back the transaction
                    }
                }
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<string>
                {
                    Data = "",
                    IsSuccess = false,
                    Message = $"An error occurred while transferring data. See the inner exception for details. Inner Exception: {ex.InnerException?.Message}"
                };

                return res;
            }
        }

        //public async Task<ApiResponseMessage<string>> InsertDisData(TrayCombinedDto combinedDto)
        //{
        //    try
        //    {
        //        using (var transaction = _dbContext.Database.BeginTransaction())
        //        {
        //            // Insert data into TblTrayTemp
        //            var newEntityForAnotherTable = new TblTray
        //            {
        //                CusId = combinedDto.CusId,
        //                Status = combinedDto.Status
        //            };

        //            _dbContext.TblTrays.Add(newEntityForAnotherTable);

        //            // Insert data into TblTrayItem
        //            var newTrayItem = new TblTrayItem
        //            { 
        //                TrayId = combinedDto.TrayTempId,
        //                Item = combinedDto.Item,
        //                Quantity = combinedDto.Quantity,
        //                AddStamp = combinedDto.AddStamp
        //            };

        //            _dbContext.TblTrayItems.Add(newTrayItem);

        //            await _dbContext.SaveChangesAsync();

        //            await transaction.CommitAsync();

                    
        //        }
        //        var res = new ApiResponseMessage<string>
        //            {
        //                Data = "Saved data",
        //                IsSuccess = true,
        //                Message = "Data inserted successfully"
        //            };

        //            return res;
        //    }
        //    catch (Exception ex)
        //    {
        //        var res = new ApiResponseMessage<string>
        //        {
        //            Data = null,
        //            IsSuccess = false,
        //            Message = $"An error occurred while saving the entity changes. See the inner exception for details. Inner Exception: {ex.InnerException?.Message}"
        //        };

        //        return res;
        //    }
        //}
        public async Task<ApiResponseMessage<string>> InsertTrayItem(TrayItemDto dto)
        {
            try
            {
                var _insertTrayItem = new TblTrayItem
                {
                    TrayId = dto.TrayId,
                    Item = dto.Item,
                    Quantity = dto.Quantity,
                    AddStamp = dto.AddStamp
                };

                await _dbContext.TblTrayItems.AddAsync(_insertTrayItem);
                await _dbContext.SaveChangesAsync();

                var res = new ApiResponseMessage<string>
                {
                    Data = "Saved TrayItem Data",
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
                    Message = $"An error occurred while transferring data. See the inner exception for details. Inner Exception: {ex.InnerException?.Message}"
                };

                return res;
            }
        }

        public async Task<ApiResponseMessage<IList<TblTrayItem>>> GetTrayItem(long trayItemId)
        {
            try
            {
                var _data = await _dbContext.TblTrayItems
                    .Where(x => x.TrayItemId == trayItemId)
                    .Select(x => new TblTrayItem
                    {
                        TrayItemId = x.TrayItemId,
                        TrayId = x.TrayId,
                        Item = x.Item,
                        Quantity = x.Quantity,
                        AddStamp = x.AddStamp
                    })
                    .ToListAsync();
                var res = new ApiResponseMessage<IList<TblTrayItem>>
                {
                    Data = _data,
                    IsSuccess = false,
                    Message = "User Found"
                };

                return res;
            }
            catch (Exception ex)
            {
                var res = new ApiResponseMessage<IList<TblTrayItem>>
                {
                    Data = [],
                    IsSuccess = true,
                    Message = ex.Message
                };

                return res;
            }
        }

        public async Task<ApiResponseMessage<string>> UpdateTrayItem(TrayItemDto dto)
        {
            try
            {

                var trayItemToUpdate = await _dbContext.TblTrayItems.FirstOrDefaultAsync(x => x.TrayItemId == dto.TrayId);

                if (trayItemToUpdate != null)
                {
                    trayItemToUpdate.TrayId = dto.TrayId;
                    trayItemToUpdate.Item = dto.Item;
                    trayItemToUpdate.Quantity = dto.Quantity;
                    trayItemToUpdate.AddStamp = dto.AddStamp;

                    _dbContext.TblTrayItems.Update(trayItemToUpdate);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Tray Item Data Updated Successfully",
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

        public async Task<ApiResponseMessage<string>> DeleteTrayItem(TrayItemDto dto)
        {
            try
            {
                var trayItem = await _dbContext.TblTrayItems.FirstOrDefaultAsync(e => e.TrayItemId == dto.TrayId);

                if (trayItem != null)
                {
                    _dbContext.TblTrayItems.Remove(trayItem);
                    await _dbContext.SaveChangesAsync();

                    var res = new ApiResponseMessage<string>
                    {
                        Data = "Tray Item Data Removed Successfully",
                        IsSuccess = true,
                        Message = ""
                    };

                    return res;
                }

                var nullRes = new ApiResponseMessage<string>
                {
                    Data = null,
                    IsSuccess = false,
                    Message = "Tray Item not found"
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
