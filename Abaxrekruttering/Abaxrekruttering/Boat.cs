using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abaxrekruttering
{
    internal class Boat : Vehicles
    {
        public Boat(string name, int effect, int speed, int weight)
        {
            Weight = weight;
            Name = name;
            Effect = effect;
            Speed = speed;
            Weight = weight;
        }
        public override string PrintInfo()
        {
            return $"Kjennetegn: {Name}, effekt: {Effect}kw, maksfart: {Speed}knop, bruttotonnasje: {Weight}kg. ";
        }
    }
}
