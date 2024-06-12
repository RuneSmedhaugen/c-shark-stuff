using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagerstyringssystem
{
    internal class Klær:IProdukt
    {
        public string Navn { get; set; }
        public double Pris { get; set; }
        private string _size;

        public Klær(string navn, double pris, string size)
        {
            Navn = navn;
            Pris = pris;
            _size = size;
        }

        public void SkrivUtInfo()
        {
            Console.WriteLine($"Navn: {Navn}, størrelse: {_size}, pris: {Pris}");
        }
    }
}
