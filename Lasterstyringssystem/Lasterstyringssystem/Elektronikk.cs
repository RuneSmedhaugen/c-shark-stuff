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
        public int Antall { get; set; }
        private int _guarantee;

        public Elektronikk(string navn, double pris, int Guarantee, int antall)
        {
            Navn = navn;
            Pris = pris;
            _guarantee = Guarantee;
            Antall = antall;
        }

        public void SkrivUtInfo()
        {
            Console.WriteLine(@$"Navn: {Navn} 
Garanti: {_guarantee}mnd
pris: {Pris}kr");
            Console.WriteLine("****************");
        }
    }
}
