namespace CostTrackerAPI.DTO.CostHistories
{
    public class CreateCostHistoryDTO
    {
        public int UserId { get; set; }
        public DateTime Created { get; set; }
        public int TotalCost { get; set; }
    }
}
