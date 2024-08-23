using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium
{
    internal class Fish
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string Draw { get; protected set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Fish(string name, string description, string draw)
        {
            Name = name;
            Description = description;
            Draw = draw;

        }

        public void FishProperties()
        {
        }
    }
}
