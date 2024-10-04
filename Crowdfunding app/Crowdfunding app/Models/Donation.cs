namespace Crowdfunding_app.Models
{
    public class Donation : BaseModel
    {
        public int CampaignID { get; set; }   // FK to the Campaign table
        public string DonorName { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateDonated { get; set; } = DateTime.UtcNow;
    }

}
