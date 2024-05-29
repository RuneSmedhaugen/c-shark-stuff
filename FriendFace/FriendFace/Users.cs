using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendFace
{
    internal class Users
    {
        private string _name { get; }
        private string _email { get; }
        private string _password { get; }
        private int _phone { get; }
        private int _age { get; }
        private string _gender { get; }
        private string _birthday { get; }

        public List<Users> FriendList { get; }

        public string Name { get { return _name; } }
        public string Email { get { return _email; } }
        public string Password { get { return _password; } }
        public int Phone { get { return _phone; } }
        public int Age { get { return _age; } }
        public string Gender { get { return _gender; } }
        public string Birthday { get { return _birthday; } }

        public Users(string name, string email, string password, int phone, int age, string gender, string birthday)
        {
             _name = name;
            _email = email;
            _password = password;
            _phone = phone;
            _age = age;
            _gender = gender;
            _birthday = birthday;
            FriendList = new List<Users>();
        }

        public void AddFriend(Users friend)
        {
            if (!FriendList.Contains(friend))
            {
                FriendList.Add(friend);
                Console.WriteLine($"{friend.Name} er nå vennen din.");
            }
            else
            {
                Console.WriteLine($"{friend.Name} er allerede i vennelisten din.");
            }
        }

        public void RemoveFriend(Users friend)
        {
            if (FriendList.Contains(friend))
            {
                FriendList.Remove(friend);
                Console.WriteLine($"{friend.Name} har blitt fjernet fra vennelisten.");
            }
            else
            {
                Console.WriteLine($"{friend.Name} er allerede ikke din venn.");
            }
        }

        public void ShowFriends()
        {
            Console.WriteLine("Dine venner:");
            foreach (var friend in FriendList)
            {
                Console.WriteLine(friend.Name);
            }
        }
    }
}
