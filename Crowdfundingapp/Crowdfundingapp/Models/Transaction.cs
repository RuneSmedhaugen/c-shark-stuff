namespace Crowdfunding_app.Models
{
    public class Transaction : BaseModel
    {
        public int DonationID { get; set; }   // FK to the Donation table
        public string PaymentMethod { get; set; }  // e.g., PayPal, Venmo
        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; }    // e.g., Success, Failed
    }

}
