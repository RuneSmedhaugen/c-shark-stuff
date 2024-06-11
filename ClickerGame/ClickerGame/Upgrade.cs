using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickerGame
{
    internal class Upgrade : ICommand
    {
        private ClickerGame _game;
        public Upgrade(ClickerGame game)
        {
            _game = game;
        }

        public char Character { get; } = 'k';

        public void Run()
        {
            _game.Upgrade();
        }
    }
}
