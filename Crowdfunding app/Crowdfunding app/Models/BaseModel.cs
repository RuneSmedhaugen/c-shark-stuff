namespace Crowdfunding_app.Models
{
    public class BaseModel
    {
        public int ID { get; set; }       // Common ID for all models
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Auto-set when created
    }
}
