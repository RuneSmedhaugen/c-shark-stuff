﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter
{
    internal class Items
    {
        public string _name { get; set; }
        public string _type { get; set; }
        public string _description { get; set; }
        public int _baseDmg { get; set; }





        public Items(string Name, string Type, string Description, int BaseDmg)
        {
            _name = Name;
            _type = Type;
            _description = Description;
            _baseDmg = BaseDmg;

        }

        public Items()
        {
            
        }
    }
}
