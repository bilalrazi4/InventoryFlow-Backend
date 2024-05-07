using AutoMapper;
using InventoryFlow.Domain.DbModels;
using InventoryFlow.Domain.DTO_s.CategoryDTO_s;
using InventoryFlow.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace InventoryFlow.Service.Services
{
    public class CategoryService
    {
        private readonly UnitOfWork<Category> _uowCategory;
        private readonly IMapper _mapper;
        private readonly UserDataService _userDataService;

        public CategoryService(UnitOfWork<Category> _uowCategory, IMapper _mapper, UserDataService _userDataService)
        {
            this._uowCategory = _uowCategory;
            this._mapper = _mapper;
            this._userDataService = _userDataService;
        }
        public async Task<CategoryDTO> CreateOrUpdate(CategoryDTO category)
        {
            try
            {
                var existingCategory = await _uowCategory.Repository.GetById(category.Id);
                if (existingCategory == null)
                {
                    var newCategory = _mapper.Map<Category>(category);
                    newCategory.CreatedAt = DateTime.Now;
                    newCategory.IsActive = true;
                    newCategory.CreatedBy = _userDataService.GetUserId();
                    await _uowCategory.Repository.InsertAsync(newCategory);
                    await _uowCategory.SaveAsync();
                    return _mapper.Map<CategoryDTO>(newCategory);
                }
                else
                {
                    var obj = _mapper.Map(category, existingCategory);
                    obj.UpdatedAt = DateTime.Now;
                    obj.UpdatedBy = _userDataService.GetUserId();
                    _uowCategory.Repository.Update(obj);
                    await _uowCategory.SaveAsync();
                    return _mapper.Map<CategoryDTO>(obj);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<CategoryDTO>> GetAll()
        {
            try
            {
                var categories = await _uowCategory.Repository.GetALL(x => x.IsActive == true).ToListAsync();
                var obj = _mapper.Map<List<CategoryDTO>>(categories);
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<CategoryDTO> GetById(int CategoryId)
        {
            try
            {
                var category = await _uowCategory.Repository.GetALL(x => x.IsActive == true && x.Id == CategoryId).FirstOrDefaultAsync();
                var obj = _mapper.Map<CategoryDTO>(category);
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<bool> Delete(int CategoryId)
        {
            try
            {
                var category = await _uowCategory.Repository.GetById(CategoryId);
                if (category != null)
                {
                    category.IsActive = false;
                    await _uowCategory.SaveAsync();
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
