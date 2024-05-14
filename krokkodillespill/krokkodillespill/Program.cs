

using System.ComponentModel.Design;

Console.WriteLine("Hello, what is your name?");

var name = Console.ReadLine();
Console.WriteLine($"Nice to meet you, {name} and welcome to the crocodile game.");
Console.WriteLine("how to play: answer with either >, < og =. Write anything else to exit.");
bool gaming = true;

Random random = new Random();
int points = 0;

while (gaming)
{

    int min = 1;
    int max = 11;
    int randomNumber = random.Next(min, max + 1);
    int randomNumber2 = random.Next(min, max + 1);
    Console.WriteLine($"{randomNumber}_{randomNumber2}");
    var answer = Console.ReadLine();

    if (randomNumber > randomNumber2)
    {
        if (answer == ">")
        {
            points++;
            Console.WriteLine($"Correct! Score: {points}");
        }
        else if (answer == "<")
        {
            points--;
            Console.WriteLine($"Wrong! Score: {points} ");
        }
        else if (answer == "=")
        {
            points--;
            Console.WriteLine($"Wrong! Score: {points} ");
        }
        else
        {
            Console.WriteLine("Goodbye");
            gaming = false;

        }

    }
    else if (randomNumber < randomNumber2)
    {
        if (answer == "<")
        {
            points++;
            Console.WriteLine($"Correct! Score: {points}");
        }
        else if (answer == ">")
        {
            points--;
            Console.WriteLine($"Wrong! Score: {points} ");
        }
        else if (answer == "=")
        {
            points--;
            Console.WriteLine($"Wrong! Score: {points} ");
        }
        else
        {
            Console.WriteLine("Goodbye");
            gaming = false;

        }

    }

    if (randomNumber == randomNumber2)
    {
        if (answer == "=")
        {
            points++;
            Console.WriteLine($"Correct! Score: {points}");
        }
        else if (answer == "<")
        {
            points--;
            Console.WriteLine($"Wrong! Score: {points} ");
        }
        else if (answer == ">")
        {
            points--;
            Console.WriteLine($"Wrong! Score: {points} ");
        }
        else
        {
            Console.WriteLine("Goodbye");
            gaming = false;
        }
    }
}

        
