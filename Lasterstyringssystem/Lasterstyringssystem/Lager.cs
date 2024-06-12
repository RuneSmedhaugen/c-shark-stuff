using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagerstyringssystem
{
    internal class Lager
    {
        private List<IProdukt> _products;

        public Lager()
        {
            _products = new List<IProdukt>();
        }

        public void LeggTilProdukt(IProdukt produkt)
        {
            _products.Add(produkt);
        }

        public bool FjernProdukt(string navn)
        {
            navn = navn.Trim().ToLower();
            var produkt = _products.FirstOrDefault(p => string.Equals(p.Navn, navn, StringComparison.OrdinalIgnoreCase));
            if (produkt != null)
            {
                _products.Remove(produkt);
                Console.WriteLine($"fant produktet {navn}");
                return true;

            }
            else
            {
                Console.WriteLine($"fant ikke produktet {navn}");
                return false;
            }
        }

        public void ListAlleProdukter()
        {
            foreach (var produkt in _products)
            {
                produkt.SkrivUtInfo();
            }
        }

        public void ListProdukterAvKategori<T>() where T : IProdukt
        {
            foreach (var produkt in _products.OfType<T>())
            {
                produkt.SkrivUtInfo();
            }
        }

    }
}
