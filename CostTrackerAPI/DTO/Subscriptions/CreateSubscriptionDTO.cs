using CostTrackerAPI.DTO.Categories;

namespace CostTrackerAPI.DTO.Subscriptions
{
    public class CreateSubscriptionDTO
    {
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public int Cost { get; set; }
        public int CategoryId { get; set; }
    }
}
