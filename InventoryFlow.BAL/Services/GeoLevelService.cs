using AutoMapper;
using InventoryFlow.Domain.DbModels;
using InventoryFlow.Domain.DTO_s.CategoryDTO_s;
using InventoryFlow.Domain.DTO_s.UserRegisterationDTO_s;
using InventoryFlow.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InventoryFlow.Service.Services
{
    public class GeoLevelService
    {
        private readonly UnitOfWork<GeoLevel> _uowGeolevel;
        private readonly IMapper _mapper;
        private readonly UserDataService _userDataService;

        public GeoLevelService(UnitOfWork<GeoLevel> _uowGeolevel, IMapper _mapper, UserDataService _userDataService)
        {
            this._uowGeolevel = _uowGeolevel;
            this._mapper = _mapper;
            this._userDataService = _userDataService;
        }
        public async Task<List<GeoLevelsDTO>> GetDistricts()
        {
            try
            {
                var GeolevelData = await _uowGeolevel.Repository.GetALL(x => x.EnableFlag == "Y" && x.Lvl== "District").ToListAsync();
                var obj = _mapper.Map<List<GeoLevelsDTO>>(GeolevelData);
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<GeoLevelsDTO>> GetTehsilsByDistrictCode(string Pkcode)
        {
            try
            {
                var GetTehsilsByDistrictCode = await _uowGeolevel.Repository.GetALL(x => x.EnableFlag == "Y" && x.Fkcode == Pkcode && x.Lvl == "Tehsil").ToListAsync();
                var obj = _mapper.Map<List<GeoLevelsDTO>>(GetTehsilsByDistrictCode);
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
