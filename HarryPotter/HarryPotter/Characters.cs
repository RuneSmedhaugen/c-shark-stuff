using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter
{
    internal class Characters
    {
        public string _name { get; set; }
        public SortingHat _house { get; set; }
        public int _mana { get; set; }
        public Items _wand { get; set; }
        public Items _pet { get; set; }

        public Characters(string Name, SortingHat House, int Mana, Items Wand, Items Pet)
        {
            _name = Name;
            _house = House;
            _mana = Mana;
            _wand = Wand;
            _pet = Pet;

        }

        public Characters()
        {
            
        }

    }
}
