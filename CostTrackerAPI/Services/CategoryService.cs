using CostTrackerAPI.DTO.Categories;
using CostTrackerAPI.Models;
using CostTrackerAPI.Repository.IRepository;
using CostTrackerAPI.Services.IService;

namespace CostTrackerAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public async Task<CategoryDTO> CreateCategoryAsync(CreateCategoryDTO newCategory)
        {
            Category incomingCategory = new Category
            {
                Name = newCategory.CategoryName
            };

            var createdCategory = await _categoryRepository.CreateCategoryAsync(incomingCategory);
            var createdDto = MapToCategoryDTO(createdCategory);
            return createdDto;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            return await _categoryRepository.DeleteCategoryAsync(id);
        }

        public async Task<List<CategoryDTO>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.ListCategoriesAsync();
            var categoryDTOs = categories.Select(c => MapToCategoryDTO(c)).ToList();

            return categoryDTOs;
        }           
        

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var result = await _categoryRepository.GetCategoryByIdAsync(id);
            return result; 
        }

        public async Task<bool> UpdateCategoryAsync(int id, CategoryDTO category)
        {
            var mapped = MapToCategory(category);
            var result = await _categoryRepository.UpdateCategoryAsync(mapped);
           
            return result;
        }


        //Below are private helper methods to map Category to CategoryDTO and vice versa.

        private CategoryDTO MapToCategoryDTO(Category category)
        {
            return new CategoryDTO
            {
                CategoryId = category.Id,
                CategoryName = category.Name
            };
        }

        private Category MapToCategory(CategoryDTO categoryDTO)
        {
            return new Category
            {
                Id = categoryDTO.CategoryId,
                Name = categoryDTO.CategoryName
            };
        }
    }
}
