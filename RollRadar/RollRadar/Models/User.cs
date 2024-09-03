namespace RollRadar.Models
{
    public class User
    {
        private int _id;
        private string _email;
        private string _passwordHash;
        private string _name;
        private int? _age;
        private string _hand;
        private string _profilepic;

        public int Id
        {
            get => _id;
            private set => _id = value;
        }

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

        public string Name
        {
            get => _name;
            set => _name = value;
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

        public string Profilepic
        {
            get => _profilepic;
            set => _profilepic = value;
        }

        public User(int id, string email, string passwordHash, string name, int? age, string hand, string profilePic)
        {
            _id = id;
            _email = email;
            _passwordHash = passwordHash;
            _name = name;
            _age = age;
            _hand = hand;
            _profilepic = profilePic;
        }

    }
}

