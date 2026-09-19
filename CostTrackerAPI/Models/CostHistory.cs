namespace CostTrackerAPI.Models
{
    public class CostHistory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateRecorded { get; set; }
        public int TotalCost { get; set; }
    }
}
