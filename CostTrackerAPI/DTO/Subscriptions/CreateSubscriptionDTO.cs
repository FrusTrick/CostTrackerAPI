using CostTrackerAPI.Models;

namespace CostTrackerAPI.DTO.Subscriptions
{
    public class CreateSubscriptionDTO
    {
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public int Cost { get; set; }
        public Category SubscriptionCategory { get; set; }
    }
}
