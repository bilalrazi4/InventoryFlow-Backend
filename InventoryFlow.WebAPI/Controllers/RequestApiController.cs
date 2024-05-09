using InventoryFlow.Domain.DTO_s.CategoryDTO_s;
using InventoryFlow.Domain.DTO_s.RequestDto_s;
using InventoryFlow.Domain.DTO_s.ResponseDTO_s;
using InventoryFlow.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestApiController : ControllerBase
    {
        private readonly RequestService _requestService;
        public RequestApiController(RequestService _requestService)
        {
            this._requestService = _requestService;
        }
        #region CUD
        [HttpPost]
        [Route("CreateOrUpdateRequest")]
        public async Task<IActionResult> CreateOrUpdateRequest(RequestDTO request)
        {
            var obj = await _requestService.CreateOrUpdate(request);
            return Ok(new ResponseDTO<RequestDTO> { Status = true, Message = "Successfully Saved or Updated", Data = obj });
        }

        #endregion
        #region Read API
        [HttpGet]
        [Route("GetAllRequests")]
        public async Task<IActionResult> GetAllRequests()
        {
            var obj = await _requestService.GetAll();
            return Ok(new ResponseDTO<List<RequestDTO>> { Status = true, Message = "Record Fetched Successfully", Data = obj });
        }


        #endregion
    }
}
