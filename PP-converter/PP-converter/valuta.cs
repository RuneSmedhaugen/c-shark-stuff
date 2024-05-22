using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP_converter
{
    internal class Valuta
    {
            public double noktodollar(double nok)
            {
                return (nok) / 10.69;
            }

            public double dollartonok(double dollar)
            {
                return (dollar) * 10.69;
            }

            public void KekW()
            {
               
                Valuta converter = new Valuta();
                while (true)
                {
                    Console.WriteLine("Valuta Converter");
                    Console.WriteLine("1. Convert NOK to Dollar");
                    Console.WriteLine("2. Convert Dollar to NOK");
                    Console.WriteLine("3. Exit");
                    Console.Write("Please choose an option (1-3): ");
                    string choice = Console.ReadLine();
                    if (choice == "1")
                    {
                        Console.WriteLine("Skriv inn tall");
                        if (double.TryParse(Console.ReadLine(), out double nok))
                        {
                            double dollar = converter.noktodollar(nok);
                            Console.WriteLine($"{nok}NOK er {dollar}$");
                        }
                    }
                    else if (choice == "2")
                    {
                        Console.WriteLine("Skriv inn tall");
                        if (double.TryParse(Console.ReadLine(), out double dollar))
                        {
                            double nok = converter.dollartonok(dollar);
                            Console.WriteLine($"{dollar}$ er {nok}NOK");
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
