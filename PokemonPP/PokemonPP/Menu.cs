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

        public Player player = new Player("Terje", "", "", 100);

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
            Console.WriteLine(@"What do you want to do?
                1: Explore the wilderness
                2: Explore the sea
                3: Enter shop");
            string menuChoice = Console.ReadLine();
            if(menuChoice == "1")
            {
               terrain.Grass();

            }
            else if (menuChoice == "2") {
                terrain.Water();
            }
            else if (menuChoice == "3")
            {
                Console.WriteLine("What would you like to buy? (pokeball/healthpotion)");
                string chosenItem = Console.ReadLine();
                shop.buyItem(player, chosenItem);
            }
            else
            {
                ChooseMenu();
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
            }
            else if (input == "charmander" || input == "Charmander")
            {
                Console.WriteLine($"You choose {input}");
            }
            else if (input == "squirtle" || input == "Squirtle")
            {
                Console.WriteLine($"You choose {input}");
            }
            else
            {
                ChoosePokemon();
            }
        }




        public void Run()
        {
            Starter();
            ChoosePokemon();
            ChooseMenu();



        }


    }
}
