using CostTrackerAPI.Models;

namespace CostTrackerAPI.Repository.IRepository
{
    public interface ISubscriptionRepository
    {
        public Task<List<Subscription>> GetUserSubscriptions(int userId);
        public Task<Subscription> GetSubscriptionById(int id);
        public Task<Subscription> CreateSubscription(Subscription subscription);
        public Task<bool> UpdateSubscription(Subscription subscription);
        public Task<bool> DeleteSubscription(int id);
    }
}
