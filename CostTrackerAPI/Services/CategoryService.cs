using CostTrackerAPI.Models;
using CostTrackerAPI.Services.IService;

namespace CostTrackerAPI.Services
{
    public class CategoryService : ICategoryService
    {
        
        public Task<CategoryDTO> CreateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> GetAllCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> UpdateCategoryAsync(int id, Category category)
        {
            throw new NotImplementedException();
        }
    }
}
