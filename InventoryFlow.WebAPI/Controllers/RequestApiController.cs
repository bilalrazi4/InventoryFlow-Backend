using InventoryFlow.Domain.DbModels;
using InventoryFlow.Domain.DTO_s.RequestDto_s;
using InventoryFlow.Domain.DTO_s.ResponseDTO_s;
using InventoryFlow.Service.Services;
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
        public async Task<IActionResult> CreateOrUpdateRequest(List<RequestDTO> productsForRequestList)
        {
            var obj = await _requestService.CreateOrUpdate(productsForRequestList);
            return Ok(new ResponseDTO<List<RequestDTO>> { Status = true, Message = "Successfully Saved or Updated", Data = obj });
        }

        //[HttpPost]
        //[Route("GeneratePDFForApprovedRequest/{RequestId}")]
        //public async Task<IActionResult> GeneratePDFForApprovedRequest(int RequestId,IFormFile pdfFile)
        //{
        //    var obj = await _requestService.GeneratePDFForApprovedRequest(pdfFile, RequestId);
        //    return Ok(new ResponseDTO<string> { Status = obj.Status, Message = obj.Message});
        //}

        [HttpPost]
        [Route("UploadImage/{additionalDetails}/{requestId}")]
        public async Task<IActionResult> UploadImage([FromForm]IFormFile imageFile,string additionalDetails,int requestId)
        {
            // Your code here
            var obj = await _requestService.UploadImage(imageFile, additionalDetails, requestId);
            return Ok(new ResponseDTO<string> { Status = true, Message = "Successfully Saved or Updated"});
        }

        [HttpGet]
        [Route("GeneratePDFForApprovedRequest/{RequestId}/{docDef}")]
        public async Task<IActionResult> GeneratePDFForApprovedRequest(int RequestId, string  docDef)
        {
            var obj = await _requestService.GeneratePDFForApprovedRequest(RequestId, docDef);
            return Ok(new ResponseDTO<string> { Status = obj.Status, Message = obj.Message });
        }
        [HttpPost]
        [Route("ApprovePendingRequest")]
        public async Task<IActionResult> ApprovePendingRequest(List<RequestDTO> pendingRequestListToApprove)
        {
            var obj = await _requestService.AcceptRequest(pendingRequestListToApprove);
            return Ok(new ResponseDTO<RequestDTO> { Status = obj.Status, Message = obj.Message });
        }

        [HttpPost]
        [Route("RejectPendingRequest/{Remarks}")]
        public async Task<IActionResult> RejectPendingRequest(List<RequestDTO> pendingRequestListToApprove,string Remarks)
        {
            var obj = await _requestService.RejectRequest(pendingRequestListToApprove, Remarks);
            return Ok(new ResponseDTO<RequestDTO> { Status = obj.Status, Message = obj.Message });
        }

        [HttpGet]
        [Route("AcceptApprovedRequest/{requestId}")]
        public async Task<IActionResult> AcceptApprovedRequest(int requestId)
        {
            var obj = await _requestService.AcceptTheRequest(requestId);
            return Ok(new ResponseDTO<bool> { Status = obj});
        }
        #endregion
        #region Read API
        [HttpGet]
        [Route("GetAllPendingRequests")]
        public async Task<IActionResult> GetAllPendingRequests()
        {
            var obj = await _requestService.GetPendingRequestsList();
            return Ok(new ResponseDTO<List<RequestMasterDTO>> { Status = true, Message = "Record Fetched Successfully", Data = obj });
        }
        [HttpGet]
        [Route("GetPendingRequestsDetailList/{RequestMasterId}")]
        public async Task<IActionResult> GetPendingRequestsDetailList(int RequestMasterId)
        {
            var obj = await _requestService.GetPendingRequestsDetailList(RequestMasterId);
            return Ok(new ResponseDTO<List<RequestDTO>> { Status = true, Message = "Record Fetched Successfully", Data = obj });
        }
        [HttpGet]
        [Route("GetAllApprovedRequests")]
        public async Task<IActionResult> GetAllApprovedRequests()
        {
            var obj = await _requestService.GetApprovedRequestsList();
            return Ok(new ResponseDTO<List<RequestMasterDTO>> { Status = true, Message = "Record Fetched Successfully", Data = obj });
        }

        [HttpGet]
        [Route("GetAllRejectedRequests")]
        public async Task<IActionResult> GetAllRejectedRequests()
        {
            var obj = await _requestService.GetRejectedRequestsList();
            return Ok(new ResponseDTO<List<RequestMasterDTO>> { Status = true, Message = "Record Fetched Successfully", Data = obj });
        }
        [HttpGet]
        [Route("GetAllRequestsListForUser")]
        public async Task<IActionResult> GetAllRequestsListForUser()
        {
            var obj = await _requestService.GetRequestsListForUser();
            return Ok(new ResponseDTO<List<RequestMasterDTO>> { Status = true, Message = "Record Fetched Successfully", Data = obj });
        }


        [HttpGet]
        [Route("GetImageAndChequeDetails/{RequestId}")]
        public async Task<IActionResult> GetImageAndChequeDetails(int RequestId)
        {
            var obj = await _requestService.GetImageAndChequeDetails(RequestId);
            return Ok(new ResponseDTO<Attachment> { Status = true, Message = "Record Fetched Successfully", Data = obj });
        }

        [HttpPost]
        [Route("GetInvoiceAgainstTheApprovedRequest")]
        public async Task<IActionResult> GetInvoiceAgainstTheApprovedRequest(RequestMasterDTO request)
        {
            var obj = await _requestService.GetInvoiceAgainstTheApprovedRequest(request);
            return Ok(new ResponseDTO<Invoice> { Status = true, Message = obj!=null?"Invoice Found":"Invoice Not Found", Data = obj });
        }
        #endregion
    }
}
