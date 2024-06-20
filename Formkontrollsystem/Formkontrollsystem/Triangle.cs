using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formkontrollsystem
{
    internal class Triangle: Shape
    {
        public int Base { get; private set; }
        public int Height { get; private set; }

        public Triangle(string name, string color, int basen, int height)
        {
            Name = name;
            Color = color;
            Base = basen;
            Height = height;
        }
        public override double BeregnAreal()
        {
            double area = 0.5 * Base * Height;
            return area;

        }
    }
}
