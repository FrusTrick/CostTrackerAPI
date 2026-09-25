using CostTrackerAPI.DTO.Categories;
using CostTrackerAPI.Models;

namespace CostTrackerAPI.Services.IService
{
    public interface ICategoryService
    {
        Task<List<CategoryDTO>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<CategoryDTO> CreateCategoryAsync(CreateCategoryDTO newCategory);
        Task<CategoryDTO> UpdateCategoryAsync(int id, CategoryDTO category);
        Task<bool> DeleteCategoryAsync(int id);

    }
}
