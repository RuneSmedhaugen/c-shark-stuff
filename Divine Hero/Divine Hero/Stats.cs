using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divine_Hero
{
    internal abstract class Stats
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMin { get; set; }
        public int DamageMax { get; set; }
        public int Maxhp { get; set; }
    }
}

        
