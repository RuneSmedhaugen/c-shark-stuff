using System;

namespace FriendFace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            login loginInstance = new login();

            if (loginInstance.LoggedIn)
            {
                Menu menuInstance = new Menu(loginInstance);
                menuInstance.ShowMenu();
            }
            else
            {
                Console.WriteLine("Innlogging mislyktes.");
            }
        }
    }
}