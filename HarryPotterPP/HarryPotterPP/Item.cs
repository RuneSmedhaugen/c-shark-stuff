using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotterPP
{
    internal class Item
    {
       public string Name;
       public string Description;
       public string whatIs;

        public Item(string name, string description, string whatIs)
        {
            Name = name;
            Description = description;
            this.whatIs = whatIs;
        }
    }
}
