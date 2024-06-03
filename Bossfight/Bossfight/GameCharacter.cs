using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Bossfight
{
    internal class GameCharacter
    {
        private int _health;
        private int _strength;
        private int _stamina;
        private Boss bossInstance;

        public GameCharacter(int Health, int Strength, int Stamina)
        {
            _health = Health;
            _strength = Strength;
            _stamina = Stamina;
        }
    
        public void Fight(Boss bossInstance)
        {
        if (_stamina > 0)
        {
            bossInstance.Health -= _strength;
            _stamina -= 10;
            Console.WriteLine(@$"You attack for {_strength}. Baws health is now {bossInstance.Health}. Your Stamina is now {_stamina}");
        }
        else
        {
            Console.WriteLine("You don't have enough stamina to attack, you recharged your energy instead.");
            Recharge();
        }

        }

    public void Recharge()
    {
        _stamina = 40;
        Console.WriteLine("You recharged your energy.");
    }

    public int Health
    {
        get { return _health; }
        set { _health = value; }

    }
    public int Stamina
    {
        get { return _stamina; }
        set { _stamina = value; }
    }
    }
}
