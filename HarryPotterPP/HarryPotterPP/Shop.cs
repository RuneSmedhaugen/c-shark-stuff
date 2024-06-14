using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotterPP
{
    internal class Shop
    {

        string ShopName;
        List<Item> Inventory;

        public Shop(string shopName)
        {
            ShopName = shopName;
            Inventory = new List<Item>();
        }
    }


}
