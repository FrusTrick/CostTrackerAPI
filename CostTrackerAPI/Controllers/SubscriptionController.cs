using CostTrackerAPI.DTO.Subscriptions;
using CostTrackerAPI.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace CostTrackerAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;
        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }

        [HttpPost]
        public async Task<ActionResult<SubscriptionDTO>> CreateSubscription(CreateSubscriptionDTO subscriptionDto)
        {
            var subscription = await _subscriptionService.CreateSubscriptionAsync(subscriptionDto);
            return Ok(subscription);
        }

        [HttpGet]
        public async Task<ActionResult<SubscriptionDTO>> GetSingleSubscription(int id)
        {
            var subscription = await _subscriptionService.GetSubscriptionByIdAsync(id);
            return Ok(subscription);
        }

        [HttpGet]
        [Route("{userId:int}")]
        public async Task<ActionResult<SubscriptionDTO>> ListSubscriptions(int userId)
        {
            var subscriptions = await _subscriptionService.GetAllSubscriptionsAsync(userId);
            return Ok(subscriptions);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<bool>> UpdateSubscription(int id, SubscriptionDTO subscriptionDto)
        {
            var result = await _subscriptionService.UpdateSubscriptionAsync(id, subscriptionDto);
            if (!result)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<bool>> DeleteSubscription(int id)
        {
            var result = await _subscriptionService.DeleteSubscriptionAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
