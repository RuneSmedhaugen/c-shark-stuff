using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium
{
    internal class Fishtank
    {
        private int tankWidth;
        private int tankHeight;
        private int startX;
        private int startY;
        private List<Fish> fishInTank = new List<Fish>();
        private Random rnd = new Random();

        public Fishtank()
        {
            Console.SetWindowSize(100,50);
            Console.SetBufferSize(100,50);
        }

        public void AddFish(Fish fish)
        {
            fish.X = rnd.Next(1, tankWidth - 2);
            fish.Y = rnd.Next(1, tankHeight - 2);
            fishInTank.Add(fish);
        }


        public void PrintFishTank()
        {
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;

            tankWidth = windowWidth - 5; // Give some space for the console edge
            tankHeight = windowHeight - 5;

            tankWidth = Math.Max(tankWidth, 20);
            tankHeight = Math.Max(tankHeight, 10);

            startX = 2;
            startY = 2;

            // Draw the tank borders
            for (int i = 0; i < tankHeight; i++)
            {
                Console.SetCursorPosition(startX, startY + i);
                for (int j = 0; j < tankWidth; j++)
                {
                    if (i == 0 || i == tankHeight - 1 || j == 0 || j == tankWidth - 1)
                    {
                        Console.Write("█");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
            }
        }

        public void DisplayFish()
        {
            foreach (var fish in fishInTank)
            {
                fish.X = Math.Clamp(fish.X, 1, tankWidth - 1);
                fish.Y = Math.Clamp(fish.Y, 1, tankHeight - 1);

                Console.SetCursorPosition(startX + fish.X, startY + fish.Y);
                Console.Write(fish.Draw);
            }
        }
    }
}
