using CostTrackerAPI.Data;
using CostTrackerAPI.Models;
using CostTrackerAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace CostTrackerAPI.Repository
{
    public class CostHistoryRepository : ICostHistoryRepository
    {
        private readonly CostTrackerAPIDBContext context;

        public CostHistoryRepository(CostTrackerAPIDBContext _context)
        {
            context = _context;
        }

        public async Task<CostHistory> CreateCostHistory(CostHistory costHistory)
        {
            context.CostHistories.Add(costHistory);
            await context.SaveChangesAsync();
            return costHistory;
        }

        public async Task<bool> DeleteCostHistory(int id)
        {
            var rowsAffected = await context.CostHistories.Where(ch => ch.Id == id).ExecuteDeleteAsync();
            if(rowsAffected > 0)
            {
                return true;
            }

            return false;
        }

        public async Task<CostHistory> GetCostHistoryById(int id)
        {
            var costHistory = await context.CostHistories.FirstOrDefaultAsync(ch => ch.Id == id);
            return costHistory;
        }

        public async Task<List<CostHistory>> GetUserCostHistory(int userId)
        {
            var costHistories = await context.CostHistories
                .Where(ch => ch.UserId == userId)
                .ToListAsync();
            if (costHistories == null || costHistories.Count == 0)
            {
                return new List<CostHistory>();
            }
            return costHistories;
        }

        public async Task<bool> UpdateCostHistory(CostHistory costHistory)
        {
            context.CostHistories.Update(costHistory);
            var result = await context.SaveChangesAsync();

            if(result > 0)
            {
                return true;
            }
            return false;
        }
    }
}
