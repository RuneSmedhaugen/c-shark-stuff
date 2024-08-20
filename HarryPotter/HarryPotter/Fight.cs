using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter
{
    internal class Fight
    {
        Random random = new Random();

        public Fight()
        {
        }

        public List<Spells> EnemySpells(List<Spells> allSpells)
        {
            List<Spells> enemySpells = new List<Spells>();

            while (enemySpells.Count < 3)
            {
                Spells randomSpell = allSpells[random.Next(allSpells.Count)];

                if (!enemySpells.Contains(randomSpell))
                {
                    enemySpells.Add(randomSpell);
                }
            }

            return enemySpells;
        }


        public void Battle(Run run, Characters characters)
        {
            var enemySpells = EnemySpells(Spells.SpellList());
            var enemy = characters.Enemies();
            run.player._health = run.player._defaulthealth;
            run.player._mana = run.player._defaultmana;

            Console.WriteLine($@"Your enemy this round is: {enemy._name}
Health: {enemy._health}
Mana: {enemy._mana}");

            while (enemy._health > 0 && run.player._health > 0)
            {
                var ranSpell = random.Next(run.playerSpells.Count);
                var spellCast = run.playerSpells[ranSpell];
                var dmg = random.Next(spellCast._minDamage, spellCast._maxDamage + 1);
                var enemyranSpell = random.Next(enemySpells.Count);
                var enemySpellCast = enemySpells[enemyranSpell];
                var enemyDmg = random.Next(enemySpellCast._minDamage, enemySpellCast._maxDamage);
                var critChance = random.Next(101);

                //SPILLEEREN SIN TUR
                if (run.player._crit >= critChance)
                {
                    dmg = dmg * 2;

                    if (spellCast._mana <= run.player._mana)

                    {
                        if (run.playerSpells[ranSpell]._id == 2)
                        {
                            run.player._health += dmg;
                            Console.WriteLine(@$"{run.player._name} {spellCast._spellcast} {dmg}(CRIT!) to himself

{run.player._name} health: {run.player._health}
{enemy._name} health: {enemy._health}
");

                        }
                        else
                        {
                            enemy._health -= dmg;
                            Console.WriteLine(
                                $@"{run.player._name} {spellCast._spellcast} {dmg}(CRIT!) damage to {enemy._name}
{run.player._name} health: {run.player._health}
{enemy._name} health: {enemy._health}
");
                        }
                    }
                }
                else if (spellCast._mana <= run.player._mana)

                {
                    if (run.playerSpells[ranSpell]._id == 2)
                    {
                        run.player._health += dmg;
                        Console.WriteLine(@$"{run.player._name} {spellCast._spellcast} {dmg} to himself

{run.player._name} health: {run.player._health}
{enemy._name} health: {enemy._health}
");

                    }
                    else
                    {
                        enemy._health -= dmg;
                        Console.WriteLine($@"{run.player._name} {spellCast._spellcast} {dmg} damage to {enemy._name}
{run.player._name} health: {run.player._health}
{enemy._name} health: {enemy._health}
");

                    }

                    if (enemy._health <= 0)
                    {
                        Console.WriteLine($"{enemy._name} Has been defeated!");
                        run.player._level += 1;
                        Console.WriteLine($"Your level is now {run.player._level}");
                        run.player._coins += 10;
                        Console.WriteLine($"You gained 10 coins. You have {run.player._coins} coins");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine($@"You don't have enough mana to cast this spell and regained 10 Mana instead.
");
                    run.player._mana += 10;
                }

                //FIENDE SIN TUR
                if (enemy._crit >= critChance)
                {
                    enemyDmg = enemyDmg * 2;
                    if (enemy._mana >= enemy._mana)
                    {
                        if (enemySpellCast._id == 2)
                        {
                            enemy._health += enemyDmg;
                            Console.WriteLine($@"{enemy._name} {enemySpellCast._spellcast} {enemyDmg}

{run.player._name} health: {run.player._health}
{enemy._name} health: {enemy._health}
");

                        }
                        else
                        {
                            run.player._health -= enemyDmg;
                            Console.WriteLine(
                                $@"{enemy._name} {enemySpellCast._spellcast} {enemyDmg} damage to {run.player._name}

{run.player._name} health: {run.player._health}
{enemy._name} health: {enemy._health}

");
                        }

                        if (run.player._health <= 0)
                        {
                            Console.WriteLine($"{run.player._name} has been defeated! You lost.");
                            break;
                        }

                    }
                    else
                    {
                        Console.WriteLine($@"{enemy._name} doesn't have enough mana and regained 10 mana.

");
                        enemy._mana += 10;
                    }
                }
                else
                {
                    if (enemy._mana >= enemy._mana)
                    {
                        if (enemySpellCast._id == 2)
                        {
                            enemy._health += enemyDmg;
                            Console.WriteLine($@"{enemy._name} {enemySpellCast._spellcast} {enemyDmg}

{run.player._name} health: {run.player._health}
{enemy._name} health: {enemy._health}
");

                        }
                        else
                        {
                            run.player._health -= enemyDmg;
                            Console.WriteLine($@"{enemy._name} {enemySpellCast._spellcast} {enemyDmg} damage to {run.player._name}

{run.player._name} health: {run.player._health}
{enemy._name} health: {enemy._health}

");
                        }
                        if (run.player._health <= 0)
                        {
                            Console.WriteLine($"{run.player._name} has been defeated! You lost.");
                            break;
                        }

                    }
                    else
                    {
                        Console.WriteLine($@"{enemy._name} doesn't have enough mana and regained 10 mana.

");
                        enemy._mana += 10;
                    }
                }
            }
        }
    }
}
