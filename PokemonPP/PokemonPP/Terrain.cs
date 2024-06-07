using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonPP
{
    internal class Terrain
    {

        private Random _random;


        public void Grass()
        {
            _random = new Random();
            Console.WriteLine("You are walking around in grass...");

            if (_random.Next(0, 2) == 1)
            {
                string encounteredPokemon = _random.Next(0, 2) == 0 ? "Pikachu" : "Pidgey";
                Console.WriteLine($"A wild {encounteredPokemon} appeared!");
                Console.WriteLine(@" What will you do?
1: Fight
2: Catch
3: Flee");
                string whatToDo = Console.ReadLine();
                if (whatToDo == "1")
                {

                }
            }
        }

        public void Water()
        {
            _random = new Random();
            Console.WriteLine("You are swimming around in the sea...");
            if (_random.Next(0, 2) == 1)
            {
                string encountedPokemon = _random.Next(0, 2) == 0 ? "Poliwag" : "Krabby";
                Console.WriteLine($"A wild {encountedPokemon} appeared!");
                Console.WriteLine(@"What will you do?
1: Fight
2: Catch
3: Flee");
            }
        }
    }
}