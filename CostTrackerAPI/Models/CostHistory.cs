using System.ComponentModel.DataAnnotations;

namespace CostTrackerAPI.Models
{
    public class CostHistory
    {
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime DateRecorded { get; set; }
        [Required]
        public int TotalCost { get; set; }
    }
}
