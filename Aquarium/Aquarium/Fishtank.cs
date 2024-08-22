using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium
{
    internal class Fishtank
    {
        public void PrintFishTank()
        {

            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;

            
            int tankWidth = windowWidth / 2; 
            int tankHeight = windowHeight / 2; 

            
            tankWidth = Math.Max(tankWidth, 20);
            tankHeight = Math.Max(tankHeight, 10); 

            
            int startX = (windowWidth - tankWidth) / 2;
            int startY = (windowHeight - tankHeight) / 2;

           
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
    }
}
