using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bossfight
{
    internal class Boss
    {
        private int _strength;
        private int _health;
        private int _stamina;
        private static Random _random = new Random();
        

        public Boss( int Health, int Stamina)
        {

            _health = Health;
            _stamina = Stamina;
            GenerateRandomStrength();
        }

        private void GenerateRandomStrength()
        {
            _strength = _random.Next(0, 31);
        }

        public void BossFight()
        {
            GenerateRandomStrength();
        }

        public void BossRecharge()
        {

        }

        public void Test()
        {
            Console.WriteLine($"str = {_stength}");
        }
    }


}
