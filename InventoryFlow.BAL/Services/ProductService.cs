using AutoMapper;
using InventoryFlow.Domain.DbModels;
using InventoryFlow.Domain.DTO_s.ProductDTO_s;
using InventoryFlow.Domain.Repositories;
using InventoryFlow.Service.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace InventoryFlow.Service.Services
{
    public class ProductService
    {
        private readonly UnitOfWork<Product> _uowProduct;
        private readonly IMapper _mapper;
        private readonly UserDataService _userDataService;

        public ProductService(UnitOfWork<Product> _uowProduct, IMapper _mapper, UserDataService _userDataService)
        {
            this._uowProduct = _uowProduct;
            this._mapper = _mapper;
            this._userDataService = _userDataService;
        }
        public async Task<ProductDTO> CreateOrUpdate(ProductDTO product)
        {
            try
            {
                var existingProduct = await _uowProduct.Repository.GetById(product.Id);
                if (existingProduct == null)
                {
                    var newProduct = _mapper.Map<Product>(product);
                    newProduct.CreatedAt = DateTime.Now;
                    newProduct.IsActive = true;
                    newProduct.CreatedBy = _userDataService.GetUserId();
                    await _uowProduct.Repository.InsertAsync(newProduct);
                    await _uowProduct.SaveAsync();
                    return _mapper.Map<ProductDTO>(newProduct);
                }
                else
                {
                    var obj = _mapper.Map(product, existingProduct);
                    obj.UpdatedAt = DateTime.Now;
                     obj.UpdatedBy = _userDataService.GetUserId();
                    _uowProduct.Repository.Update(obj);
                    await _uowProduct.SaveAsync();
                    return _mapper.Map<ProductDTO>(obj);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<ProductDTO>> GetAll()
        {
            try
            {
                var products = await _uowProduct.Repository.GetALL().ToListAsync();
                var obj = _mapper.Map<List<ProductDTO>>(products);
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ProductDTO> GetById(int ProductId)
        {
            try
            {
                var product = await _uowProduct.Repository.GetALL(x => x.IsActive == true && x.Id == ProductId).FirstOrDefaultAsync();
                var obj = _mapper.Map<ProductDTO>(product);
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> Delete(int ProductId)
        {
            try
            {
                var product = await _uowProduct.Repository.GetById(ProductId);
                if (product != null)
                {
                    product.IsActive = false;
                    await _uowProduct.SaveAsync();
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
