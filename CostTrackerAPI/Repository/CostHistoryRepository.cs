using CostTrackerAPI.Models;
using CostTrackerAPI.Repository.IRepository;

namespace CostTrackerAPI.Repository
{
    public class CostHistoryRepository : ICostHistoryRepository
    {
        public Task<CostHistory> CreateCostHistory(CostHistory costHistory)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteCostHistory(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CostHistory> GetCostHistoryById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<CostHistory>> GetUserCostHistory(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateCostHistory(CostHistory costHistory)
        {
            throw new NotImplementedException();
        }
    }
}
