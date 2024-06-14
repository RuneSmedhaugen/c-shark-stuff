using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagerstyringssystem
{
    internal class Matvare:IProdukt
    {
        public string Navn { get; set; }
        public double Pris { get; set; }
        public int Antall { get; set; }
        private DateOnly _expiration;

        public Matvare(string navn, double pris, DateOnly expiration, int antall)
        {
            Navn = navn;
            Pris = pris;
            _expiration = expiration;
            Antall = antall;
        }

        public void SkrivUtInfo()
        {
            Console.WriteLine(@$"Navn: {Navn} 
utløpsdato: {_expiration} 
pris: {Pris}kr");
            Console.WriteLine("****************");
        }
    }
}
