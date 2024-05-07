using AutoMapper;
using InventoryFlow.Domain.DbModels;
using InventoryFlow.Domain.DTO_s.ProductDTO_s;
using InventoryFlow.Domain.DTO_s.VendorDTO_s;
using InventoryFlow.Domain.Repositories;
using InventoryFlow.Service.Common;
using Microsoft.EntityFrameworkCore;
namespace InventoryFlow.Service.Services
{
    public class VendorService
    {
        private readonly UnitOfWork<Vendor> _uowVendor;
        private readonly IMapper _mapper;
        private readonly UserDataService _userDataService;

        public VendorService(UnitOfWork<Vendor> _uowVendor, IMapper _mapper, UserDataService _userDataService)
        {
            this._uowVendor = _uowVendor;
            this._mapper = _mapper;
            this._userDataService = _userDataService;

        }
        public async Task<VendorDTO> CreateOrUpdate(VendorDTO vendor)
        {
            try
            {
                var existingVendor = await _uowVendor.Repository.GetById(vendor.Id);
                if (existingVendor == null)
                {
                    var newVendor = _mapper.Map<Vendor>(vendor);
                    newVendor.CreatedAt = DateTime.Now;
                    newVendor.IsActive = true;
                    newVendor.CreatedBy = _userDataService.GetUserId();
                    await _uowVendor.Repository.InsertAsync(newVendor);
                    await _uowVendor.SaveAsync();
                    return _mapper.Map<VendorDTO>(newVendor);
                }
                else
                {
                    var obj = _mapper.Map(vendor, existingVendor);
                    existingVendor.UpdatedAt = DateTime.Now;
                    obj.UpdatedBy = _userDataService.GetUserId();
                    _uowVendor.Repository.Update(obj);
                    await _uowVendor.SaveAsync();
                    return _mapper.Map<VendorDTO>(existingVendor);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task<List<VendorDTO>> GetAll()
        {
            try
            {
                var vendors = await _uowVendor.Repository.GetALL(x => x.IsActive == true).ToListAsync();
                var obj = _mapper.Map<List<VendorDTO>>(vendors);
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<VendorDTO> GetById(int VendorId)
        {
            try
            {
                var vendor = await _uowVendor.Repository.GetALL(x => x.IsActive == true && x.Id == VendorId).FirstOrDefaultAsync();
                var obj = _mapper.Map<VendorDTO>(vendor);
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> Delete(int VendorId)
        {
            try
            {
                var vendor = await _uowVendor.Repository.GetById(VendorId);
                if (vendor != null)
                {
                    vendor.IsActive = false;
                    await _uowVendor.SaveAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
