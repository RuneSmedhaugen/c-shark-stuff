using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagerstyringssystem
{
    internal class Matvare:Iprodukt
    {
        private string _name;
        private double _price;
        private DateOnly _expiration;

        public Matvare(string Name, double Price, DateOnly Expiration)
        {
            _name = Name;
            _price = Price;
            _expiration = Expiration;
        }

        public void SkrivUtInfo()
        {

        }
    }
}
