using InventoryFlow.Domain.DTO_s.ApplicationUser;
using InventoryFlow.Domain.DTO_s.CategoryDTO_s;
using InventoryFlow.Domain.DTO_s.RegisterationDTO_s;
using InventoryFlow.Domain.DTO_s.ResponseDTO_s;
using InventoryFlow.Domain.DTO_s.StockDto_s;
using InventoryFlow.Domain.DTO_s.UserRegisterationDTO_s;
using InventoryFlow.Domain.DTO_s.UserRoles;
using InventoryFlow.Domain.Repositories;
using InventoryFlow.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InventoryFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserRegisterationController : ControllerBase
    {
        private readonly GeoLevelService _geolevelService;
        private readonly HealthFacilityService _HealthFacilityService;
        private readonly UserDataService _userDataService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public UserRegisterationController(UserManager<ApplicationUser> userManager,
            GeoLevelService _geolevelService,
            HealthFacilityService _HealthFacilityService,
            UserDataService _userDataService,
            RoleManager<IdentityRole> _roleManager)
        {
            this._geolevelService = _geolevelService;
            this._HealthFacilityService = _HealthFacilityService;
            this._userDataService = _userDataService;
            _userManager = userManager;
            this._roleManager = _roleManager;

        }
        [HttpGet]
        [Route("GetAllDistricts")]
        public async Task<IActionResult> GetAllDistricts()
        {
            var obj = await _geolevelService.GetDistricts();
            return Ok(new ResponseDTO<List<GeoLevelsDTO>> { Status = true, Message = "Record Fetched Successfully", Data = obj });

        }

        [HttpGet]
        [Route("GetAllTehsilByDistrict/{Pkcode}")]
        public async Task<IActionResult> GetAllTehsilByDistrict(string Pkcode)
        {
            var obj = await _geolevelService.GetTehsilsByDistrictCode(Pkcode);
            return Ok(new ResponseDTO<List<GeoLevelsDTO>> { Status = obj != null, Message = obj != null ? "Record Found" : "Record Not Found", Data = obj });
        }

        [HttpGet]
        [Route("GetAllHealthFacilitiesByTehsil/{Pkcode}")]
        public async Task<IActionResult> GetAllHealthFacilitiesByTehsil(string Pkcode)
        {
            var obj = await _HealthFacilityService.GetByTehsilCode(Pkcode);
            return Ok(new ResponseDTO<List<HealthFacilitiesDTO>> { Status = obj != null, Message = obj != null ? "Record Found" : "Record Not Found", Data = obj });
        }

        [HttpGet]
        [Route("GetAllHealthFacilities")]
        public async Task<IActionResult> GetAllHealthFacilities()
        {
            var obj = await _HealthFacilityService.GetAllHealthFacilties();
            return Ok(new ResponseDTO<List<HealthFacilitiesDTO>> { Status = obj != null, Message = obj != null ? "Record Found" : "Record Not Found", Data = obj });
        }


        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var obj = await _userDataService.GetAllRegisteredUsers();
            return Ok(new ResponseDTO<List<UserDetailDTO_s>> { Status = true, Message = "Record Fetched Successfully", Data = obj.Data });
        }


        [HttpGet]
        [Route("GetCurrentLoggedInUser")]
        public async Task<IActionResult> GetCurrentLoggedInUser()
        {
            var obj = await _userDataService.GetCurrentLoggedInUser();
            return Ok(new ResponseDTO<UserDetailDTO_s> { Status = true, Message = "Record Fetched Successfully", Data = obj.Data });
        }


        [HttpPost]
        [Route("RegisterNewUser")]
        public async Task<IActionResult> RegisterNewUser(UserRegisterDTO model)
        {
            var userExists = await _userManager.FindByNameAsync(model.CNIC);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDTO<string> { Status = false, Message = "User already exists!" });

            ApplicationUser user = new()
            {
                Email = model.CNIC + "@gmail.com",
                NormalizedUserName = model.Email,
                Hash = "Asd@123",
                FirstName = model.FirstName,
                LastName = model.LastName,
                FullName = model.FirstName + model.LastName,
                DistrictCode = model.DistrictCode,
                TownCode = model.TownCode,
                InstituteId = model.InstituteId,
                Designation = "User",
                CreatedBy = _userDataService.GetUserId(),
                CNIC = model.CNIC,
                CreatedDate = DateTime.Now,
                UserName = model.CNIC,
                PhoneNumber = model.PhoneNo,
                IsDisabled = false,
            };

            var result = await _userManager.CreateAsync(user, user.Hash);
            if (await _roleManager.RoleExistsAsync(UserRoles.User))
                await _userManager.AddToRoleAsync(user, UserRoles.User);

            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDTO<string> { Status = false, Message = "User creation failed! Please check user details and try again." });

            return Ok(new ResponseDTO<string> { Status = true, Message = "User created successfully!" });
        }
    }
}
