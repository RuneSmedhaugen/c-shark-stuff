namespace RollRadar.Models
{
    public class User : Inherit
    {
        private string _email;
        private string _passwordHash;
        private int? _age;
        private string _hand;


        public string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentNullException("Email can't be empty");
                _email = value;
            }
        }

        public string PasswordHash
        {
            get => _passwordHash;
            set => _passwordHash = value;
        }


        public int? Age
        {
            get => _age;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Age can't be negative lol.");
                _age = value;
            }
        }

        public string Hand
        {
            get => _hand;
            set
            {
                if (value != "Lefty" && value != "Righty")
                    throw new ArgumentOutOfRangeException("Hand must be 'Lefty' or 'Righty'");
                _hand = value;
            }
        }

        public User(string name, string email, string passwordHash, int? age, string hand, string image, string comments) : base(name, image, comments)
        {
            _email = email;
            _passwordHash = passwordHash;
            _age = age;
            _hand = hand;
        }




    }
}

