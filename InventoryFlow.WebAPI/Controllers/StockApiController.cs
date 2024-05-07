using InventoryFlow.Domain.DTO_s.ProductDTO_s;
using InventoryFlow.Domain.DTO_s.ResponseDTO_s;
using InventoryFlow.Domain.DTO_s.StockDto_s;
using InventoryFlow.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StockApiController : ControllerBase
    {
        private readonly StockService _stockService;
        public StockApiController(StockService _stockService)
        {
            this._stockService = _stockService;
        }
        #region CUD
        [HttpPost]
        [Route("CreateOrUpdateStock")]
        public async Task<IActionResult> CreateOrUpdateStock(StockDTO stock)
        {
            var obj = await _stockService.CreateOrUpdate(stock);
            return Ok(new ResponseDTO<StockDTO> { Status = obj.Status, Message =obj.Message, Data = obj.Data });
        }

        [HttpDelete]
        [Route("DeleteStock/{StockId}")]
        public async Task<IActionResult> DeleteStock(int StockId)
        {
            var obj = await _stockService.Delete(StockId);
            return Ok(new ResponseDTO<bool> { Status = obj, Message = obj ? "Successfully Deleted" : "Not found" });
        }


        #endregion

        [HttpGet]
        [Route("GetAllStocks")]
        public async Task<IActionResult> GetAllStocks()
        {
            var obj = await _stockService.GetAll();
            return Ok(new ResponseDTO<List<StockDTO>> { Status = true, Message = "Record Fetched Successfully", Data = obj.Data });
        }

        [HttpGet]
        [Route("GetAllStockWithNames")]
        public async Task<IActionResult> GetAllStockWithNames()
        {
            var obj = await _stockService.GetStockWithNames();
            return Ok(new ResponseDTO<List<StockWithNamesDto>> { Status = true, Message = "Record Fetched Successfully", Data = obj.Data });
        }
    }
}
