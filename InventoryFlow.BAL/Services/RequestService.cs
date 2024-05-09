using AutoMapper;
using InventoryFlow.Domain.DbModels;
using InventoryFlow.Domain.DTO_s.RequestDto_s;
using InventoryFlow.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InventoryFlow.Service.Services
{
    public class RequestService
    {
        private readonly UnitOfWork<Request> _uowRequest;
        private readonly IMapper _mapper;
        private readonly UserDataService _userDataService;

        public RequestService(UnitOfWork<Request> _uowRequest, IMapper _mapper, UserDataService _userDataService)
        {
            this._uowRequest = _uowRequest;
            this._mapper = _mapper;
            this._userDataService = _userDataService;
        }
        public async Task<RequestDTO> CreateOrUpdate(RequestDTO request)
        {
            try
            {
                var existingRequest = await _uowRequest.Repository.GetById(request.Id);
                if (existingRequest == null)
                {
                    var newRequest = _mapper.Map<Request>(request);
                    //newRequest.HfId = _userDataService.GetUserHFId();



                    newRequest.TotalPrice = newRequest.PricePerUnit * newRequest.TotalPrice;
                    newRequest.Status = "Pending";
                    newRequest.CreatedAt = DateTime.Now;
                    newRequest.IsActive = true;
                    newRequest.CreatedBy = _userDataService.GetUserId();
                    await _uowRequest.Repository.InsertAsync(newRequest);
                    await _uowRequest.SaveAsync();
                    return _mapper.Map<RequestDTO>(newRequest);
                }
                else
                {
                    var obj = _mapper.Map(request, existingRequest);
                    obj.UpdatedAt = DateTime.Now;
                    obj.UpdatedBy = _userDataService.GetUserId();
                    _uowRequest.Repository.Update(obj);
                    await _uowRequest.SaveAsync();
                    return _mapper.Map<RequestDTO>(obj);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<RequestDTO> AcceptRequest(RequestDTO request)
        {
            return null;
        }

        public async Task<RequestDTO> RejectRequest(RequestDTO request)
        {
            return null;
        }
        public async Task<List<RequestDTO>> GetAll()
        {
            try
            {
                var requests = await _uowRequest.Repository.GetALL(x => x.IsActive == true).ToListAsync();
                var obj = _mapper.Map<List<RequestDTO>>(requests);
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<RequestDTO> GetById(int RequestId)
        {
            try
            {
                var request = await _uowRequest.Repository.GetALL(x => x.IsActive == true && x.Id== RequestId).FirstOrDefaultAsync();
                var obj = _mapper.Map<RequestDTO>(request);
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> Delete(int RequestId)
        {
            try
            {
                var request = await _uowRequest.Repository.GetById(RequestId);
                if (request != null)
                {
                    request.IsActive = false;
                    await _uowRequest.SaveAsync();
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
