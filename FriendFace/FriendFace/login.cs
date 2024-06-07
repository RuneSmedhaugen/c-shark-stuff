using System;
using System.Collections.Generic;

namespace FriendFace
{
    internal class login
    {
        public List<Users> userList = new List<Users>
        {
            new Users("Bjarne", "bjarne@get.no", "hehexd", 13376969, 42, "male", "14 August"),
            new Users("Kåre", "kaare@get.no", "hehexd", 69691337, 69, "male", "09 February"),
            new Users("Gunn", "Gunn@get.no", "hehexd", 42042069, 19, "female", "31 October"),
            new Users("Andre", "Andre@get.no", "drøbaksuger", 69696969, 24, "whoKnows", "kekw nobody knows")
        };

        public bool LoggedIn;
        public Users CurrentUser;

        public login()
        {
            if (!LoggedIn)
            {
                checkLogin();
            }
        }

        private void checkLogin()
        {
            Console.WriteLine($@"Velkommen til FriendFace. Vennligst logg inn.");
            Console.WriteLine("Navn:");
            string Username = Console.ReadLine();

            Console.WriteLine("Passord:");
            string loginPassword = Console.ReadLine();

            foreach (var user in userList)
            {
                if (user.Name.Equals(Username, StringComparison.OrdinalIgnoreCase) && user.Password == loginPassword)
                {
                    LoggedIn = true;
                    CurrentUser = user;
                    Console.WriteLine("Innlogging vellykket!");
                    return;
                }
            }
            Console.WriteLine("Ugyldig navn eller passord.");
        }
    }
}