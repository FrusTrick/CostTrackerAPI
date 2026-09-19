using CostTrackerAPI.Models;

namespace CostTrackerAPI.Repository.IRepository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> ListCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);
        Task<Category> CreateCategoryAsync(Category category);
        Task<bool> UpdateCategoryAsync(Category category);
        Task<bool> DeleteCategoryAsync(int id);

    }
}
