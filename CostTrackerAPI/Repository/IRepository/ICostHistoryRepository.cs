using CostTrackerAPI.Models;

namespace CostTrackerAPI.Repository.IRepository
{
    public interface ICostHistoryRepository
    {
        Task<List<CostHistory>> GetUserCostHistory(int userId);
        Task<CostHistory> GetCostHistoryById(int id);
        Task<CostHistory> CreateCostHistory(CostHistory costHistory);
        Task<bool> UpdateCostHistory(CostHistory costHistory);
        Task<bool> DeleteCostHistory(int id);

    }
}
