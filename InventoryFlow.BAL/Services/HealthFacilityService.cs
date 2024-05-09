using AutoMapper;
using InventoryFlow.Domain.DbModels;
using InventoryFlow.Domain.DTO_s.CategoryDTO_s;
using InventoryFlow.Domain.DTO_s.UserRegisterationDTO_s;
using InventoryFlow.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InventoryFlow.Service.Services
{
    public class HealthFacilityService
    {
        private readonly UnitOfWork<HealthFacilitiesNew> _uowHealthFacility;
        private readonly IMapper _mapper;
        private readonly UserDataService _userDataService;

        public HealthFacilityService(UnitOfWork<HealthFacilitiesNew> _uowHealthFacility, IMapper _mapper, UserDataService _userDataService)
        {
            this._uowHealthFacility = _uowHealthFacility;
            this._mapper = _mapper;
            this._userDataService = _userDataService;
        }

        public async Task<List<HealthFacilitiesDTO>> GetByTehsilCode(string Pkcode)
        {
            try
            {
                var category = await _uowHealthFacility.Repository.GetALL(x => x.FacilityStatus == 1 && x.TehsilCode == Pkcode).ToListAsync();
                var obj = _mapper.Map<List<HealthFacilitiesDTO>>(category);
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
