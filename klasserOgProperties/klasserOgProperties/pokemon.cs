using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klasserOgProperties
{
    internal class Pokemon
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Level { get; set; }

        public Pokemon(string name, int health, int level)
        {
            Name = name;
            Health = health;
            Level = level;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"pokemon: {Name}, health: {Health}, level: {Level}");
        }
    }
}
