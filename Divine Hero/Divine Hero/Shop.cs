using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Divine_Hero
{
    internal class Shop
    {
        private int HealthCost = 10;
        private int DamageCost = 15;
        private int CritCost = 10;

        public void IncreaseHealth(Hero hero)
        {
            if (hero._coins >= HealthCost)
            {
                hero.Maxhp += 10;
                hero._coins -= HealthCost;
                hero.Health = hero.Maxhp;
                Console.WriteLine(@$"You bought increased health. Your health is now {hero.Health}

Press any key to continue");
            }
            else
                Console.WriteLine(@"Not enough coins to increase health.

Press any key to continue");
        }

        public void IncreaseDamage(Hero hero)
        {
            if (hero._coins >= DamageCost)
            {
                hero.DamageMin += 5;
                hero.DamageMax += 5;
                hero._coins -= DamageCost;
                Console.WriteLine(@$"You bought increased damage. Your damage is now {hero.DamageMin}-{hero.DamageMax}
                                  
Press any key to continue");
            }
            else
            {
                Console.WriteLine(@"Not enough coins to increase damage.

Press any key to continue");
            }
        }

        public void IncreaseCrit(Hero hero)
        {
            if (hero._coins >= CritCost)
            {
                hero._crit += 0.5;
                hero._coins -= CritCost;
                Console.WriteLine(@$"You bought increased crit. Your crit is now {hero._crit}.

Press any key to continue");
            }
            else
                Console.WriteLine(@"Not enough coins to increase crit chance.

Press any key to continue");
        }
        
         
    }
}
