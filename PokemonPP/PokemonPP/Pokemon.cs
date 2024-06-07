using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonPP
{
    internal class Pokemon
    {
        private string _name;
        private string _type;
        private int _health;
        private int _attack;
        public Pokemon(string Name, string Type, int Health, int Attack)
        {
            _name = Name;
            _type = Type;
            _health = Health;
            _attack = Attack;

        }

        public string Name
        {
            get { return _name; }
        }
    }
}
