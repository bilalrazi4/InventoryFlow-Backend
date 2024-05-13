using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InventoryFlow.Service.Services
{
    public class UserDataService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserDataService(IHttpContextAccessor _httpContextAccessor)
        {
            this._httpContextAccessor = _httpContextAccessor;
        }
        public string GetUserId()
        {
            HttpContext httpContext = _httpContextAccessor.HttpContext;
            var userClaims = httpContext.User.Claims.ToList();
            var userId = userClaims.Where(x => x.Type == "UserId").FirstOrDefault().Value;
            return userId;
        }
        public int GetUserHFId()
        {
            HttpContext httpContext = _httpContextAccessor.HttpContext;
            var userClaims = httpContext.User.Claims.ToList();
            var userhfId = userClaims.Where(x => x.Type == "UserHFId").FirstOrDefault().Value;
            int.TryParse(userhfId, out int hfid);
            return hfid;
        }
    }
}
