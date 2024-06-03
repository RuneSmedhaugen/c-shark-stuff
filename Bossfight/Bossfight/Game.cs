using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bossfight
{
    internal class Game
    {
        bool playing = false;
        private Boss _boss;
        private GameCharacter _player;

        public Game(Boss boss, GameCharacter player)
        {
            _boss = boss;
            _player = player;
        }

        public void PlayingGame()
        {
            Console.WriteLine("Would you like to start fighting? (yes/no)");
            string startGame = Console.ReadLine();

            if (startGame == "yes")
            {
                playing = true;

                while (playing)
                {
                    Stats();
                    Console.WriteLine(@"What would you do?
1: Attack
2: Recharge");
                    string atkOrRchrg = Console.ReadLine();
                    if (atkOrRchrg == "1")
                    {
                        _player.Fight(_boss);
                        _boss.BossFight(_player);
                    }
                    else if (atkOrRchrg == "2")
                    {
                        _player.Recharge();
                        Console.WriteLine("You fully recharged your Energy.");
                    }
                    else
                    {
                        {Console.WriteLine("Please select 1 or 2");}
                    }
                    WinOrLose();
                }
            }
            else if (startGame == "no")
            {
                Console.WriteLine("well wtf u doing here then kekw");
            }
        }

        public void Stats()
        {
            Console.WriteLine($@"Your stats:
Health: {_player.Health} 
Energy: {_player.Stamina}
        ***
Boss Health:{_boss.Health}
");
        }

        public void WinOrLose()
        {
            if (_boss.Health <= 0)
            {
                playing = false;
                Console.WriteLine("You win!");
            }
            else if (_player.Health  <= 0)
            {
                playing = false;
                Console.WriteLine("You lose.. L");
            }
        }
    }
}
