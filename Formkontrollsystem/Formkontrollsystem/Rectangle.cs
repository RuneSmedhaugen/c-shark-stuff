using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Formkontrollsystem
{
    internal class Rectangle: Shape
    {
        public int Length { get; private set; }
        public int Width { get; private set; }

        public Rectangle(string name, string color, int length, int width)
        {
            Name = name;
            Color = color;
            Length = length;
            Width = width;
        }

        public override double BeregnAreal()
        {
            double area = Width * Length;
            return area;
        }
    }
}
