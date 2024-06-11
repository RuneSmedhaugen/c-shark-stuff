﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerGame
{
    internal interface ICommand
    {
        public void Run();
        char Character { get; }
    }
}
