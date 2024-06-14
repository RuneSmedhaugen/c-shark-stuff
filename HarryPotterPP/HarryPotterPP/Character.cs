using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotterPP
{
    internal class Character
    {

        private string Name;
        private string House;
        public List<Item> Items;

        public Character(string name, string house)
        {
            Name = name;
            House = house;
            Items = new List<Item>();
        }


        public void Introduction()
        {
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("House: " + House);

            foreach (var item in Items)
            {
                Console.WriteLine(item.Name + ", " + item.Description);
            }
        }

    }
}
