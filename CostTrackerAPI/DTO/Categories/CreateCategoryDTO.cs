using System.ComponentModel.DataAnnotations;

namespace CostTrackerAPI.DTO.Categories
{
    public class CreateCategoryDTO
    {
        [Required]
        [MaxLength(100)]
        public string CategoryName { get; set; }
    }
}
