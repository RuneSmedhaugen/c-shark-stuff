using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abaxrekruttering
{
    internal class Plane : Vehicles
    {
        public int Wingspan { get; private set; }
        public int Load { get; private set; }

        public Plane(string name, int effect, int wingspan, int load, int weight, string type)
        {
            Name = name;
            Effect = effect;
            Wingspan = wingspan;
            Load = load;
            Weight = weight;
            Type = type;

        }

        public override string PrintInfo()
        {
            return
                $"Kjennetegn: {Name}, effekt: {Effect}kw, Vingespenn: {Wingspan}m, Lasteevne: {Load}tonn, vekt: {Weight}tonn, type: {Type} ";
        }
    }
}
