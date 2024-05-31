using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Chatbot
    {
        private string tekst1 = "Hva heter du?";
        private string tekst2 = "hvordan har du det";
        private string tekst3 = "hva driver du med idag";

        private List<string> randomResponses = new List<string>
        {
            "Så interessant", 
            "Fortell meg mer!",
            "Så kjedelig du er....",
            "PAKKIS!",
            "Rune er KUL!",
            "Fatos er kulere!",
            "Jeg liker navnet du ga meg :)",
            "hahahahahahahahahaha!",
        };

        private Random random = new Random();

        public void Chat()
        {
            Console.WriteLine("hei der, hva heter jeg?");
            string botname = Console.ReadLine();

            Console.WriteLine($"jeg heter nå {botname}");

            Console.WriteLine(tekst1);
            string answerOne = Console.ReadLine();
            Console.WriteLine($"Så fint navn du har, {answerOne}!");
            Console.WriteLine(tekst2);
            string answerTwo = Console.ReadLine();
            Console.WriteLine($"Hva mener du med {answerTwo}?");
            string answerThree = Console.ReadLine();
            Console.WriteLine($"Okey. {answerThree} er en helt gyldig grunn.");
            Console.WriteLine(tekst3);
            string answerFour = Console.ReadLine();
            Console.WriteLine($"Så kult pakkis!");

            string userInput;
            do
            {
                Console.WriteLine("skrive noe funny eller skriv exit for å avslutte :)");
                userInput = Console.ReadLine();

                if (userInput.ToLower() != "exit")
                {
                    string randomResponse = GetRandomResponses();
                    Console.WriteLine(randomResponse);
                }

            } while (userInput.ToLower() != "exit");

            Console.WriteLine("prækas");
        }



        private string GetRandomResponses()
            {
                int index = random.Next(randomResponses.Count);
                return randomResponses[index];
            }

    }
        
}




