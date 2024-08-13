using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HarryPotter
{
    internal class Run
    {
        private Items Store = new Items();
        private Characters character = new Characters();
        private SortingHat sortingHat = new SortingHat();
        public void Game()
        {
            Console.WriteLine($@"Welcome wizard, to Hogwards!");
            Console.WriteLine(@$"So you are the new student!
Now, before we can begin, you need to buy yourself a wand and a pet. Head over to the shop and get your desired items.");
            Console.WriteLine("You walk to Diagon Alley...");
            Shop();
        }

        public void Shop()
        {
            Console.WriteLine("You arrive at Diagon Alley and first goes into the petstore...");
            var playerPet = PetStore();
            Console.WriteLine("After buying your pet, you walk into Ollivanders: Makers of Fine Wands since 382 B.C.");
            var playerWand = WandStore();
            Console.WriteLine("After buying your wand, you start walking back....");
            CreateCharacter(playerPet, playerWand);
        }

        public Items PetStore()
        {
            Console.WriteLine("Some old weird dude welcomes you to the store.");

                Console.WriteLine($@"So, what pet are you looking to buy today?");
                var petType = Console.ReadLine();
                Console.WriteLine($"How would you describe {petType}?");
                var petDescription = Console.ReadLine();
                Console.WriteLine("Great, now you just need to give your new pet a name");
                var petName = Console.ReadLine();
                Items playerPet = new Items(petName, petType, petDescription);
                Console.WriteLine("Thank you for your purchase, have a good day!");
                return playerPet;
        }

        public Items WandStore()
        {
            Console.WriteLine("Ollivanders looks at you and welcomes you to his shop.");
            Console.WriteLine("New wizard in town eh? So, first things first, what kind of wand are you looking for? (one word)");
            var wandName = Console.ReadLine();
            Console.WriteLine($"Hmm i may have something similar to a {wandName}... Ah yes here it is! how would you describe this wand?");
            var wandDescription = Console.ReadLine();
            Console.WriteLine("Sounds about right. Here is your new wand! Goodbye.");
            Items playerWand = new Items(wandName, "wand", wandDescription);
            return playerWand;
        }


        public Characters CreateCharacter(Items playerWand, Items playerPet)
        {
            var (Nice,Insult, House) = sortingHat.SelectedSenteces();

            Console.WriteLine(@"You return to Hogwards, and gather in the great hall among the other students.
Principal Snape holds a speech and it's time to get sorted to a House by the sorting hat.
After a while Snape calls your name...");
            var playerName = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($@"'{playerName}!' he yells. You step up and sit down on the chair in front of everyone
the sorting hat is placed on your head...
'Hmmmm...' the sorting hat goes... 'this one is very {Nice._sentences}... but also {Insult._sentences}...
'AH I KNOW! I WILL PLACE YOU IN............... 
...
.......
...........
{House._sentences}!!!!!!!!

Everyone in {House._sentences} clapped and welcomed you to their House.");
            Characters player = new Characters(playerName, House, 100, playerWand, playerPet);
            return player;
        }
    }
}
