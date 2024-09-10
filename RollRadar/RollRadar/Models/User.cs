namespace RollRadar.Models
{
    public class User : Inherit
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int? Age { get; set; }
        public string Hand { get; set; }

        public User(string name, string email, string passwordHash, int? age, string hand, string image, string comments) : base(name, image, comments)
        {
            Email = email;
            PasswordHash = passwordHash;
            Age = age;
            Hand = hand;
        }
    }
}

