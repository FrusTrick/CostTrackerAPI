using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CostTrackerAPI.Models
{
    public class User : IdentityUser<int>
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        public List<Subscription> UserSubscriptions { get; set; }
        public List<CostHistory> UserCostHistory { get; set; }
        public List<Category> UserCategories { get; set; }
    }
}
