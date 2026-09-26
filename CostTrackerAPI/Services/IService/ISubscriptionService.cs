using CostTrackerAPI.Models;
using CostTrackerAPI.DTO.Subscriptions;

namespace CostTrackerAPI.Services.IService
{
    public interface ISubscriptionService
    {
        Task<List<SubscriptionDTO>> GetAllSubscriptionsAsync(int userId);
        Task<SubscriptionDTO> GetSubscriptionByIdAsync(int id);
        Task<SubscriptionDTO> CreateSubscriptionAsync(CreateSubscriptionDTO subscription);
        Task<bool> UpdateSubscriptionAsync(int id, SubscriptionDTO subscription);
        Task<bool> DeleteSubscriptionAsync(int id);
    }
}
