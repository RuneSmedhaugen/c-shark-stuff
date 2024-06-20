using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abaxrekruttering
{
   internal abstract class Vehicles
   {
        public string Name { get; set; }
        public int Effect { get; set; }
        public int Speed { get; set; }
        public string Type { get; set; }
        public int Weight { get; set; }         

        public abstract string PrintInfo();

    }

    
}
