using CostTrackerAPI.Models;
using CostTrackerAPI.DTO.CostHistories;

namespace CostTrackerAPI.Services.IService
{
    public interface ICostHistoryService
    {
        Task<List<CostHistoryDTO>> GetAllCostHistoriesAsync(int userId);
        Task<CostHistoryDTO> GetCostHistoryByIdAsync(int id);
        Task<CostHistoryDTO> CreateCostHistoryAsync(CreateCostHistoryDTO costHistory);
        Task<bool> UpdateCostHistoryAsync(int id, CostHistoryDTO costHistory);
        Task<bool> DeleteCostHistoryAsync(int id);
    }
}
