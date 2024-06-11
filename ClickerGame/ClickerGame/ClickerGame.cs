using System;
using System.Collections.Generic;
using System.Text;

namespace ClickerGame
{
    class ClickerGame
    {
        public int Points { get; private set; } = 0;
        int _pointsPerClick = 1;
        int _pointsPerClickIncrease  = 1;
        public int _upgradecost { get; private set; } = 10;
        public void Click()
        {
            Points += _pointsPerClick;
        }

        public void Upgrade()
        {
            if (Points < _upgradecost) return;
            Points -= _upgradecost;
            _upgradecost += 10;
            _pointsPerClick += _pointsPerClickIncrease;
            Console.WriteLine("Upgraded! Points: " + Points + ", Points per click: " + _pointsPerClick);
        }

        public void SuperUpgrade()
        {
            if (Points < 100) return;
            Points -= 100;
            _pointsPerClickIncrease++;
        }
    }
}