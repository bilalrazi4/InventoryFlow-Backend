using InventoryFlow.Domain.DbModels;
using InventoryFlow.Domain.DTO_s.ProductDTO_s;
using autoMapper = AutoMapper;
using DbModel = InventoryFlow.Domain.DbModels;
namespace InventoryFlow.Service.Common
{
    public class AutoMapperProfiles
    {
        public class ProductProfile:autoMapper.Profile
        {
            public ProductProfile()
            {
                CreateMap<DbModel.Product, ProductDTO>().ReverseMap();
            }

        }
    }
}
