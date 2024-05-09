using InventoryFlow.Domain.DTO_s.CategoryDTO_s;
using InventoryFlow.Domain.DTO_s.ResponseDTO_s;
using InventoryFlow.Domain.DTO_s.UserRegisterationDTO_s;
using InventoryFlow.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UserRegisterationController : ControllerBase
    {
        private readonly GeoLevelService _GeolevelService;
        private readonly HealthFacilityService _HealthFacilityService;
        public UserRegisterationController(GeoLevelService _GeolevelService, HealthFacilityService _HealthFacilityService)
        {
            this._GeolevelService = _GeolevelService;
            this._HealthFacilityService = _HealthFacilityService;
        }
        [HttpGet]
        [Route("GetAllDistricts")]
        public async Task<IActionResult> GetAllDistricts()
        {
            var obj = await _GeolevelService.GetDistricts();
            return Ok(new ResponseDTO<List<GeoLevelsDTO>> { Status = true, Message = "Record Fetched Successfully", Data = obj });

        }

        [HttpGet]
        [Route("GetAllTehsilByDistrict/{Pkcode}")]
        public async Task<IActionResult> GetAllTehsilByDistrict(string Pkcode)
        {
            var obj = await _GeolevelService.GetTehsilsByDistrictCode(Pkcode);
            return Ok(new ResponseDTO<List<GeoLevelsDTO>> { Status = obj != null, Message = obj != null ? "Record Found" : "Record Not Found", Data = obj });
        }

        [HttpGet]
        [Route("GetAllHealthFacilitiesByTehsil/{Pkcode}")]
        public async Task<IActionResult> GetAllHealthFacilitiesByTehsil(string Pkcode)
        {
            var obj = await _HealthFacilityService.GetByTehsilCode(Pkcode);
            return Ok(new ResponseDTO<List<HealthFacilitiesDTO>> { Status = obj != null, Message = obj != null ? "Record Found" : "Record Not Found", Data = obj });
        }
    }
}
