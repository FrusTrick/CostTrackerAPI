using System.ComponentModel.DataAnnotations;

namespace CostTrackerAPI.DTO.Categories
{
    public class CategoryDTO
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category name is required")]
        [MaxLength(100, ErrorMessage = "Category name cannot exceed 100 characters")]
        public string CategoryName { get; set; }
    }
}
