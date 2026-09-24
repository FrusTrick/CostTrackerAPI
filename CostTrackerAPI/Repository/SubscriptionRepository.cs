using CostTrackerAPI.Data;
using CostTrackerAPI.Models;
using CostTrackerAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CostTrackerAPI.Repository
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly CostTrackerAPIDBContext context;

        public SubscriptionRepository(CostTrackerAPIDBContext _context)
        {
            context = _context;
        }


        public async Task<Subscription> CreateSubscription(Subscription subscription)
        {
            context.Subscriptions.Add(subscription);
            await context.SaveChangesAsync();

            return subscription;
        }

        public async Task<bool> DeleteSubscription(int id)
        {
            var rowsaffected = await context.Subscriptions.Where(s => s.Id == id).ExecuteDeleteAsync();
            if (rowsaffected > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<Subscription> GetSubscriptionById(int id)
        {
            var subscription = await context.Subscriptions.FirstOrDefaultAsync(s => s.Id == id);
            return subscription;
        }

        public async Task<List<Subscription>> GetUserSubscriptions(int userId)
        {
            var subscriptions = await context.Subscriptions
                .Where(s => s.UserId == userId)
                .ToListAsync();
            if (subscriptions == null || subscriptions.Count == 0)
            {
                return new List<Subscription>();
            }

            return subscriptions        ;
        }

        public async Task<bool> UpdateSubscription(Subscription subscription)
        {
            var result = await context.Subscriptions
                .Where(s => s.Id == subscription.Id)
                .ExecuteUpdateAsync(s => s.SetProperty(p => 
                    p.CompanyName, 
                    subscription.CompanyName)
                .SetProperty(p => 
                    p.Cost, subscription.Cost));
            if (result > 0) 
            {
                return true;
            }

            return false;
        }
    }
}
