using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerGame
{
    internal class Click : ICommand
    {
        private ClickerGame _game;
        public char Character { get; } = ' ';

        public Click(ClickerGame game)
        {
            _game = game;
        }

        public void Run()
        {
            _game.Click();
        }
    }
}
