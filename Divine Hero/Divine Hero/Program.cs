using Divine_Hero;
using System;
using System.Threading;
using System.Runtime.ExceptionServices;
using Microsoft.VisualBasic;

class Program
{
    private static List<EnemyOne> enemies = new List<EnemyOne>
    {
        //normal enemies
        new EnemyOne("Grok", 100, 100, 10,20),
        new EnemyOne("Grak", 150, 150, 20,30),
        new EnemyOne("Gruk", 200, 200, 40,60),
    };

    private List<EnemyOne> bosses = new List<EnemyOne>
    {
new EnemyOne("Gthree",500, 500, 20,30),
new EnemyOne("l00p", 1250, 1250, 30,50)
    };
    static void Main(string[] args)
    {
        Console.WriteLine("Hello and welcome to Divine Hero! What is your hero's name?");
        string input = Console.ReadLine();
        Hero hero = new Hero(input, 100, 100, 1, 10, 20, 0, 200,0);
        Shop shop = new Shop();

        bool mainMeu = true;
        while (mainMeu)
        {

        Console.Clear();
        Console.WriteLine(@$"Hello, {hero.Name}! You have {hero._wins} wins and {hero._loss} losses.
1: Fight enemy
2: Fight boss
3: Visit shop
4: show your stats
5: How to play
6: Exit program");
        string menuChoice = Console.ReadLine();
        switch (menuChoice)
        {
                case "1":
                    FightEnemy();
                    Console.ReadKey();
                    break;
                case "2":
                    //fight boss method
                break;
                case "3":
                    Shopmenu(hero);
                break;
                case "4":
                    hero.ShowStats();
                break;
                case "5":
                    HowToPlay();
                break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Please choose between 1-4.");
                    break;
        }
        }

        void HowToPlay()
        {
            Console.WriteLine(@"How to play:
This is a turn-based hero game, level up and upgrade your hero to become stronger and fight harder enemies!
Fight enemies to level up and gain coins
Fight bosses to increase experience and coins gained
Visit the shop to upgrade your hero!

Press any button to continue");
            Console.ReadKey();
        }
        
        void Shopmenu(Hero hero)
        {
           bool inShop = true;
           while (inShop)
           {

           
                Console.Clear();
                Console.WriteLine(@$"What would you like to buy?
Coins: {hero._coins}

1: Increase health: 10 coins
2: Increase damage: 15 coins
3: Increase crit chance: 10 coins
4: Exit shop"); 
                string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                   shop.IncreaseHealth(hero);
                   Console.ReadKey();
                break;
                case "2":
                    shop.IncreaseDamage(hero);
                    Console.ReadKey();
                        break;
                case "3":
                    shop.IncreaseCrit(hero);
                    Console.ReadKey();
                        break;
                case "4":
                    inShop = false;
                    break;
                default:
                    Console.WriteLine(@"please enter a valid choice

press any key to continue...");
                    Console.ReadKey();
                        break;
            }
           }
        }

        void FightEnemy()
        {
            int enemyIndex = (hero._wins / 10) % enemies.Count;
            EnemyOne currentEnemy = enemies[enemyIndex];
            Console.WriteLine($"You are fighting {currentEnemy.Name}");

            bool isFighting = true;
            while (isFighting)
            {
                int dmgdealt = hero.Fight(currentEnemy);
                if (dmgdealt > hero.DamageMax)
                {
                    Console.WriteLine($"{hero.Name} did {dmgdealt} (Critical!) damage to {currentEnemy.Name}");
                }
                else
                {
                    Console.WriteLine($"{hero.Name} did {dmgdealt} damage to {currentEnemy.Name}");
                }
                
                if (currentEnemy.Health <= 0)
                {
                    hero._wins++;
                    hero._xp += 10;
                    hero.LevelUp();
                    hero._coins += 10;
                    hero.Health = hero.Maxhp;
                    currentEnemy.Health = currentEnemy.Maxhp;
                    Console.WriteLine($"You defeated {currentEnemy.Name}! Press any key to continue....");
                    isFighting = false;
                    break;
                }
                Thread.Sleep(1000);

                int dmgtaken = currentEnemy.Fight(hero);
                Console.WriteLine($"{currentEnemy.Name} did {dmgtaken} damage to {hero.Name}");
                if (hero.Health <= 0)
                {
                    Console.WriteLine($"{currentEnemy.Name} defeated you. Press any key to continue...");
                    hero._loss++;
                    hero._coins += 2;
                    hero._xp += 5;
                    hero.LevelUp();
                    hero.Health = hero.Maxhp;
                    currentEnemy.Health = currentEnemy.Maxhp;

                    isFighting =false;
                    break;
                }
            }
        }

    }
}
