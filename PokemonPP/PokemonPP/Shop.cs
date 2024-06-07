using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonPP
{
    internal class Shop
    {

        private string _pokeball;
        private string _healthpotion;
        private int _pokeballPrice = 10;
        private int _healthpotionPrice = 20;


        public Shop(string Pokeball, string Healthpotion)
        {
            _pokeball = Pokeball;
            _healthpotion = Healthpotion;
        }


        public void buyItem(Player player, string item)
        {
            if (item.Equals(_pokeball))
            {
                if (player.Coins >= _pokeballPrice)
                {
                    player.Coins -= _pokeballPrice;
                    player.AddToInventory("Pokeball");
                    Console.WriteLine("Pokeball has been added to your inventory.");
                }
                else if (player.Coins < _pokeballPrice)
                {
                    Console.WriteLine("you don't have enough coins to buy this item.");
                }
            }
            else if (item.Equals(_healthpotion))
            {
                if (player.Coins >= _healthpotionPrice)
                {
                    player.Coins -= (_healthpotionPrice);
                    player.AddToInventory("Healthpotion");
                    Console.WriteLine("Healthpotion has been added to your inventory.");
                }
                else if (player.Coins < _healthpotionPrice)
                {
                    Console.WriteLine("you don't have enough coins to buy this item.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Item!");
            }
        }
    }
}
