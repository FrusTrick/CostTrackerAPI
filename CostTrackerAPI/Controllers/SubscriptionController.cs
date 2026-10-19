using CostTrackerAPI.DTO.Subscriptions;
using CostTrackerAPI.Services.IService;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<SubscriptionDTO>> CreateSubscription(CreateSubscriptionDTO subscriptionDto)
        {
            var subscription = await _subscriptionService.CreateSubscriptionAsync(subscriptionDto);
            return Ok(subscription);
        }

        [Authorize]
        [HttpGet]
        [Route("{subscriptionId:int}")]
        public async Task<ActionResult<SubscriptionDTO>> GetSingleSubscription(int subscriptionId)
        {
            var subscription = await _subscriptionService.GetSubscriptionByIdAsync(subscriptionId);
            return Ok(subscription);
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<SubscriptionDTO>>> ListUserSubscriptions(int userId)
        {
            var subscriptions = await _subscriptionService.GetAllSubscriptionsAsync(userId);
            return Ok(subscriptions);
        }

        [Authorize]
        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<bool>> UpdateUserSubscription(SubscriptionDTO subscriptionDto)
        {
            var result = await _subscriptionService.UpdateSubscriptionAsync(subscriptionDto);
            if (!result)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [Authorize]
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
