using InventoryFlow.Domain.DTO_s.CategoryDTO_s;
using InventoryFlow.Domain.DTO_s.ResponseDTO_s;
using InventoryFlow.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InventoryFlow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoryApiController : ControllerBase
    {
        private readonly CategoryService _categoryService;
        public CategoryApiController(CategoryService _categoryService)
        {
            this._categoryService = _categoryService;
        }
        #region CUD
        [HttpPost]
        [Route("CreateOrUpdateCategory")]
        public async Task<IActionResult> CreateOrUpdateCategory(CategoryDTO category)
        {
            var obj = await _categoryService.CreateOrUpdate(category);
            return Ok(new ResponseDTO<CategoryDTO> { Status = true, Message = "Successfully Saved or Updated", Data = obj });
        }
        [HttpDelete]
        [Route("DeleteCategory/{CategoryId}")]
        public async Task<IActionResult> DeleteCategory(int CategoryId)
        {
            var obj = await _categoryService.Delete(CategoryId);
            return Ok(new ResponseDTO<bool> { Status = obj, Message = obj ? "Successfully Deleted" : "Not found" });
        }

        #endregion
        #region Read API
        [HttpGet]
        [Route("GetAllCategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            var obj = await _categoryService.GetAll();
            return Ok(new ResponseDTO<List<CategoryDTO>> { Status = true, Message = "Record Fetched Successfully", Data = obj });
        }


        [HttpGet]
        [Route("GetCategoryById/{CategoryId}")]
        public async Task<IActionResult> GetCategoryById(int CategoryId)
        {
            var obj = await _categoryService.GetById(CategoryId);
            return Ok(new ResponseDTO<CategoryDTO> { Status = obj != null, Message = obj != null ? "Record Found" : "Record Not Found", Data = obj });
        }
        #endregion
    }
}
