using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divine_Hero
{
    internal class EnemyOne : Stats
    {
        Random random = new Random();

        public EnemyOne(string name, int health, int maxhp, int damagemin, int damagemax)
        {
            Name = name;
            Health = health;
            Maxhp = maxhp;
            DamageMin = damagemin;
            DamageMax = damagemax;
        }

        public int Fight(Hero hero)
        {
          int dmg = random.Next(DamageMin, DamageMax);
          hero.Health -= dmg;
          return dmg;
        }
    }
}
