using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_converter
{
    internal class Weight
    {
        public double kilotopound(double kilo)
        {
            return (kilo) * 2.2;
        }

        public double poundtokilo(double pound)
        {
            return (pound) / 2.2;
        }

        public void Vekt()
        {
           
            Weight converter = new Weight();
            while (true)
            {
                Console.WriteLine("Weight Converter");
                Console.WriteLine("1. Convert kilo to pound");
                Console.WriteLine("2. Convert pound to kilo");
                Console.WriteLine("3. Exit");
                Console.Write("Please choose an option (1-3): ");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.WriteLine("Skriv inn tall");
                    if (double.TryParse(Console.ReadLine(), out double kilo))
                    {
                        double pound = converter.kilotopound(kilo);
                        Console.WriteLine($"{kilo}K er {pound}P");
                    }
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Skriv inn tall");
                    if (double.TryParse(Console.ReadLine(), out double pound))
                    {
                        double kilo = converter.poundtokilo(pound);
                        Console.WriteLine($"{pound}P er {kilo}K");
                    }
                }
                else if (choice == "3")
                {
                    Console.WriteLine("Prekæs");
                    break;
                }
                else
                {
                    Console.WriteLine("Ey dummy, du må velge 1, 2 eller 3. Kan ikke skrive noe annet.");
                }
            }
        }

    }
}
