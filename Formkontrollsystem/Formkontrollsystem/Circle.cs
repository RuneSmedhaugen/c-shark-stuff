using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formkontrollsystem
{
    internal class Circle : Shape
    {
        public int Radius { get;private set; }

        public Circle(string name, string color, int radius )
        {
            Radius = radius;
            Name = name;
            Color = color;
            
        }
        public override double BeregnAreal()
        {
           double area = Math.PI * Radius;
            return area;
        }
    }
}
