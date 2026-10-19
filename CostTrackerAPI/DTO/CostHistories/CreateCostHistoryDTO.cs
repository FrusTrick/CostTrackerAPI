using System.ComponentModel.DataAnnotations;

namespace CostTrackerAPI.DTO.CostHistories
{
    public class CreateCostHistoryDTO
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Date recorded is required")]
        public DateTime DateRecorded { get; set; }
        [Required(ErrorMessage = "Total cost is required")]
        public int TotalCost { get; set; }
    }
}
