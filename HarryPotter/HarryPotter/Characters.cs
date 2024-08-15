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
        public int _health { get; set; }
        public Items _wand { get; set; }
        public Items _pet { get; set; }
        public int _spells { get; set; }
        Random random = new Random();

        public Characters(string Name, SortingHat House, int Mana, Items Wand, Items Pet, int health, int spells)
        {
            _name = Name;
            _house = House;
            _mana = Mana;
            _wand = Wand;
            _pet = Pet;
            _health = health;
            _spells = spells;
        }

        public Characters()
        {

        }

        public Characters(string Name, int Mana, int Health)
        {
            _name = Name;
            _mana = Mana;
            _health = Health;
            
        }

        public Characters Enemies()
        {
            List<Characters> enemies = new List<Characters>
            {
                new Characters("Bjarne", 100, 100),
                new Characters("Arne", 50, 150),
                new Characters("Plutte", 150, 50),
                new Characters("Trine", 120, 80),
                new Characters("Frode", 80, 120),
                new Characters("Jonas", 50, 200),
                new Characters("Thomas", 200, 90),
            };

            var randomEnemy = random.Next(8);
            return enemies[randomEnemy];

        }
    }
}
