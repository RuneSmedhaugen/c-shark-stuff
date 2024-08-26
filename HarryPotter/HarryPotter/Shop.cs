using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter
{
    internal class Shop
    {
        public void Shopping(Run run)
        {
            Console.WriteLine($@"Welcome to the shop, what would you like to buy?");

            while (true)
            {
                Console.WriteLine(@"
1: Increase health by 10. Costs 20 coins
2: Increase mana by 10. Costs 20 coins
3: increase damage by 5. Costs 20 coins
3:Increase crit chance by 1%. Costs 50 coins
4: Exit shop");

                var shopanswer = Console.ReadLine();

                switch (shopanswer)
                {
                    case "1":
                        if (run.player._coins >= 20)
                        {
                            run.player._defaulthealth += 10;
                            run.player._coins -= 20;
                            Console.WriteLine($"Your health has increased by 10 and is now {run.player._defaulthealth}hp");
                        }
                        else
                        {
                            Console.WriteLine("You don't have enough coins to buy this upgrade.");
                        }
                        break;
                    case "2":
                        if (run.player._coins >= 20)
                        {
                            run.player._defaultmana += 10;
                            run.player._coins -= 20;
                            Console.WriteLine($"Your mana has increased by 10 and is now {run.player._defaultmana} mana");
                        }
                        else
                        {
                            Console.WriteLine("You don't have enough coins to buy this upgrade.");
                        }
                        break;
                    case "3":
                        if (run.player._coins >= 20)
                        {
                            run.player._wand._baseDmg += 5;
                            run.player._coins -= 20;
                            Console.WriteLine($"Your base damage has increased by 5 and is now {run.player._wand._baseDmg}dmg");
                        }
                        else
                        {
                            Console.WriteLine("You don't have enough coins to buy this upgrade.");
                        }
                        break;

                    case "4":
                        if (run.player._coins >= 50)
                        {
                            run.player._defaultmana += 10;
                            run.player._coins -= 20;
                            Console.WriteLine($"Your mana has increased by 10 and is now {run.player._defaultmana} mana");
                        }
                        else
                        {
                            Console.WriteLine("You don't have enough coins to buy this upgrade.");
                        }
                        break;
                }
            }
        }
    }
}
