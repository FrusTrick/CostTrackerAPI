using CostTrackerAPI.DTO.Categories;
using System.ComponentModel.DataAnnotations;

namespace CostTrackerAPI.DTO.Subscriptions
{
    public class CreateSubscriptionDTO
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Company name is required")]
        [MaxLength(100, ErrorMessage = "Company name cannot exceed 100 characters")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Cost is required")]
        public int Cost { get; set; }

        [Required(ErrorMessage = "A valid category ID is required")]
        public int CategoryId { get; set; }
    }
}
