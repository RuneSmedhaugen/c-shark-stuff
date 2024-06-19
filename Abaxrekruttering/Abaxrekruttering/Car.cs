using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abaxrekruttering
{
    internal class Car : Vehicles
    {
        public Car(string name, int effect, int speed, string color, string type)
        {
            Name = name;
            Effect = effect;
            Speed = speed;
            Color = color;
            Type = type;
        }

        public override string PrintInfo()
        {
            return $"reg. nr: {Name}, effekt: {Effect}kw, maksfart: {Speed}km/t, farge: {Color}, type: {Type}";
        }


    }
}
