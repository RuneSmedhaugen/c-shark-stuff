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
        private GameCharacter _character;


        public Boss(int Health, int Stamina)
        {

            _health = Health;
            _stamina = Stamina;
            GenerateRandomStrength();
        }

        private void GenerateRandomStrength()
        {
            _strength = _random.Next(0, 31);
        }

        public void BossFight(GameCharacter _character)
        {
            GenerateRandomStrength();
            if (_stamina > 0)
            {
                _character.Health -= _strength;
                _stamina -= 10;
                Console.WriteLine($"Boss attacks you for {_strength}. Your health is now {_character.Health}");
            }
            else
            {
                Console.WriteLine("The Baws recharged his energy.");
                BossRecharge();
            }
            

        }

        public void BossRecharge()
        {
            _stamina = 10;
        }

        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
    }


}
