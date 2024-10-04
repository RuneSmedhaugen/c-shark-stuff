namespace Crowdfunding_app.Models
{
    public class User : BaseModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
    }
}
