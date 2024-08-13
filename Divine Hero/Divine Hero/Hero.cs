using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Divine_Hero
{
    internal class Hero : Stats
    {


        public int _level { get;  set; }
        public double _crit { get; set; }
        public int _coins { get; set; }
        public int _xp { get; set; }
        public int _wins { get; set; }
        public int _loss { get; set; }
        
        Random random = new Random();

        public Hero(string name,int maxhp, int health, int level, int damagemin, int damagemax, double crit, int coins, int xp)
        {
            Name = name;
            Maxhp = maxhp;
            Health = health;
            DamageMin = damagemin;
            DamageMax = damagemax;
            _level = level;
            _crit = crit;
            _coins = coins;
            _xp = xp;
        }

        public int Fight(EnemyOne enemy)
        {
            int dmg;
           int critChance = random.Next(0, 101);
           if (_crit > critChance)
           {
               dmg = random.Next(DamageMin, DamageMax) * 2;
           }
           else
           {
               dmg = random.Next(DamageMin, DamageMax);
           }

           enemy.Health -= dmg;
           return dmg;


        }

        public void LevelUp()
        {
            if (_xp >= 100)
            {
                _level++;
                _coins += 50;
                Health += 10;
                DamageMin += 10;
                DamageMax += 10;
                _xp = 0;
                
                Console.WriteLine(@$"You leveled up! you are now level {_level}.
+50 coins
+10 health
+10 damage");
            }
        }

        public void ShowStats()
        {
            Console.WriteLine($@"
Name: {Name}
Health: {Maxhp}
Level: {_level}
Damage: {DamageMin}-{DamageMax}
Crit %: {_crit}
Coins: {_coins}
XP: {_xp}
Wins: {_wins}

Press any key to continue");
            Console.ReadKey();
        }

    }
}


