using CostTrackerAPI.DTO.Categories;

namespace CostTrackerAPI.DTO.Subscriptions
{
    public class SubscriptionDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public int Cost { get; set; }

        public int CategoryId { get; set; }
        public CategoryDTO SubscriptionCategory { get; set; }
    }
}
