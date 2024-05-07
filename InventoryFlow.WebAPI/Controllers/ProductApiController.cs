using InventoryFlow.Domain.DTO_s.ProductDTO_s;
using InventoryFlow.Domain.DTO_s.ResponseDTO_s;
using InventoryFlow.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductApiController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductApiController(ProductService _productService)
        {
            this._productService = _productService;
        }
        #region CUD
        [HttpPost]
        [Route("CreateOrUpdateProduct")]
        public async Task<IActionResult> CreateOrUpdateProduct(ProductDTO product)
        {
            var obj = await _productService.CreateOrUpdate(product);
            return Ok(new ResponseDTO<ProductDTO> { Status = true, Message = "Successfully Saved or Updated", Data = obj });
        }
        [HttpDelete("DeleteProduct/{ProductId}")]
        public async Task<IActionResult> DeleteProduct(int ProductId)
        {
            var obj = await _productService.Delete(ProductId);
            return Ok(new ResponseDTO<bool> { Status = obj, Message = obj ? "Successfully Deleted" : "Not found" });
        }

        #endregion
        #region Read API
        [HttpGet]
        [Route("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var obj = await _productService.GetAll();
            return Ok(new ResponseDTO<List<ProductDTO>> { Status = true, Message = "Record Fetched Successfully", Data = obj });
        }


        [HttpGet]
        [Route("GetProductById/{ProductId}")]
        public async Task<IActionResult> GetProductById(int ProductId)
        {
            var obj = await _productService.GetById(ProductId);
            return Ok(new ResponseDTO<ProductDTO> { Status = obj != null, Message = obj != null ? "Record Found" : "Record Not Found", Data = obj });
        }
        #endregion
    }
}
