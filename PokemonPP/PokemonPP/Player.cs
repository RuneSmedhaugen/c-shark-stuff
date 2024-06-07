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
        private string _pokemon;
        private string _inventory;
        private int _coins;

        public Player(string Name, string Pokemon, string Inventory, int Coins)
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

        public int Coins
        {
            get { return _coins; }
            set { _coins = value; }
        }

        public string Pokemon
        {
            get { return _pokemon; }
            set { _pokemon = value; }
        }


    }
}
