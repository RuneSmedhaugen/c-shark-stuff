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
            tankWidth = Console.WindowWidth - 5;
            tankHeight = Console.WindowHeight - 5;

            tankWidth = Math.Max(tankWidth, 20);
            tankHeight = Math.Max(tankHeight, 10);

            startX = 2;
            startY = 2;

            fish.X = rnd.Next(1, tankWidth - 2);
            fish.Y = rnd.Next(1, tankHeight - 2);
            fishInTank.Add(fish);
        }

        //Fant ikke ut hvordan jeg kan få fisketanken til å ikke blinke som faen så denne brukes ikke akkurat nå
        public void PrintFishTank()
        {
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;

            tankWidth = windowWidth - 5; 
            tankHeight = windowHeight - 5;

            tankWidth = Math.Max(tankWidth, 20);
            tankHeight = Math.Max(tankHeight, 10);

            startX = 2;
            startY = 2;

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
                fish.X = Math.Clamp(fish.X, 1, tankWidth - 2);
                fish.Y = Math.Clamp(fish.Y, 1, tankHeight - 2);

                Console.SetCursorPosition(startX + fish.X, startY + fish.Y);
                Console.Write(fish.Draw);
            }
        }

        public void clearFish(int x, int y)
        {
            foreach (var fish in fishInTank)
            {
                Console.SetCursorPosition(startX + fish.X, startY + fish.Y);
                Console.Write(" ");
            }
        }

        public void MoveFish()
        {
            foreach (var fish in fishInTank)
            {
                clearFish(fish.X, fish.Y);

                int move = rnd.Next(0, 4);
                switch (move)
                {
                    case 0:
                        fish.Y = Math.Clamp(fish.Y - 1, 1, tankHeight - 2);
                        break;
                    case 1:
                        fish.Y = Math.Clamp(fish.Y + 1, 1, tankHeight - 2);
                        break;
                    case 2:
                        fish.X = Math.Clamp(fish.X - 1, 1, tankWidth - 2);
                        break;
                    case 3:
                        fish.X = Math.Clamp(fish.X + 1, 1, tankWidth - 2);
                        break;
                }
            }
                
            
        }

        public void RunFishtankSimulation()
        {
            while (true)
            {
                Console.Clear();
                MoveFish();
                DisplayFish();
                Thread.Sleep(200);
            }
        }
    }
}
