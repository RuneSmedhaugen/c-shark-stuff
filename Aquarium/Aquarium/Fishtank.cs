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

        public void MoveFish()
        {
            foreach (var fish in fishInTank)
            {
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

        public async void RunFishtankSimulation()
        {
            while (true)
            {
                Console.Clear();
                MoveFish();
                DisplayFish();
               await Task.Delay(200);
            }
        }
    }
}
