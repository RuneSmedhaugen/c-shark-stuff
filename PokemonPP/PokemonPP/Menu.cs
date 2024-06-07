using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonPP
{
    internal class Menu
    {
        private Terrain terrain = new Terrain();
        Shop shop = new Shop("pokeball", "healthpotion");

        public Player player;

        Pokemon poliwag = new Pokemon("Poliwag", "Water", 100, 10);
        Pokemon krabby = new Pokemon("Krabby", "water", 100, 10);
        Pokemon pidgey = new Pokemon("Pidgey", "Flying", 100, 10);
        Pokemon pikachu = new Pokemon("Pikachu", "Electric", 100, 10);
        Pokemon bulbasaur = new Pokemon("Bulbasaur", "Grass", 100, 15);
        Pokemon charmander = new Pokemon("Charmander", "Fire", 100, 20);
        Pokemon squirtle = new Pokemon("Squirtle", "Water", 100, 15);













        public void Starter()
        {
            Console.Clear();
            Console.WriteLine("WELCOME TO POKEMON GAME!");
            Console.WriteLine("Press 'Enter' to Start New Game!");
            Console.ReadLine();
        }


        public void ChooseMenu()
        {
            while (true)
            {
                Console.WriteLine(@"What do you want to do?
1: Explore the wilderness
2: Explore the sea
3: Enter shop
4: See inventory
5: Check Pokemon
5: Exit game");
            string menuChoice = Console.ReadLine();
            if(menuChoice == "1")
            {
               terrain.Grass(player);

            }
            else if (menuChoice == "2") {
                terrain.Water(player);
            }
            else if (menuChoice == "3")
            {
                Console.WriteLine("What would you like to buy? (pokeball/healthpotion)");
                string chosenItem = Console.ReadLine();
                shop.buyItem(player, chosenItem);
            }
            else if (menuChoice == "4")
            {
               CheckInventory();
            }

            else if (menuChoice == "5")
            {
                CheckPokemon();
            }
            else if (menuChoice == "6")
            {
                Console.WriteLine("Exiting game. Cya nerd!");
                break;
            }
            else
            {
                Console.WriteLine("Please select a valid choice.");
            }
            }
        }


        public void ChoosePokemon()
        {
            Console.WriteLine("Choose a Pokemon:");
            Console.WriteLine("Bulbasaur, Charmander or Squirtle!");
            var input = Console.ReadLine();
            if(input == "bulbasaur" || input == "Bulbasaur")
            {
                Console.WriteLine($"You choose {input}");
                player = new Player("Terje", bulbasaur, "", 100);
            }
            else if (input == "charmander" || input == "Charmander")
            {
                Console.WriteLine($"You choose {input}");
                player = new Player("Terje", charmander, "", 100);
            }
            else if (input == "squirtle" || input == "Squirtle")
            {
                Console.WriteLine($"You choose {input}");
                player = new Player("Terje", squirtle, "", 100);
            }
            else
            {
                ChoosePokemon();
            }
        }

        public void CheckInventory()
        {
            Console.WriteLine("Your inventory contains:");
            Console.WriteLine(player.GetInventory());
        }

        public void CheckPokemon()
        {
            Console.WriteLine("Your pokemon:");
            Console.WriteLine(player.GetPokemonList());
        }


        public void Run()
        {
            Starter();
            ChoosePokemon();
            ChooseMenu();



        }


    }
}
