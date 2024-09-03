using RollRadar.Models;
using RollRadar.Services;

namespace RollRadar
{
    public class Run
    {
        //Dette er bare en test for å øve på å legge ting inn i databasen, tror jeg fikk det til
        public void CreateUser(UserService userService)
        {
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your age: ");
            string ageInput = Console.ReadLine();
            int? age = string.IsNullOrEmpty(ageInput) ? (int?)null : int.Parse(ageInput);

            Console.Write("Enter your hand (Lefty/Righty): ");
            string hand = Console.ReadLine();

            Console.Write("Enter the path to your profile picture (optional): ");
            string profilePic = Console.ReadLine();


            User newUser = new User(email, password, name, age, hand,
                string.IsNullOrEmpty(profilePic) ? null : profilePic);

            userService.AddUser(newUser);
        }
    }
}
