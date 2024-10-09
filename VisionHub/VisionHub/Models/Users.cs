using System;

namespace VisionHub.Models
{
    public class Users : BaseModel
    {
        private string _name;
        private string _username;
        private string _email;
        private string _password;
        private string _passwordHash;
        private string? _biography;
        private DateTime _birthDate;
        private DateTime _registerDate = DateTime.Now;

        public string Name
        {
            get => _name;
            set => _name = value;
        }

        public string UserName
        {
            get => _username;
            set => _username = value;
        }

        public string Email
        {
            get => _email;
            set => _email = value;
        }

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        public string PasswordHash
        {
            get => _passwordHash;
            set => _passwordHash = value;
        }

        public string? Biography
        {
            get => _biography;
            set => _biography = value;
        }

        public DateTime BirthDate
        {
            get => _birthDate;
            set => _birthDate = value;
        }

        public DateTime RegisterDate
        {
            get => _registerDate;
            private set => _registerDate = value;
        }

        public Users(int id, string username, string name, string email, string password, string passwordHash, string? biography, DateTime birthdate, string connectionString) : base(id, connectionString)
        {
            UserName = username;
            Name = name;
            Email = email;
            Password = password;
            PasswordHash = passwordHash;
            Biography = biography;
            BirthDate = birthdate;
        }

        public Users()
        {
            
        }
    }
}