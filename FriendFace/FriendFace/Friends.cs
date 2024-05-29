using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendFace
{
    internal class Friends
    {
        private login _loginInstance;


        public Friends(login loginInstance)
        {
            _loginInstance = loginInstance;
        }

        public void DisplayAllUsers()
        {
            foreach (var user in _loginInstance.userList)
            {
                Console.WriteLine(user.Name);
            }
        }

        public void AddFriend(string friendName)
        {
            var friend =
                _loginInstance.userList.FirstOrDefault(u =>
                    u.Name.Equals(friendName, StringComparison.OrdinalIgnoreCase));
            if (friend != null)
            {
                _loginInstance.CurrentUser.AddFriend(friend);
            }
            else
            {
                Console.WriteLine("bruker ikke funnet.");
            }
        }


        public void RemoveFriend(string friendName)
        {
            var friend = _loginInstance.CurrentUser.FriendList.FirstOrDefault(u =>
                u.Name.Equals(friendName, StringComparison.OrdinalIgnoreCase));
            if (friend != null)
            {
                _loginInstance.CurrentUser.RemoveFriend(friend);
            }
            else
            {
                Console.WriteLine("Venn ikke funnet");
            }
        }

        public void ViewFriends()
        {
            _loginInstance.CurrentUser.ShowFriends();
        }

        public void ViewFriendInfo(string friendName)
        {
            var friend = _loginInstance.CurrentUser.FriendList.FirstOrDefault(u =>
                u.Name.Equals(friendName, StringComparison.OrdinalIgnoreCase));
            if (friend != null)
            {
                Console.WriteLine($"Navn: {friend.Name}");
                Console.WriteLine($"Email: {friend.Email}");
                Console.WriteLine($"Telefon: {friend.Phone}");
                Console.WriteLine($"Alder: {friend.Age}");
                Console.WriteLine($"Kjønn: {friend.Gender}");
                Console.WriteLine($"Bursdag: {friend.Birthday}");
            }
            else
            {
                Console.WriteLine("Venn ikke funnet.");
            }
        }
    }
}
