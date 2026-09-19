using System.Data.Common;

namespace CostTrackerAPI.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CompanyName { get; set; }
        public int Cost { get; set; }
        public Category SubscriptionCategory { get; set; }
    }
}
