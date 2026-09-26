using CostTrackerAPI.DTO.CostHistories;
using CostTrackerAPI.Models;
using CostTrackerAPI.Repository.IRepository;
using CostTrackerAPI.Services.IService;

namespace CostTrackerAPI.Services
{
    public class CostHistoryService : ICostHistoryService
    {

        private readonly ICostHistoryRepository _costHistoryRepository;
        public CostHistoryService(ICostHistoryRepository costHistoryRepository)
        {
            _costHistoryRepository = costHistoryRepository;
        }


        public async Task<CostHistoryDTO> CreateCostHistoryAsync(CreateCostHistoryDTO costHistory)
        {
            var mappedCostHistory = new CostHistory
            {
                UserId = costHistory.UserId,
                DateRecorded = costHistory.Created,
                TotalCost = costHistory.TotalCost
            };

            var result = await _costHistoryRepository.CreateCostHistory(mappedCostHistory);
            return MapToCostHistoryDTO(result);
        }

        public async Task<bool> DeleteCostHistoryAsync(int id)
        {
            bool result = await _costHistoryRepository.DeleteCostHistory(id);

            return result;
        }

        public async Task<List<CostHistoryDTO>> GetAllCostHistoriesAsync(int userId)
        {
            var costHistories = await _costHistoryRepository.GetUserCostHistory(userId);
            return costHistories.Select(MapToCostHistoryDTO).ToList();
        }

        public async Task<CostHistoryDTO> GetCostHistoryByIdAsync(int id)
        {
            var costHistory = await _costHistoryRepository.GetCostHistoryById(id);
            return MapToCostHistoryDTO(costHistory);
        }

        public async Task<bool> UpdateCostHistoryAsync(int id, CostHistoryDTO costHistory)
        {
            var mappedCostHistory = MapToCostHistory(costHistory);
            var result = await _costHistoryRepository.UpdateCostHistory(mappedCostHistory);


            return result;
        }

        // Private helper method to map CostHistory to CostHistoryDTO and vice versa.
        private CostHistoryDTO MapToCostHistoryDTO(CostHistory costHistory)
        {
            return new CostHistoryDTO
            {
                Id = costHistory.Id,
                UserId = costHistory.UserId,
                DateRecorded = costHistory.DateRecorded,
                TotalCost = costHistory.TotalCost
            };
        }

        private CostHistory MapToCostHistory(CostHistoryDTO costHistoryDTO)
        {
            return new CostHistory
            {
                Id = costHistoryDTO.Id,
                UserId = costHistoryDTO.UserId,
                DateRecorded = costHistoryDTO.DateRecorded,
                TotalCost = costHistoryDTO.TotalCost
            };


        }

    }
}
