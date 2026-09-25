using CostTrackerAPI.Models;
using CostTrackerAPI.DTO.CostHistories;

namespace CostTrackerAPI.Services.IService
{
    public interface ICostHistoryService
    {
        Task<List<CostHistoryDTO>> GetAllCostHistoriesAsync();
        Task<CostHistoryDTO> GetCostHistoryByIdAsync(int id);
        Task<CostHistoryDTO> CreateCostHistoryAsync(CreateCostHistoryDTO costHistory);
        Task<CostHistoryDTO> UpdateCostHistoryAsync(int id, CostHistoryDTO costHistory);
        Task<bool> DeleteCostHistoryAsync(int id);
    }
}
