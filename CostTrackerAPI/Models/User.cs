using Microsoft.AspNetCore.Identity;

namespace CostTrackerAPI.Models
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Subscription> UserSubscriptions { get; set; }
        public List<CostHistory> UserCostHistory { get; set; }
    }
}
