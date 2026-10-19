using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Common;

namespace CostTrackerAPI.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        [MaxLength(100)]
        public string CompanyName { get; set; }
        [Required]
        public int Cost { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category SubscriptionCategory { get; set; }
    }
}
