

using ClickerGame;
using System.Runtime.ConstrainedExecution;

namespace ClickerGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new ClickerGame();
            var commands = new CommandSet(game);
            while (true)
            {
                Console.Clear();
                Console.WriteLine(@$"Kommandoer:
                     SPACE = klikk(og få poeng)
                     K = kjøp oppgradering - øker poeng per klikk. Koster {game._upgradecost} poeng.
                     S = kjøp superoppgradering - Øker antall poeng per klikk for oppgradering. Koster 100 poeng.
                     X = avslutt applikasjonen");
                Console.WriteLine($"Du har {game.Points} poeng.");
                Console.WriteLine("Trykk tast for ønsket kommando.");
                var command = Console.ReadKey().KeyChar;

                commands.Run(command);
            }
        }
    }
}

