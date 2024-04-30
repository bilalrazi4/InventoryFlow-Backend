using AutoMapper;
using InventoryFlow.Domain.DbModels;
using InventoryFlow.Domain.DTO_s.ProductDTO_s;
using InventoryFlow.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryFlow.Service.Services
{
    public class ProductService
    {
        private readonly UnitOfWork<Product> _uowProduct;
        private readonly IMapper _mapper;
        public ProductService(UnitOfWork<Product> _uowProduct, IMapper _mapper)
        {
            this._uowProduct = _uowProduct;
            this._mapper = _mapper;
        }
        public async Task<ProductDTO> CreateOrUpdate(ProductDTO product)
        {
            try
            {
                var obj = _mapper.Map<Product>(product);
                if (product.Id == null)
                {
                    obj.CreatedAt = DateTime.Now;
                    obj.IsActive = true;
                    //obj.createedBy
                    await _uowProduct.Repository.InsertAsync(obj);
                }
                else
                {
                    obj.UpdatedAt = DateTime.Now;
                    //obj.updatedBy
                    await _uowProduct.Repository.InsertAsync(obj);
                    _uowProduct.Repository.Update(obj);
                }

                await _uowProduct.SaveAsync();
                return _mapper.Map<ProductDTO>(obj);
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
                var products = await _uowProduct.Repository.GetALL(x=>x.IsActive==true).ToListAsync();
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
                
                var product = await _uowProduct.Repository.GetALL(x=>x.IsActive==true && x.Id==ProductId).FirstOrDefaultAsync();
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
