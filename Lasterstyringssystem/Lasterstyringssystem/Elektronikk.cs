using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagerstyringssystem
{
    internal class Elektronikk:Iprodukt
    {
        private string _name;
        private double _price;
        private int _guarantee;

        public Elektronikk(string Name, double Price, int Guarantee)
        {
            _name = Name;
            _price = Price;
            _guarantee = Guarantee;
        }

        public void SkrivUtInfo()
        {

        }
    }
}
