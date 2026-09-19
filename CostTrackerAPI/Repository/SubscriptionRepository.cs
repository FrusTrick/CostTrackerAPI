using CostTrackerAPI.Models;
using CostTrackerAPI.Repository.IRepository;

namespace CostTrackerAPI.Repository
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        public Task<Subscription> CreateSubscription(Subscription subscription)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteSubscription(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Subscription> GetSubscriptionById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Subscription>> GetUserSubscriptions(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateSubscription(Subscription subscription)
        {
            throw new NotImplementedException();
        }
    }
}
