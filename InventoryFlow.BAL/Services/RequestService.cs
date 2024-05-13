using AutoMapper;
using Azure.Core;
using InventoryFlow.Domain.DbModels;
using InventoryFlow.Domain.DTO_s.RequestDto_s;
using InventoryFlow.Domain.DTO_s.ResponseDTO_s;
using InventoryFlow.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Request = InventoryFlow.Domain.DbModels.Request;

namespace InventoryFlow.Service.Services
{
    public class RequestService
    {
        private readonly UnitOfWork<Request> _uowRequest;
        private readonly UnitOfWork<RequestMaster> _uowRequestMaster;
        private readonly UnitOfWork<HealthFacilitiesNew> _uowHealthFacilties;
        private readonly UnitOfWork<Stock> _uowStock;
        private readonly UnitOfWork<StockOut> _uowStockOut;
        private readonly UnitOfWork<Invoice> _uowInvoice;
        private readonly UnitOfWork<Attachment> _uowAttachment;

        private readonly IMapper _mapper;
        private readonly UserDataService _userDataService;


        public RequestService(UnitOfWork<Request> _uowRequest, IMapper _mapper, UserDataService _userDataService,
            UnitOfWork<RequestMaster> _uowRequestMaster, UnitOfWork<HealthFacilitiesNew> _uowHealthFacilties,
            UnitOfWork<Stock> _uowStock, UnitOfWork<StockOut> _uowStockOut, UnitOfWork<Invoice> _uowInvoice,
            UnitOfWork<Attachment> _uowAttachment)
        {
            this._uowRequest = _uowRequest;
            this._mapper = _mapper;
            this._userDataService = _userDataService;
            this._uowRequestMaster = _uowRequestMaster;
            this._uowHealthFacilties = _uowHealthFacilties;
            this._uowStock = _uowStock;
            this._uowStockOut = _uowStockOut;
            this._uowInvoice = _uowInvoice;
            this._uowAttachment = _uowAttachment;
        }
        public async Task<List<RequestDTO>> CreateOrUpdate(List<RequestDTO> productsForRequestList)
        {
            try
            {
                var newRequestMaster = new RequestMaster();
                newRequestMaster.CreatedAt = DateTime.Now;
                newRequestMaster.CreatedBy = _userDataService.GetUserId();
                newRequestMaster.UserHfId = _userDataService.GetUserHFId();
                newRequestMaster.RequestStatus = "Pending";
                newRequestMaster.IsActive = true;
                await _uowRequestMaster.Repository.InsertAsync(newRequestMaster);
                await _uowRequestMaster.SaveAsync(); // saving a new row in RequestMaster


                var currentRequestMasterId = newRequestMaster.Id; // getting the requestMasterId for adding it to the requestDetail rows
                List<RequestDTO> newList = [];
                foreach (var singleProductRequest in productsForRequestList)
                {
                    var newProduct = _mapper.Map<Request>(singleProductRequest);
                    newProduct.RequestId = currentRequestMasterId;
                    newProduct.TotalPrice = singleProductRequest.PricePerUnit * singleProductRequest.RequestedQuantity;
                    newProduct.CreatedAt = DateTime.Now;
                    newProduct.CreatedBy = _userDataService.GetUserId();
                    newProduct.IsActive = true;
                    await _uowRequest.Repository.InsertAsync(newProduct);
                    await _uowRequest.SaveAsync();
                    newList.Add(_mapper.Map<RequestDTO>(newProduct));
                }
                return newList;


                //var existingRequest = await _uowRequest.Repository.GetById();
                //if (existingRequest == null)
                //{
                //    var newRequest = _mapper.Map<Request>(request);
                //    //newRequest.HfId = _userDataService.GetUserHFId();



                //    newRequest.TotalPrice = newRequest.PricePerUnit * newRequest.TotalPrice;
                //    //newRequest.Status = "Pending";
                //    newRequest.CreatedAt = DateTime.Now;
                //    newRequest.IsActive = true;
                //    newRequest.CreatedBy = _userDataService.GetUserId();
                //    await _uowRequest.Repository.InsertAsync(newRequest);
                //    await _uowRequest.SaveAsync();
                //    return _mapper.Map<RequestDTO>(newRequest);
                //}
                //else
                //{
                //    var obj = _mapper.Map(request, existingRequest);
                //    obj.UpdatedAt = DateTime.Now;
                //    obj.UpdatedBy = _userDataService.GetUserId();
                //    _uowRequest.Repository.Update(obj);
                //    await _uowRequest.SaveAsync();
                //    return _mapper.Map<RequestDTO>(obj);
                //}
            }
            catch (Exception)
            {
                throw;
            }
        }
        //public async Task<ResponseDTO<string>> GeneratePDFForApprovedRequest(IFormFile pdfFile,int requestId)
        //{
        //    // Read the PDF file into a byte array
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        await pdfFile.CopyToAsync(ms);
        //        byte[] pdfBlob = ms.ToArray();

        //        // Create a new Invoice object and save it to the database
        //        var invoice = new Invoice
        //        {
        //            Pdf = pdfBlob,
        //            RequestId = requestId,
        //            InvoiceStatus = true
        //        };
        //        await _uowInvoice.Repository.InsertAsync(invoice);
        //        await _uowInvoice.SaveAsync();
        //    }
        //    return new ResponseDTO<string>
        //    {
        //        Status = true,
        //        Message = "Invoice Generated"
        //    };
        //}

        public async Task<ResponseDTO<string>> GeneratePDFForApprovedRequest(int requestId, string docDef)
        {
            // Create a new Invoice object and save it to the database
            var invoice = new Invoice
            {
                Pdf = docDef,
                RequestId = requestId,
                InvoiceStatus = true
            };
            await _uowInvoice.Repository.InsertAsync(invoice);
            await _uowInvoice.SaveAsync();

            return new ResponseDTO<string>
            {
                Status = true,
                Message = "Invoice Generated"
            };
        }

        public async Task<ResponseDTO<string>> UploadImage(IFormFile imageFile, string additionalDetails, int Requestid)
        {
            // Convert the image file to a byte array
            byte[] imageData;
            using (var memoryStream = new MemoryStream())
            {
                await imageFile.CopyToAsync(memoryStream);
                imageData = memoryStream.ToArray();
            }
            var attachment = new Attachment
            {
                ChequeImage = imageData,
                RequestId = Requestid,
                ChequeDetail = additionalDetails
            };
            await _uowAttachment.Repository.InsertAsync(attachment);
            await _uowAttachment.SaveAsync();

            var req = await _uowRequestMaster.Repository.GetALL(x => x.IsActive == true && x.Id == Requestid).FirstOrDefaultAsync();
            if (req != null)
            {
                req.ChequeStatus = true;
                _uowRequestMaster.Repository.Update(req);
                await _uowRequestMaster.SaveAsync();
            }

            return new ResponseDTO<string>
            {
                Status = true,
                Message = "Image Saved"
            };
        }
        public async Task<ResponseDTO<RequestDTO>> AcceptRequest(List<RequestDTO> pendingRequestListToApprove)
        {
            //declaring this requestId so that I can update the status of Request against all these products in the Master Table
            int requestIdToUpdate = 0;
            foreach (var product in pendingRequestListToApprove)
            {
                var batchList = _uowStock.Repository.GetALL(x => x.IsActive == true && x.ProductId == product.ProductId).OrderBy(x => x.ExpiryDate).ToList();
                var totalQuantity = batchList.Sum(batch => batch.Quantity);//for calculating the sum of all the quantities in the batchlist for the specific product
                var OriginalRequestedQuantity = product.RequestedQuantity;

                //retrieving this requestId so that I can update the status of Request against all these products in the Master Table
                requestIdToUpdate = product.RequestId;

                if (totalQuantity >= OriginalRequestedQuantity)
                    foreach (var batch in batchList)
                    {
                        if (product.RequestedQuantity != 0)
                        {
                            var stockOutProduct = new StockOut();
                            //batch.Quantity <= product.RequestedQuantity
                            //what if product.requestQuantity > batch.Quantity and vice versa
                            stockOutProduct.Rate = product.PricePerUnit;
                            stockOutProduct.RequestId = product.RequestId;
                            //requestedQuantity should be the original RequestedQuantity
                            stockOutProduct.RequestedQuantity = OriginalRequestedQuantity;
                            stockOutProduct.LastAvailableQuantity = batch.Quantity;
                            stockOutProduct.TotalPrice = product.TotalPrice;
                            stockOutProduct.Batch = batch.Batch;
                            stockOutProduct.CreatedAt = DateTime.Now;
                            stockOutProduct.CreatedBy = _userDataService.GetUserId();
                            stockOutProduct.IsActive = true;
                            if (batch.Quantity <= product.RequestedQuantity)
                            {
                                product.RequestedQuantity -= batch.Quantity;
                                stockOutProduct.ApprovedQuantity = batch.Quantity;
                                stockOutProduct.StockId = batch.Id;
                                await _uowStockOut.Repository.InsertAsync(stockOutProduct);
                            }
                            else
                            {
                                //batch.Quantity > product.RequestedQuantity
                                stockOutProduct.StockId = batch.Id;
                                var quantityLeftInBatch = batch.Quantity - product.RequestedQuantity;
                                stockOutProduct.ApprovedQuantity = product.RequestedQuantity;
                                product.RequestedQuantity -= product.RequestedQuantity;
                                await _uowStockOut.Repository.InsertAsync(stockOutProduct);
                            }
                        }
                    }
            }
            await _uowStockOut.SaveAsync();
            var request = await _uowRequestMaster.Repository.GetById(requestIdToUpdate);
            if (request != null)
            {
                request.UpdatedBy = _userDataService.GetUserId();
                request.UpdatedAt = DateTime.Now;
                request.RequestStatus = "Approved";
                request.AdminId = _userDataService.GetUserId();
                request.ChequeStatus = false;
                _uowRequestMaster.Repository.Update(request);
                await _uowRequestMaster.SaveAsync();
            }
            return new ResponseDTO<RequestDTO>
            {
                Status = true,
                Message = "Transaction commited",
            };
        }


        public async Task<ResponseDTO<RequestDTO>> RejectRequest(List<RequestDTO> pendingRequestListToApprove, string Remarks)
        {
            //declaring this requestId so that I can update the status of Request against all these products in the Master Table
            int requestIdToUpdate = 0;
            foreach (var product in pendingRequestListToApprove)
            {
                //retrieving this requestId so that I can update the status of Request against all these products in the Master Table
                requestIdToUpdate = product.RequestId;
                var requestDetailtoDelete = await _uowRequest.Repository.GetALL(x => x.Id == product.Id).FirstOrDefaultAsync();
                requestDetailtoDelete.IsActive = false;
                requestDetailtoDelete.UpdatedAt = DateTime.Now;
                requestDetailtoDelete.UpdatedBy = _userDataService.GetUserId();
                _uowRequest.Repository.Update(requestDetailtoDelete);
            }
            await _uowRequest.SaveAsync();
            var request = await _uowRequestMaster.Repository.GetById(requestIdToUpdate);
            if (request != null)
            {
                request.UpdatedBy = _userDataService.GetUserId();
                request.UpdatedAt = DateTime.Now;
                request.RequestStatus = "Rejected";
                request.AdminId = _userDataService.GetUserId();
                request.Remarks = Remarks;
                _uowRequestMaster.Repository.Update(request);
                await _uowRequestMaster.SaveAsync();
            }
            return new ResponseDTO<RequestDTO>
            {
                Status = true,
                Message = "Request Rejected",
            };
        }


        //public async Task<RequestDTO> RejectRequest(RequestDTO request)
        //{
        //    return null;
        //}
        //public async Task<List<>> GetAll()
        //{
        //    try
        //    {
        //        var requests = await _uowRequestMaster.Repository.GetALL(x => x.IsActive == true).ToListAsync();
        //        var obj = _mapper.Map<List<RequestMasterDTO>>(requests);
        //        return obj;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public async Task<List<RequestDTO>> GetPendingRequestsList()
        //{
        //    try
        //    {
        //        var requests = await _uowRequest.Repository.GetALL(x => x.IsActive == true && x.Requ== "Pending").ToListAsync();
        //        var obj = _mapper.Map<List<RequestDTO>>(requests);
        //        return obj;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        public async Task<List<RequestMasterDTO>> GetPendingRequestsList()
        {
            try
            {

                var requests = await _uowRequestMaster.Repository.GetALL(x => x.IsActive == true && x.RequestStatus == "Pending").ToListAsync();
                var obj = _mapper.Map<List<RequestMasterDTO>>(requests);
                foreach (var o in obj)
                {
                    var healthFacility = await _uowHealthFacilties.Repository.GetALL(x => x.Id == o.UserHfId).FirstOrDefaultAsync();
                    o.HealthFacilityName = healthFacility?.FacilityName;
                }

                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<RequestDTO>> GetPendingRequestsDetailList(int RequestMaserId)
        {
            try
            {
                var requestsDetail = await _uowRequest.Repository.GetALL(x => x.IsActive == true && x.RequestId == RequestMaserId).ToListAsync();
                var obj = _mapper.Map<List<RequestDTO>>(requestsDetail);
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<RequestMasterDTO>> GetApprovedRequestsList()
        {
            try
            {
                var approvedRequests = await _uowRequestMaster.Repository.GetALL(x => x.IsActive == true && x.RequestStatus == "Approved" &&
                x.AdminId == _userDataService.GetUserId()).ToListAsync();
                var obj = _mapper.Map<List<RequestMasterDTO>>(approvedRequests);
                foreach (var o in obj)
                {
                    var healthFacility = await _uowHealthFacilties.Repository.GetALL(x => x.Id == o.UserHfId).FirstOrDefaultAsync();
                    o.HealthFacilityName = healthFacility?.FacilityName;
                }
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<RequestMasterDTO>> GetRejectedRequestsList()
        {
            try
            {
                var rejectedRequests = await _uowRequestMaster.Repository.GetALL(x => x.IsActive == true && x.RequestStatus == "Rejected" &&
                x.AdminId == _userDataService.GetUserId()).ToListAsync();
                var obj = _mapper.Map<List<RequestMasterDTO>>(rejectedRequests);
                foreach (var o in obj)
                {
                    var healthFacility = await _uowHealthFacilties.Repository.GetALL(x => x.Id == o.UserHfId).FirstOrDefaultAsync();
                    o.HealthFacilityName = healthFacility?.FacilityName;
                }
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<RequestMasterDTO>> GetRequestsListForUser()
        {
            try
            {
                var requestListforUser = await _uowRequestMaster.Repository.GetALL(x => x.IsActive == true && x.CreatedBy == _userDataService.GetUserId()).ToListAsync();
                var obj = _mapper.Map<List<RequestMasterDTO>>(requestListforUser);
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<Attachment> GetImageAndChequeDetails(int Requestid)
        {
            try
            {
                var chequeDetailforCurrentRequest = await _uowAttachment.Repository.GetALL(x => x.RequestId == Requestid).FirstOrDefaultAsync();
                return chequeDetailforCurrentRequest;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public async Task<Invoice> GetInvoiceAgainstTheApprovedRequest(RequestMasterDTO request)
        {
            try
            {
                var invoiceForTheRequest = await _uowInvoice.Repository.GetALL(x => x.InvoiceStatus == true && x.RequestId == request.Id).FirstOrDefaultAsync();
                return invoiceForTheRequest;
            }
            catch (Exception)
            {
                throw;
            }
        }

        //public async Task<List<RequestDTO>> GetRejectedRequestsList()
        //{
        //    try
        //    {
        //        var requests = await _uowRequest.Repository.GetALL(x => x.IsActive == true && x.Status == "Rejected" && x.AdminId == _userDataService.GetUserId()).ToListAsync();
        //        var obj = _mapper.Map<List<RequestDTO>>(requests);
        //        return obj;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //public async Task<RequestDTO> GetById(int RequestId)
        //{
        //    try
        //    {
        //        var request = await _uowRequest.Repository.GetALL(x => x.IsActive == true && x.Id == RequestId).FirstOrDefaultAsync();
        //        var obj = _mapper.Map<RequestDTO>(request);
        //        return obj;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //public async Task<bool> Delete(int RequestId)
        //{
        //    try
        //    {
        //        var request = await _uowRequest.Repository.GetById(RequestId);
        //        if (request != null)
        //        {
        //            request.IsActive = false;
        //            await _uowRequest.SaveAsync();
        //            return true;
        //        }
        //        return false;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}
