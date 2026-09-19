using CostTrackerAPI.Models;
using CostTrackerAPI.Repository.IRepository;

namespace CostTrackerAPI.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        public Task<Category> CreateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Category>> ListCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
