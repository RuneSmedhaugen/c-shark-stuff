using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lagerstyringssystem
{
    public interface Iprodukt
    {
        private string Navn { get; set; }
        private double pris { get; set; }

        void SkrivUtInfo();
    }
}
