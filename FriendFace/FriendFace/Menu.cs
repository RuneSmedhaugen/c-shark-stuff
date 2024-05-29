using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendFace
{
    internal class Menu
    {
        private login loginInstance;
        private Friends friendsInstance;

        public Menu(login loginInstance)
        {
            this.loginInstance = loginInstance;
            this.friendsInstance = new Friends(loginInstance);
        }

        public void ShowMenu()
        {
            while (loginInstance.LoggedIn)
            {

                if (loginInstance.LoggedIn)
                {
                    Console.WriteLine(@$"Du er nå logget inn som {loginInstance.CurrentUser.Name}.
Her er dine valg:
1: Legge til venner
2: Fjerne venner
3: Se venner
4: Venneliste");
                    string loginChoice = Console.ReadLine();

                    switch (loginChoice)
                    {
                        case "1":
                            Console.WriteLine("Skriv inn navnet på vennen du vil legge til:");
                            friendsInstance.DisplayAllUsers();
                            string addFriendName = Console.ReadLine();
                            friendsInstance.AddFriend(addFriendName);
                            break;

                        case "2":
                            Console.WriteLine("Dine venner:");
                            loginInstance.CurrentUser.ShowFriends();
                            Console.WriteLine("Skriv inn navnet på vennen du vil fjerne:");
                            string removeFriendName = Console.ReadLine();
                            friendsInstance.RemoveFriend(removeFriendName);
                            break;

                        case "3":
                            friendsInstance.ViewFriends();
                            break;

                        case "4":
                            Console.WriteLine("Skriv inn navnet på vennen du vil se info om:");
                            string friendInfoName = Console.ReadLine();
                            friendsInstance.ViewFriendInfo(friendInfoName);
                            break;


                        default:
                            Console.WriteLine("Ugyldig valg. Vennligst prøv igjen.");
                            break;
                    }
                }
            }

        }
    }
}
