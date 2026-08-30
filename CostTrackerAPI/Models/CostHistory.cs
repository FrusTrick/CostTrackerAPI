namespace CostTrackerAPI.Models
{
    public class CostHistory
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int TotalCost { get; set; }
    }
}
