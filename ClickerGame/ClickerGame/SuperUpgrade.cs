using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ClickerGame
{
    internal class SuperUpgrade : ICommand
    {
        private ClickerGame _game;
        public char Character { get; } = 's';

        public SuperUpgrade(ClickerGame game)
        {
            _game = game;
        }

        public void Run()
        {
            _game.SuperUpgrade();
        }
    }
}
