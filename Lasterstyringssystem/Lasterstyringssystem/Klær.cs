using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagerstyringssystem
{
    internal class Klær:Iprodukt
    {
        private string _name;
        private double _price;
        private string _size;

        public Klær(string Name, double Price, string Size)
        {
            _name = Name;
            _price = Price;
            _size = Size;
        }

        public void SkrivUtInfo()
        {

        }
    }
}
