using System;
using System.Collections.Generic;
using System.Linq;
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

        public Fishtank()
        {
            Console.SetWindowSize(100,50);
            Console.SetBufferSize(100,50);
        }

        public void AddFish(Fish fish)
        {
            Random rnd = new Random();
            int minX = 1;
            int maxX = Math.Max(startX + tankWidth - 2, minX + 1);
            int minY = 1;
            int maxY = Math.Max(+tankHeight - 2, minY + 1);

            fish.X = rnd.Next(minX, maxX);
            fish.Y = rnd.Next(minY, maxY);

            
            fishInTank.Add(fish);
        }


        public void PrintFishTank()
        {

            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;

            
            int tankWidth = windowWidth / 3; 
            int tankHeight = windowHeight / 3; 

            
            tankWidth = Math.Max(tankWidth, 99);
            tankHeight = Math.Max(tankHeight, 48);


            int startX = windowWidth - tankWidth - 1;
            int startY = 0;

            Console.Clear();
           
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
                Console.SetCursorPosition(startX + fish.X, startY + fish.Y);
                Console.Write(fish.Draw);
            }
        }
    }
}
