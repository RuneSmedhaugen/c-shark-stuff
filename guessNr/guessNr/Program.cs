


bool playGame = true;

while (playGame)
{
    Random random = new Random();
    int randomNumber = random.Next(1, 101);
    Console.WriteLine("Hello! Guess a number between 1 and 100");

    bool guessedCorrect = false;

    while (!guessedCorrect)
    {
        var answer = Console.ReadLine();

        if (!int.TryParse(answer, out int guess))
        {
            Console.WriteLine("enter a valid number.");
        }

        if (guess > randomNumber)
        {
            Console.WriteLine("Too high!");
        }
        else if (guess < randomNumber)
        {
            Console.WriteLine("Too low!");
        }
        else
        {
            Console.WriteLine("Correct!");
            guessedCorrect = true;
        }
    }

    Console.WriteLine("Would you like to play again? (yes/no)");
    var playAgain = Console.ReadLine();

    if (playAgain == "yes")
    {
        guessedCorrect = false;
    }
    else
    {
        Console.WriteLine("ok asshole.");
        break;

    }
}


