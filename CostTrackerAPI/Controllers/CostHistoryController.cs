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
        [Route ("{costHistoryId:int}")]
        public async Task<ActionResult<CostHistoryDTO>> GetSingleCostHistory(int costHistoryId)
        {
            var costHistory = await _costHistoryService.GetCostHistoryByIdAsync(costHistoryId);
            return Ok(costHistory);
        }

        [HttpGet]
        public async Task<ActionResult<List<CostHistoryDTO>>> ListCostHistories(int userId)
        {
            var costHistories = await _costHistoryService.GetAllCostHistoriesAsync(userId);
            return Ok(costHistories);
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdateCostHistory(CostHistoryDTO costHistoryDto)
        {
            int id = costHistoryDto.Id;
            bool result = await _costHistoryService.UpdateCostHistoryAsync(costHistoryDto);
            if (!result)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete]
        [Route("id:int")]
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
