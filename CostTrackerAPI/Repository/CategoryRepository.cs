using CostTrackerAPI.Data;
using CostTrackerAPI.Models;
using CostTrackerAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CostTrackerAPI.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CostTrackerAPIDBContext context;

        public CategoryRepository(CostTrackerAPIDBContext _context)
        {
            context = _context;
        }


        public async Task<Category> CreateCategoryAsync(Category newCategory)
        {
           context.Categories.Add(newCategory);
           await context.SaveChangesAsync();
           return newCategory;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
           int rowsAffected = await context.Categories.Where(c => c.Id == id).ExecuteDeleteAsync();
           if(rowsAffected > 0)
           {
                return true;
           }

           return false;
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            Category category = await context.Categories.FirstOrDefaultAsync(c => c.Id == id);

            return category;
        }

        public async Task<List<Category>> ListCategoriesAsync()
        {
            List<Category> categoryList = await context.Categories.ToListAsync();

            return categoryList;
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            context.Categories.Update(category);
            int result = await context.SaveChangesAsync();

            if(result > 0)
            {
                return true;
            }
            return false;
        }
    }
}
