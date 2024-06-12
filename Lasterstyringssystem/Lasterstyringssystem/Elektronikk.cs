using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagerstyringssystem
{
    internal class Elektronikk:IProdukt
    {
        public string Navn { get; set; }
        public double Pris { get; set; }
        private int _guarantee;

        public Elektronikk(string navn, double pris, int Guarantee)
        {
            Navn = navn;
            Pris = pris;
            _guarantee = Guarantee;
        }

        public void SkrivUtInfo()
        {
            Console.WriteLine($"Navn: {Navn}, Garanti: {_guarantee}, pris: {Pris}");
        }
    }
}
