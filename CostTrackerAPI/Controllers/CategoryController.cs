using CostTrackerAPI.DTO.Categories;
using CostTrackerAPI.Services;
using CostTrackerAPI.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace CostTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController( ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<ActionResult<CreateCategoryDTO>> CreateCategory(CreateCategoryDTO categoryDto)
        {
            var category = await _categoryService.CreateCategoryAsync(categoryDto);
            return Ok(category);
        }

        [HttpGet]
        public async Task<ActionResult<CategoryDTO>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            return Ok(category);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<bool>> UpdateCategory(int id, CategoryDTO categoryDto)
        {
            var result = await _categoryService.UpdateCategoryAsync(id, categoryDto);
            if (!result)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<bool>> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
