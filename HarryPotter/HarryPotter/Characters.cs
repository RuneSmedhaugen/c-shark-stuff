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
        public int _level { get; set; }
        public int _coins { get; set; }
        public int _defaulthealth { get; set; }
        public int _defaultmana { get; set; }
        public int _crit { get; set; }
        Random random = new Random();

        public Characters(string Name, SortingHat House, int Mana, Items Wand, Items Pet, int health, int spells, int level, int coins, int defaulthealth, int defaultmana, int crit)
        {
            _name = Name;
            _house = House;
            _mana = Mana;
            _wand = Wand;
            _pet = Pet;
            _health = health;
            _spells = spells;
            _level = level;
            _coins = coins;
            _defaulthealth = defaulthealth;
            _defaultmana = defaultmana;
            _crit = crit;
        }

        public Characters()
        {

        }

        public Characters(string Name, int Health, int Mana, int Crit)
        {
            _name = Name;
            _mana = Mana;
            _health = Health;
            _crit = Crit;
            
        }

        public Characters Enemies()
        {
            List<Characters> enemies = new List<Characters>
            {
                new Characters("Erlend", 100,100,0),
                new Characters("Linda", 100,100,0),
                new Characters("Ellie",100,100,0),
                new Characters("Erik",100,100,0),
                new Characters("Martin", 100,100,0),
                new Characters("Christopher",100,100,0),
                new Characters("Sofus", 100,100,0),
                new Characters("Viktor",100,100,0),
                new Characters("Marie",100,100,0),
                new Characters("Hanne",100,100,0),
                new Characters("Stian", 100, 100,0),
                new Characters("Albert", 120, 120, 5),
                new Characters("André", 150, 150, 5),
                new Characters("Trine", 150, 180, 10),
                new Characters("Frode", 200, 200, 10),
                new Characters("Jonas", 200, 250,15),
                new Characters("Thomas", 300, 300, 15),
                new Characters("Linn", 200,320,20),
                new Characters("Eskil", 200, 350, 20),
                new Characters("Marie", 200,400,20),
                new Characters("Rebecka", 200,450, 25),
                new Characters("Terje", 500, 250,30),
            };

            foreach (var enemy in enemies)
            {
                if (enemy._health > 0)
                {
                    return enemy;
                }

            }

            return null;
        }

        
    }
}
