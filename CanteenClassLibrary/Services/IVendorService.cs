using CanteenClassLibrary.APIResponse;
using CanteenClassLibrary.Dto;
using CanteenClassLibrary.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CanteenClassLibrary.Services
{
    public interface IVendorService
    {
        Task<VendorDto> GetVendorById(long vendorId);
        Task<List<TblVendor>> GetAllVendors();
        Task<ApiResponseMessage<IList<VendorDto>>> AddVendor(VendorDto dto);
        Task<ApiResponseMessage<string>> InsertVendor(VendorDto dto);
        Task<ApiResponseMessage<string>> UpdateVendor(VendorDto dto);
        Task<ApiResponseMessage<string>> DeleteVendor(VendorDto dto);
    }
}
