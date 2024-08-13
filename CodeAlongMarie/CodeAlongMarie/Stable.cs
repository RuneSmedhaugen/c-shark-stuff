using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlongMarie
{
    internal class Stable
    {
        private HorseRace race = new HorseRace();
        
        public void CreateHorse()
        {
            Console.WriteLine("Hello! Name your horse:");
            var input = Console.ReadLine();
            Horses myHorse = new Horses(input, 20);
            while (true)
            { 
                Console.WriteLine($@"What would you like to do?
1: Feed {myHorse._name}
2: Groom {myHorse._name}
3: Do a race");
            var menuChoice = Console.ReadLine();

            switch (menuChoice)
            {
                case "1":
                    Console.WriteLine(myHorse.FeedHorse());
                    break;
                case "2":
                    Console.WriteLine(myHorse.BrushHorse());
                    break;
                case "3":
                    race.Race();
                    break;
                default:
                    Console.WriteLine("Please select 1,2 or 3");
                    break;
            }
            }
        }
    }
}
