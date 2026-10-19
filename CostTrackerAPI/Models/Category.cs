using System.ComponentModel.DataAnnotations;

namespace CostTrackerAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public ICollection<Subscription> Subscriptions { get; set; }
    }
}
