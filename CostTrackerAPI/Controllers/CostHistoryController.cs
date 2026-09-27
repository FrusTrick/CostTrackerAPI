using CostTrackerAPI.DTO.CostHistories;
using CostTrackerAPI.Services.IService;
using Microsoft.AspNetCore.Mvc;

namespace CostTrackerAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CostHistoryController : ControllerBase
    {
        private readonly ICostHistoryService _costHistoryService;
        public CostHistoryController(ICostHistoryService costHistoryService)
        {
            _costHistoryService = costHistoryService;
        }

        [HttpPost]
        public async Task<ActionResult<CostHistoryDTO>> CreateCostHistory(CreateCostHistoryDTO costHistoryDto)
        {
            var costHistory = await _costHistoryService.CreateCostHistoryAsync(costHistoryDto);
            return Ok(costHistory);
        }

        [HttpGet]
        public async Task<ActionResult<CostHistoryDTO>> GetSingleCostHistory(int chId)
        {
            var costHistory = await _costHistoryService.GetCostHistoryByIdAsync(chId);
            return Ok(costHistory);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<CostHistoryDTO>> ListCostHistories(int userId)
        {
            var costHistories = await _costHistoryService.GetAllCostHistoriesAsync(userId);
            return Ok(costHistories);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateCostHistory(int id, CostHistoryDTO costHistoryDto)
        {
            var result = await _costHistoryService.UpdateCostHistoryAsync(id, costHistoryDto);
            if (!result)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteCostHistory(int id)
        {
            var result = await _costHistoryService.DeleteCostHistoryAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
