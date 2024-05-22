using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_converter
{
    internal class Temperature
    {
        public double celsiustofahrenheit(double celsius)
        {
            return(celsius *9/5)+32;
        }

        public double fahrenheittocelsius(double fahrenheit)
        {
            return (fahrenheit - 32) * 5 / 9;
        }

        public void Temp()
        {
         
            Temperature converter = new Temperature();
            while(true)
            {
                Console.WriteLine("Temperature Converter");
                Console.WriteLine("1. Convert Celsius to Fahrenheit");
                Console.WriteLine("2. Convert Fahrenheit to Celsius");
                Console.WriteLine("3. Exit");
                Console.Write("Please choose an option (1-3): ");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.WriteLine("Skriv inn tall");
                    if (double.TryParse(Console.ReadLine(), out double celsius))
                    {
                        double fahrenheit = converter.celsiustofahrenheit(celsius);
                        Console.WriteLine($"{celsius}C er {fahrenheit}F");
                    }
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Skriv inn tall");
                    if (double.TryParse(Console.ReadLine(), out double fahrenheit))
                    {
                        double celsius = converter.fahrenheittocelsius(fahrenheit);
                        Console.WriteLine($"{fahrenheit}F er {celsius}C");
                    }
                }
                else if(choice == "3")
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
