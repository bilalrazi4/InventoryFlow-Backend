using InventoryFlow.Domain.DTO_s.ApplicationUser;
using InventoryFlow.Domain.DTO_s.CategoryDTO_s;
using InventoryFlow.Domain.DTO_s.RegisterationDTO_s;
using InventoryFlow.Domain.DTO_s.ResponseDTO_s;
using InventoryFlow.Domain.DTO_s.StockDto_s;
using InventoryFlow.Domain.DTO_s.UserRegisterationDTO_s;
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
        private readonly GeoLevelService _GeolevelService;
        private readonly HealthFacilityService _HealthFacilityService;
        private readonly UserDataService _userDataService;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserRegisterationController(UserManager<ApplicationUser> userManager,GeoLevelService _GeolevelService, HealthFacilityService _HealthFacilityService, UserDataService _userDataService)
        {
            this._GeolevelService = _GeolevelService;
            this._HealthFacilityService = _HealthFacilityService;
            this._userDataService = _userDataService;
           this. _userManager = userManager;

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

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
          
            char[] stringChars = new char[8];

            // Ensure at least one capital letter
            stringChars[0] = chars[random.Next(26)]; // Pick a random capital letter
           
            for (int i = 1; i < 8; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var password= new string(stringChars);
            password = password + "@";
            ApplicationUser user = new()
            {
                Email = model.CNIC+"@gmail.com",
                NormalizedUserName=model.Email,
                SecurityStamp = password,
                Hash= password,
                FirstName= model.FirstName,
                LastName= model.LastName,
                FullName= model.FirstName+model.LastName,
                CNIC= model.CNIC,
                CreatedDate= DateTime.Now,
                UserName = model.CNIC,
                PhoneNumber = model.PhoneNo,
                IsDisabled = false,
            };
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new ResponseDTO<string> { Status = false, Message = "User creation failed! Please check user details and try again." });

            return Ok(new ResponseDTO<string> { Status = true, Message = "User created successfully!" });
        }
    }
}
