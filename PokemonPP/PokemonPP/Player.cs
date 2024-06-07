using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonPP
{
    internal class Player
    {
        private string _name;
        private Pokemon _pokemon;
        private List<Pokemon> _pokemons;
        private string _inventory;
        private int _coins;

        public Player(string Name, Pokemon Pokemon, string Inventory, int Coins)
        {
            _name = Name;
            _pokemon = Pokemon;
            _inventory = Inventory;
            _coins = Coins;
        }

        public void AddToInventory(string item)
        {
            _inventory += (string.IsNullOrEmpty(_inventory) ? "" : ", ") + item;
        }

        public string GetInventory()
        {
            return string.IsNullOrEmpty(_inventory) ? "Inventory is empty." : _inventory;
        }

        public int PokeballCount
        {
            get
            {
                return _inventory.Split(new[] { ", " }, StringSplitOptions.None).Count(item => item == "Pokeball");
            }

            set
            {
                var items = _inventory.Split(new[] { ", " }, StringSplitOptions.None).ToList();
                if (value < items.Count(item => item == "Pokeball"))
                {
                    items.Remove("Pokeball");
                }
                else
                {
                    items.Add("Pokeball");
                }
                _inventory = string.Join(", ", items);
            }
        }

        public bool UsePokeball()
        {
            if (PokeballCount > 0)
            {
                PokeballCount--;
                return true;
            }
            else
            {
                return false;
            }
        }
        public int Coins
        {
            get { return _coins; }
            set { _coins = value; }
        }

        public Pokemon Pokemon
        {
            get { return _pokemon; }
            set { _pokemon = value; }
        }


    }
}
