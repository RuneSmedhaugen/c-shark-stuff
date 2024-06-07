using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonPP
{
    internal class Terrain
    {

        private Random _random;


        public void Grass(Player player)
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
                else if (whatToDo == "2")
                {
                    CatchPokemon(player, encounteredPokemon);
                }
            }
        }

        public void Water(Player player)
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

        public void CatchPokemon(Player player, Pokemon pokemon)
        {
            if (player.UsePokeball())
            {
                Random random = new Random();
                bool isCaught = random.Next(0, 2) == 0;
                if (isCaught)
                {
                    Console.WriteLine($"You caught a {pokemon.Name}!");
                    player.AddPokemon(pokemon);
                }
                else
                {
                    Console.WriteLine($" The {pokemon.Name} dodged your ball and yeeted away!");
                }

            }
            else
            {
                Console.WriteLine("You don't have any pokeballs!");
            }
        }
    }
}