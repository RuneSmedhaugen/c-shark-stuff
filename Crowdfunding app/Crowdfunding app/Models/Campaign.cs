namespace Crowdfunding_app.Models
{
    public class Campaign : BaseModel
    {
        public int UserID { get; set; }   // FK to the User table
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal GoalAmount { get; set; }
        public decimal CurrentAmount { get; set; } = 0;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
