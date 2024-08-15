using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter
{
    internal class Spells
    {
        public int _id { get; set; }
        public string _name { get; set; }
        public string _description { get; set; }
        public string _spellcast { get; set; }
        public int _maxDamage;
        public int _minDamage;
        public int _mana;

        public Spells(string Name, string Description, int MaxDamage, int MinDamage, int Mana, string SpellCast, int id)
        {
            _name = Name;
            _description = Description;
            _maxDamage = MaxDamage;
            _minDamage = MinDamage;
            _mana = Mana;
            _spellcast = SpellCast;
            _id = id;
        }

        public Spells()
        {

        }

        public static List<Spells> SpellList()
        {
            List<Spells> spells = new List<Spells>
            {
                new Spells("Aguamenti", "Conjure a stream of water to hit your enemy for 10-15dmg. Costs 20 mana", 15, 10, 20,
                    "casts Aguamenti and a stream of water deals", 1),
                new Spells("Brackium Emendo", "Heal yourself for 10-20 health. Costs 35 mana", 10, 20, 35, "casts Brackium Emendo and heals for",2),
                new Spells("Incendio", "Create a ball of fire to shoot at your enemy. Deals 12-18dmg. Costs 30 mana",12,18,30,"yells INCENDIO! and deals",3),
                new Spells("Fracto Strata", "Zap your enemy for 15-20dmg. Costs 40 mana",15,20,40,"casts Fracto Strata and sends out a zap that deals",4),
                new Spells("Everte Statum","Throw your enemy backward, dealing 8-12dmg. Costs 10 mana",8,12,10,"Takes a step forwards and yells Everte Statum, dealing",5),
                new Spells("Expulso", "Create a pressure explosion, dealing 1-50dmg. Costs 50 mana",1,50,50,"Tries to cast Expulso, creating a pressure explosion that deals",6),
                new Spells("Rictusempra","Tickle your enemy weak. Deal 10 damage. Costs 10 mana",10,10,10,"Yells RICTUSEMPRA, making the opponent roll of the floor laughing. deals",7),
            };
            return spells;
        }

        public static void AllSpells(Run run)
        {
            List<Spells> allSpells = SpellList();
            var i = 1;

            foreach (var spell in allSpells)
            {
                Console.WriteLine(@$"
{i}:
Name: {spell._name}
Description: {spell._description}");
                i++;
            }

            LearnSpell(run);
        }

        public static void LearnSpell(Run run)
        {
            Characters player = run.player;

          
            if (player._spells > 0)
            {
                
                Console.WriteLine("Type the number of the spell you want to learn:");
                var learnSpellInput = Console.ReadLine();

               
                if (int.TryParse(learnSpellInput, out int spellId))
                {
                    Spells selectedSpell = SpellList().FirstOrDefault(spell => spell._id == spellId);

                    if (selectedSpell != null)
                    {
                        run.playerSpells.Add(selectedSpell);
                        player._spells--;
                        Console.WriteLine($"You have learned the spell: {selectedSpell._name}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid spell ID! Please enter a valid number corresponding to a spell.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input! Please enter a valid number.");
                }
            }
            else
            {
                Console.WriteLine("You cannot learn any more spells. Your spell slots are full.");
            }
        }

    }
}
