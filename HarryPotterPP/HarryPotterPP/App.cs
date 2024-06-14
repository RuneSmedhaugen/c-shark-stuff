using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotterPP
{
    internal class App
    {
        public Character harryPotter;
        public Item hedwig { get; set; }

        public Shop wandShop = new Shop("Wand shop");
        public Shop petStore = new Shop("Pet store");

        public List<Item> wandShopInventory = new()
        {
            new Item("Phoenix wand", "A wand made from phoenix feathers", "wand"),
            new Item("Unicorn wand", "A wand made from the horn of a unicorn", "wand"),
            new Item("Troll wand", "A wand made from troll toe nail clippings", "wand"),
        };

        public List<Item> petStoreInventory = new()
        {
            new Item("Owl", "Owls can fly.", "pet"),
            new Item("Rat", "Rats cannot fly", "pet"),
            new Item("Cat", "Cats are very happy that rats cannot fly", "pet"),
        };

        public List<Magic> wandMagic = new()
        {
            new Magic("vingardium leviosa", "You made a feather fly."),
            new Magic("Avada Kedavra", "You killed your pet. RIP"),
            new Magic("Alohomora", "You unlocked the door to Snape's private chambers. He was naked when you entered. RIP your eyes kekw"),
        };
        public void Run()
        {
            hedwig = new Item("Hedwig", "Hedwig is fat.", "pet");
            harryPotter = new Character("Harry Potter", "Gryffindor");
            harryPotter.Items.Add(hedwig);

            harryPotter.Introduction();
            MainMenu();
        }

        public void MainMenu()
        {
        var mainMenu = true;

            while (mainMenu)
            {
                Console.WriteLine(@"What would you like to do?
1. Go to Diagon Alley
2. Cast some magic
3. go to Spellbook");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        mainMenu = false;
                        GoToShop();
                        break;
                    case "2":
                        mainMenu = false;
                        DoSomeMagic();
                        break;
                    case "3":
                        foreach (var item in wandMagic)
                        Console.WriteLine(item.name);
                        break;
                    default:
                        Console.WriteLine("Invalid choice, try again");
                        break;
                }
            }
        }

        public void GoToShop()
        {
            var menu = true;
            while (menu)
            {

                Console.WriteLine(@"Which shop would you like to enter?
1. Ollivanders (Wand shop)
2. The magical menagerie (Pet store)");

                var input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        menu = false;
                        GoToWandShop();
                        break;
                    case "2":
                        menu = false;
                        GoToPetStore();
                        break;
                    default:
                        Console.WriteLine("You run face first into a brick wall, thinking it was a door...");
                        break;
                }
            }

        }

        public void GoToWandShop()
        {
            Console.WriteLine("Which wand would you like to buy?");
            for (int i = 0; i < wandShopInventory.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + wandShopInventory[i].Name + ", " + wandShopInventory[i].Description);
            }

            var input = Console.ReadLine();

            if (int.TryParse(input, out int choice) && choice > 0 && choice <= wandShopInventory.Count)
            {
                var selectWand = wandShopInventory[choice - 1];

                harryPotter.Items.Add(selectWand);
                Console.WriteLine($"You bought {selectWand.Name}");
                MainMenu();
            }
        }

        public void GoToPetStore()
        {
            Console.WriteLine("Which pet would you like to buy?");
            for (int i = 0; i < petStoreInventory.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + petStoreInventory[i].Name + ", " + petStoreInventory[i].Description);
            }

            var input = Console.ReadLine();

            if (int.TryParse(input, out int choice) && choice > 0 && choice <= petStoreInventory.Count)
            {
                var selectpet = petStoreInventory[choice - 1];

                harryPotter.Items.Add(selectpet);
                Console.WriteLine($"You bought {selectpet.Name}");
                MainMenu();
            }
        }
            public void DoSomeMagic()
        {
            while (true)
            {
                Console.WriteLine("Type in a spell or mainmenu to go back to the menu.");
                var input = Console.ReadLine().ToLower();

                if (input == "vingardium leviosa")
                {
                    Console.WriteLine("you made a feather fly");
                }
                else if (input == "avada kedavra")
                {
                    var pet = harryPotter.Items.FirstOrDefault(Item => Item.whatIs == "pet");
                    if (pet != null)
                    {
                        harryPotter.Items.Remove(pet);
                        Console.WriteLine($"You killed {pet.Name}. RIP");
                    }
                    else
                    {
                        Console.WriteLine("You killed yourself instead. u ded ggez");
                        Run();
                    }
                }
                else if (input == "alohamora")
                {
                    Console.WriteLine("You unlocked the door to Snape's private chambers. He was naked when you entered. RIP your eyes kekw.");
                }
                else if (input == "mainmenu")
                {
                    MainMenu();
                }
                else
                {
                    Console.WriteLine("You suck at spells, try again");
                }
            }

        }
    }


}




//Harry Pottah🥳l33t haxx0r
//Du skal starte med å lage en harrypotter character klasse med egenskaper som navn,
//house, inventory (ex wand eller pet)

//Få applikasjonen til å printe ut en introduksjon for karakteren,
//som sier noe om hva de heter, hvilket hus de er medlem av og hvilke items de har

//Karakteren skal ha mulighet til å gå inn i en Magibutikk, der kan de kjøpe et dyr:
//ugle, rotte eller en katt.
//De har også mulighet til å kjøpe en tryllestav: føniksstav, unikornstav eller trollstav.
//For å få til dette må du lage en egen klasse som er butikken,
//og presentere brukeren med en meny for hva personen skal kjøpe.

//Karakteren skal ha mulighet til å trylle - ta inn input fra brukeren,
//og dersom en skriver en riktig trylleformel skal det printes til skjermen at
//de har utført tryllingen

//trylleformler: 
//vingardium leviosa(får en fjær til å fly)
//hokus pokus(fyrer av fyrverkerier)