using AutoMapper;
using Azure.Core;
using InventoryFlow.Domain.DbModels;
using InventoryFlow.Domain.DTO_s.RequestDto_s;
using InventoryFlow.Domain.DTO_s.ResponseDTO_s;
using InventoryFlow.Domain.DTO_s.StockDto_s;
using InventoryFlow.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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


                //this is so that i can add the requestIdentifier against the request I just inserted


                var initials = await GetInitials();
                newRequestMaster.RequestIdentifier = initials + newRequestMaster.Id;
                _uowRequestMaster.Repository.Update(newRequestMaster);
                await _uowRequestMaster.SaveAsync();


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
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> GetInitials()
        {
            var userFacility = await _uowHealthFacilties.Repository.GetALL(x => x.Id == _userDataService.GetUserHFId()).FirstOrDefaultAsync();

            if (string.IsNullOrEmpty(userFacility.FacilityName))
                return string.Empty;

            var initials = string.Concat(userFacility.FacilityName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                             .Select(word => word[0]));

            return initials;
        }
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
                requestDetailtoDelete.Remarks = "Request Rejected";
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

        public async Task<List<RequestDTO>> GetAcceptedRequestsDetailListForUser(int RequestMaserId)
        {
            try
            {
                var requestsDetail = await _uowRequest.Repository.GetALL(x => x.RequestId == RequestMaserId && x.Remarks == "product has been dispensed").ToListAsync();
                var obj = _mapper.Map<List<RequestDTO>>(requestsDetail);
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<RequestMasterDTO> GetRequestMasterByRequestId(int RequestMaserId)
        {
            try
            {
                var requestMaster = await _uowRequestMaster.Repository.GetALL(x => x.Id == RequestMaserId).FirstOrDefaultAsync();

                var Facility = await _uowHealthFacilties.Repository.GetALL(x => x.Id == requestMaster.UserHfId).FirstOrDefaultAsync();

                var obj = _mapper.Map<RequestMasterDTO>(requestMaster);
                obj.HealthFacilityName = Facility.FacilityName;
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
                var requestListforUser = await _uowRequestMaster.Repository.GetALL(x => x.IsActive == true && x.UserHfId == _userDataService.GetUserHFId()).ToListAsync();
                var obj = _mapper.Map<List<RequestMasterDTO>>(requestListforUser);
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

        public async Task<bool> AcceptTheRequest(int Requestid)
        {
            try
            {
                var requestList = await _uowRequest.Repository.GetALL(x => x.RequestId == Requestid).ToListAsync();
                var batchList = await _uowStockOut.Repository.GetALL(x => x.RequestId == Requestid).ToListAsync();
                foreach (var batch in batchList)
                {
                    var stockToEditQuantity = await _uowStock.Repository.GetALL(x => x.Id == batch.StockId).FirstOrDefaultAsync();
                    var obj = _mapper.Map<StockDTO>(stockToEditQuantity);
                    if (obj.Quantity >= batch.ApprovedQuantity)
                        obj.Quantity -= batch.ApprovedQuantity;
                    obj.UpdatedAt = DateTime.Now;
                    obj.UpdatedBy = _userDataService.GetUserId();
                    if (obj.Quantity <= 0)
                    {
                        obj.IsActive = false;
                        obj.InStock = false;
                    }
                    var objtoInsert = _mapper.Map<Stock>(obj);
                    _uowStock.Detach(stockToEditQuantity);
                    _uowStock.Repository.Update(objtoInsert);
                    await _uowStock.SaveAsync();
                }
                foreach (var request in requestList)
                {
                    var requestToSetActiveFalse = await _uowRequest.Repository.GetALL(x => x.Id == request.Id).FirstOrDefaultAsync();
                    var obj = _mapper.Map<RequestDTO>(requestToSetActiveFalse);

                    obj.IsActive = false;
                    obj.Remarks = "product has been dispensed";
                    var objtoInsert = _mapper.Map<Request>(obj);
                    _uowRequest.Detach(requestToSetActiveFalse);

                    _uowRequest.Repository.Update(objtoInsert);
                    await _uowRequest.SaveAsync();
                }
                var requestToAccept = await _uowRequestMaster.Repository.GetALL(x => x.Id == Requestid).FirstOrDefaultAsync();
                var _obj = _mapper.Map<RequestMasterDTO>(requestToAccept);
                _obj.Remarks = "Request has been Accepted";
                _obj.RequestStatus = "Accepted";
                var _objtoInsert = _mapper.Map<RequestMaster>(_obj);
                _uowRequestMaster.Detach(requestToAccept);
                _uowRequestMaster.Repository.Update(_objtoInsert);
                await _uowRequestMaster.SaveAsync();




                return true;

            }
            catch (Exception)
            {
                throw;
            }

        }

        //public async Task<bool> AcceptTheRequest(int Requestid)
        //{
        //    using (var transaction = _uowStock.GetDbContext().Database.BeginTransaction())
        //        try
        //        {

        //            var requestList = await _uowRequest.Repository.GetALL(x => x.RequestId == Requestid).ToListAsync();
        //            var batchList = await _uowStockOut.Repository.GetALL(x => x.RequestId == Requestid).ToListAsync();
        //            List<Stock> stockListToUpdate = [];
        //            foreach (var batch in batchList)
        //            {
        //                var stockToEditQuantity = await _uowStock.Repository.GetALL(x => x.Id == batch.StockId).FirstOrDefaultAsync();
        //                var obj = _mapper.Map<StockDTO>(stockToEditQuantity);
        //                if (obj.Quantity >= batch.ApprovedQuantity)
        //                    obj.Quantity -= batch.ApprovedQuantity;
        //                obj.UpdatedAt = DateTime.Now;
        //                obj.UpdatedBy = _userDataService.GetUserId();
        //                if (obj.Quantity <= 0)
        //                {
        //                    obj.IsActive = false;
        //                    obj.InStock = false;
        //                }
        //                var objtoInsert = _mapper.Map<Stock>(obj);
        //                _uowStock.Detach(stockToEditQuantity);
        //                stockListToUpdate.Add(objtoInsert);
        //                // _uowStock.Detach(stockToEditQuantity);
        //                //_uowStock.Repository.Update(objtoInsert);
        //                //await _uowStock.SaveAsync();
        //            }
        //            _uowStock.Repository.UpdateRange(stockListToUpdate);
        //            await _uowStock.SaveAsync();


        //            List<Request> requestListToUpdate = [];
        //            foreach (var request in requestList)
        //            {
        //                var requestToSetActiveFalse = await _uowRequest.Repository.GetALL(x => x.Id == request.Id).FirstOrDefaultAsync();
        //                var obj = _mapper.Map<RequestDTO>(requestToSetActiveFalse);
        //                obj.IsActive = false;
        //                obj.Remarks = "product has been dispensed";
        //                var objtoInsert = _mapper.Map<Request>(obj);
        //                requestListToUpdate.Add(objtoInsert);
        //                //_uowRequest.Detach(requestToSetActiveFalse);
        //                //  _uowRequest.Detach(requestToSetActiveFalse);
        //                // _uowRequest.Repository.Update(objtoInsert);
        //                // await _uowRequest.SaveAsync();
        //            }
        //            _uowRequest.Repository.UpdateRange(requestListToUpdate);
        //            await _uowRequest.SaveAsync();

        //            var requestToAccept = await _uowRequestMaster.Repository.GetALL(x => x.Id == Requestid).FirstOrDefaultAsync();
        //            var _obj = _mapper.Map<RequestMasterDTO>(requestToAccept);
        //            _obj.Remarks = "Request has been Accepted";
        //            _obj.RequestStatus = "Accepted";
        //            var _objtoInsert = _mapper.Map<RequestMaster>(_obj);
        //            //  _uowRequestMaster.Detach(requestToAccept);
        //            _uowRequestMaster.Repository.Update(_objtoInsert);
        //            await _uowRequestMaster.SaveAsync();

        //            await transaction.CommitAsync();
        //            return true;

        //        }
        //        catch (Exception)
        //        {
        //            await transaction.RollbackAsync();
        //            throw;
        //        }

        //}



        //public async Task<bool> AcceptTheRequest(int Requestid)
        //{
        //    using (var transaction = _uowHealthFacilties.GetDbContext().Database.BeginTransaction())
        //        try
        //        {

        //            var requestList = await _uowRequest.Repository.GetALL(x => x.RequestId == Requestid).ToListAsync();
        //            var batchList = await _uowStockOut.Repository.GetALL(x => x.RequestId == Requestid).ToListAsync();
        //            //getting the stockId's of each batch that are in batchList
        //            var currentStockIdsList = batchList.Select(x => x.StockId).ToList();
        //            //getting the stockList through the stockId's that are in stockIdsList that corresponds to each batch/stockItem 
        //            var currentStockList = await _uowStock.Repository.GetALL(x => currentStockIdsList.Contains(x.Id)).ToListAsync();

        //            List<Stock> stockListToUpdate = [];
        //            foreach (var batch in batchList)
        //            {
        //                var stockToEditQuantity = currentStockList.FirstOrDefault(x => x.Id == batch.StockId);
        //                var obj = _mapper.Map<StockDTO>(stockToEditQuantity);
        //                if (obj.Quantity >= batch.ApprovedQuantity)
        //                    obj.Quantity -= batch.ApprovedQuantity;
        //                obj.UpdatedAt = DateTime.Now;
        //                obj.UpdatedBy = _userDataService.GetUserId();
        //                if (obj.Quantity <= 0)
        //                {
        //                    obj.IsActive = false;
        //                    obj.InStock = false;
        //                }
        //                var objtoInsert = _mapper.Map<Stock>(obj);
        //               // _uowStock.Detach(stockToEditQuantity);
        //                stockListToUpdate.Add(objtoInsert);
        //                // _uowStock.Detach(stockToEditQuantity);
        //                //_uowStock.Repository.Update(objtoInsert);
        //                //await _uowStock.SaveAsync();
        //            }
        //            _uowStock.Repository.UpdateRange(stockListToUpdate);
        //            await _uowStock.SaveAsync();


        //            List<Request> requestListToUpdate = [];
        //            var currentRequestIdsList = requestList.Select(x => x.Id).ToList();
        //            var currentRequestList = await _uowRequest.Repository.GetALL(x=>currentRequestIdsList.Contains(x.Id)).ToListAsync();
        //            foreach (var request in requestList)
        //            {
        //                var requestToSetActiveFalse = currentRequestList.FirstOrDefault(x=>x.Id==request.Id);
        //                var obj = _mapper.Map<RequestDTO>(requestToSetActiveFalse);
        //                obj.IsActive = false;
        //                obj.Remarks = "product has been dispensed";
        //                var objtoInsert = _mapper.Map<Request>(obj);
        //                requestListToUpdate.Add(objtoInsert);
        //                //_uowRequest.Detach(requestToSetActiveFalse);
        //                //  _uowRequest.Detach(requestToSetActiveFalse);
        //                // _uowRequest.Repository.Update(objtoInsert);
        //                // await _uowRequest.SaveAsync();
        //            }
        //            _uowRequest.Repository.UpdateRange(requestListToUpdate);
        //            await _uowRequest.SaveAsync();

        //            var requestToAccept = await _uowRequestMaster.Repository.GetALL(x => x.Id == Requestid).FirstOrDefaultAsync();
        //            var _obj = _mapper.Map<RequestMasterDTO>(requestToAccept);
        //            _obj.Remarks = "Request has been Accepted";
        //            _obj.RequestStatus = "Accepted";
        //            var _objtoInsert = _mapper.Map<RequestMaster>(_obj);
        //            //  _uowRequestMaster.Detach(requestToAccept);
        //            _uowRequestMaster.Repository.Update(_objtoInsert);
        //            await _uowRequestMaster.SaveAsync();

        //            await transaction.CommitAsync();
        //            return true;

        //        }
        //        catch (Exception)
        //        {
        //            await transaction.RollbackAsync();
        //            throw;
        //        }

        //}





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
