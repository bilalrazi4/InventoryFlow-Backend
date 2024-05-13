using AutoMapper;
using Dapper;
using InventoryFlow.Domain.DbModels;
using InventoryFlow.Domain.DTO_s.RegisterationDTO_s;
using InventoryFlow.Domain.DTO_s.ResponseDTO_s;
using InventoryFlow.Domain.DTO_s.StockDto_s;
using InventoryFlow.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InventoryFlow.Service.Services
{
    public class UserDataService

    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UnitOfWork<HealthFacilitiesNew> _uowHealthFacility;
        private readonly IMapper _mapper;

        public UserDataService(IHttpContextAccessor _httpContextAccessor, UnitOfWork<HealthFacilitiesNew> uowHealthFacility, IMapper _mapper)
        {
            this._httpContextAccessor = _httpContextAccessor;
            _uowHealthFacility = uowHealthFacility;
            this._mapper = _mapper;
        }
        public string GetUserId()
        {
            HttpContext httpContext = _httpContextAccessor.HttpContext;
            var userClaims = httpContext.User.Claims.ToList();
            var userId = userClaims.Where(x => x.Type == "UserId").FirstOrDefault().Value;
            return userId;
        }
    }
}
