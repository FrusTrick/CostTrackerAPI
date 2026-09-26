using CostTrackerAPI.Models;
using CostTrackerAPI.DTO.Subscriptions;
using CostTrackerAPI.Services.IService;
using CostTrackerAPI.Repository.IRepository;
using CostTrackerAPI.DTO.Categories;

namespace CostTrackerAPI.Services
{
    public class SubscriptionService : ISubscriptionService
    {

        private readonly ISubscriptionRepository _subscriptionRepository;
        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository    ;
        }



        public async Task<SubscriptionDTO> CreateSubscriptionAsync(CreateSubscriptionDTO subscription)
        {
            var newSubscription = new Subscription
            {
                UserId = subscription.UserId,
                CompanyName = subscription.CompanyName,
                Cost = subscription.Cost,
                SubscriptionCategory = subscription.SubscriptionCategory
            };

            var createdSubscription = await _subscriptionRepository.CreateSubscription(newSubscription);

            

            var createdDto = MapToSubscriptionDTO(createdSubscription);

            return createdDto;
        }

        public async Task<bool> DeleteSubscriptionAsync(int id)
        {
            return await _subscriptionRepository.DeleteSubscription(id);
        }

        public async Task<List<SubscriptionDTO>> GetAllSubscriptionsAsync(int userId)
        {
            var result = await _subscriptionRepository.GetUserSubscriptions(userId);

            var subscriptionDTOs = result.Select(subscription => new SubscriptionDTO
            {
                Id = subscription.Id,
                userId = subscription.UserId,
                CompanyName = subscription.CompanyName,
                Cost = subscription.Cost,
                SubscriptionCategory = new CategoryDTO
                {
                    CategoryId = subscription.SubscriptionCategory.Id,
                    CategoryName = subscription.SubscriptionCategory.Name
                }
            }).ToList();

            return subscriptionDTOs;
        }


        public async Task<SubscriptionDTO> GetSubscriptionByIdAsync(int id)
        {
            var result = await _subscriptionRepository.GetSubscriptionById(id);

            var subscriptionDTO = MapToSubscriptionDTO(result);

            return subscriptionDTO;
        }

        public async Task<bool> UpdateSubscriptionAsync(int id, SubscriptionDTO subscription)
        {
            var result = await _subscriptionRepository.UpdateSubscription(MapToSubscription(subscription));
            return result;
        }

        // Below are helper methods to map between Subscription and SubscriptionDTO
        private SubscriptionDTO MapToSubscriptionDTO(Subscription subscription)
        {
            return new SubscriptionDTO
            {
                Id = subscription.Id,
                userId = subscription.UserId,
                CompanyName = subscription.CompanyName,
                Cost = subscription.Cost,
                SubscriptionCategory = new CategoryDTO
                {
                    CategoryId = subscription.SubscriptionCategory.Id,
                    CategoryName = subscription.SubscriptionCategory.Name
                }
            };
        }

        private Subscription MapToSubscription(SubscriptionDTO subscriptionDTO)
        {
            return new Subscription
            {
                Id = subscriptionDTO.Id,
                UserId = subscriptionDTO.userId,
                CompanyName = subscriptionDTO.CompanyName,
                Cost = subscriptionDTO.Cost,
                SubscriptionCategory = new Category
                {
                    Id = subscriptionDTO.SubscriptionCategory.CategoryId,
                    Name = subscriptionDTO.SubscriptionCategory.CategoryName
                }
            };
        }
    }
}
