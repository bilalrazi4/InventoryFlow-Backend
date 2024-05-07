using InventoryFlow.Domain.DTO_s.ProductDTO_s;
using InventoryFlow.Domain.DTO_s.ResponseDTO_s;
using InventoryFlow.Domain.DTO_s.VendorDTO_s;
using InventoryFlow.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VendorApiController : ControllerBase
    {
        private readonly VendorService _vendorService;
        public VendorApiController(VendorService _vendorService)
        {
            this._vendorService = _vendorService;
        }
        #region CUD
        [HttpPost]
        [Route("CreateOrUpdateVendor")]
        public async Task<IActionResult> CreateOrUpdateVendor(VendorDTO vendor)
        {
            var obj = await _vendorService.CreateOrUpdate(vendor);
            return Ok(new ResponseDTO<VendorDTO> { Status = true, Message = "Successfully Saved or Updated", Data = obj });
        }
        [HttpDelete("DeleteVendor/{VendorId}")]
        public async Task<IActionResult> DeleteVendor(int VendorId)
        {
            var obj = await _vendorService.Delete(VendorId);
            return Ok(new ResponseDTO<bool> { Status = obj, Message = obj ? "Successfully Deleted" : "Not found" });
        }
        #endregion
        #region Read API
        [HttpGet]
        [Route("GetAllVendors")]
        public async Task<IActionResult> GetAllVendors()
        {
            var obj = await _vendorService.GetAll();
            return Ok(new ResponseDTO<List<VendorDTO>> { Status = true, Message = "Record Fetched Successfully", Data = obj });
        }
        [HttpGet]
        [Route("GetVendorById/{VendorId}")]
        public async Task<IActionResult> GetVendorById(int VendorId)
        {
            var obj = await _vendorService.GetById(VendorId);
            return Ok(new ResponseDTO<VendorDTO> { Status = obj != null, Message = obj != null ? "Record Found" : "Record Not Found", Data = obj });
        }
        #endregion
    }
}
