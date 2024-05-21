using System;

class Program
{
    static void Main()
    {
        bool isGameOver = false;
        int score = 0;
        int birdPositionY = Console.WindowHeight / 2; // Initial bird position

        while (!isGameOver)
        {
            DrawGame(birdPositionY);
            HandleInput(ref birdPositionY);
            UpdateGame(ref isGameOver, ref score);
            Console.Clear(); // Clear console for next frame
        }

        Console.WriteLine($"Game over! Your score: {score}");
        Console.ReadLine(); // Wait for user input before exiting
    }

    static void DrawGame(int birdY)
    {
        Console.SetCursorPosition(0, birdY);
        Console.WriteLine("  _");
        Console.SetCursorPosition(0, birdY + 1);
        Console.WriteLine(" / \\");
    }

    static void HandleInput(ref int birdY)
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Spacebar)
            {
                birdY -= 2; 
            }
        }
    }

    static void UpdateGame(ref bool isGameOver, ref int score)
    {

    }
}