using System.Security.Cryptography;

Random rand = new Random();


Console.WriteLine("Hello! What's your name?");
var name = Console.ReadLine();
Console.WriteLine($"Nice to meet you, {name}. This is an automatic hobby selector, proceed to do what you're told.");

while (true)
{
    Console.WriteLine(
        " Would you like to get a hobby? (yes/no)");
    var answer = Console.ReadLine();

    if (answer == "yes")
    {
        var randomNumber = rand.Next(0, 7);
        if (randomNumber == 0)
        {
            Console.WriteLine($"{name} you are now a gamer! Have fun ragequitting :)");
        }
        else if (randomNumber == 1)
        {
            Console.WriteLine($"You are now a cyclist, {name}! Make sure to slow down all the fucking traffic.");
        }
        else if (randomNumber == 2)
        {
            Console.WriteLine(
                $"Congratulations! You are now a bowler! Headlines in every newspaper will be <{name} threw his ball in the gutter for the 100th time in a row!> ");
        }
        else if (randomNumber == 3)
        {
            Console.WriteLine($"Welp, {name}, you are now a hunter. Make sure to practice a lot!");
        }
        else if (randomNumber == 4)
        {
            Console.WriteLine($"LOL {name} is now an asskisser! Hahahahahahahahaha");
        }
        else if (randomNumber == 5)
        {
            Console.WriteLine($"kekW {name} is now a thief! We might as well retire 90% of the policeforce xD");
        }
        else if (randomNumber == 6)
        {
            Console.WriteLine($"{name}, you're now a fisherman. Don't get eaten youself!");
        }

    }
    else if (answer == "no")
    {
        Console.WriteLine("Well fuck you then.");
        break;
    }
    else
    {
        Console.WriteLine("please answer with yes or no");
    }
}