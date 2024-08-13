using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlongMarie
{
    internal class HorseRace
    {
        private int finishLine = 3000;

        private List<Horses> horses = new List<Horses>
        {
            new Horses("speedyboi", 35),
            new Horses("mediumboi", 30)
        };

        public void Race()
        {
            bool raceFinished = false;

            while (!raceFinished)
            {
                foreach (var horse in horses)
                {
                    horse.Run();
                    Console.WriteLine($"{horse._name} ran {horse.Position}.");

                    if (horse.Position >= finishLine)
                    {
                        Console.WriteLine($"{horse._name} finished the race");
                        raceFinished = true;
                        break;
                    }
                }
                Thread.Sleep(200);
            }

        }
    }
}
