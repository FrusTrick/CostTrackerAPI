using System.ComponentModel.DataAnnotations;

namespace CostTrackerAPI.DTO.CostHistories
{
    public class CreateCostHistoryDTO
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Date recorded is required")]
        public DateTime Created { get; set; }
        [Required]
        public int TotalCost { get; set; }
    }
}
