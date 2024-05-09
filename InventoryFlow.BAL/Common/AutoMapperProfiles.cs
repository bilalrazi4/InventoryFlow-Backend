using InventoryFlow.Domain.DTO_s.CategoryDTO_s;
using InventoryFlow.Domain.DTO_s.ProductDTO_s;
using InventoryFlow.Domain.DTO_s.StockDto_s;
using InventoryFlow.Domain.DTO_s.UserRegisterationDTO_s;
using InventoryFlow.Domain.DTO_s.VendorDTO_s;
using autoMapper = AutoMapper;
using DbModels = InventoryFlow.Domain.DbModels;
namespace InventoryFlow.Service.Common
{
    public class AutoMapperProfiles
    {
        public class ProductProfile:autoMapper.Profile
        {
            public ProductProfile()
            {
                CreateMap<DbModels.Product, ProductDTO>().ReverseMap().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            }
        }
        public class VendorProfile : autoMapper.Profile
        {
            public VendorProfile()
            {
                CreateMap<DbModels.Vendor, VendorDTO>().ReverseMap().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            }
        }
        public class CategoryProfile : autoMapper.Profile
        {
            public CategoryProfile()
            {
                CreateMap<DbModels.Category, CategoryDTO>().ReverseMap().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            }
        }
        public class StockProfile : autoMapper.Profile
        {
            public StockProfile()
            {
                CreateMap<DbModels.Stock, StockDTO>().ReverseMap().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            }
        }
        public class GeoLevelProfile : autoMapper.Profile
        {
            public GeoLevelProfile()
            {
                CreateMap<DbModels.GeoLevel, GeoLevelsDTO>().ReverseMap().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
               
            }
        }
        public class HealthFacilityNewProfile : autoMapper.Profile
        {
            public HealthFacilityNewProfile()
            {
                CreateMap<DbModels.HealthFacilitiesNew, HealthFacilitiesDTO>().ReverseMap().ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            }
        }
    }
}
