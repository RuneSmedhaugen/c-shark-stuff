using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium
{
    internal class Run
    {
        List< Saltwater> salt = new List< Saltwater>();
        List< Freshwater> fresh = new List< Freshwater>();
        Fishtank fishtank = new Fishtank();

        public void RunProgram()
        {
            InitializeFreshwaterTank();
            InitializeSaltwaterTank();

            Menu();
        }

        private void InitializeSaltwaterTank()
        {
            foreach (Saltwater.FishSpecies species in Enum.GetValues(typeof(Saltwater.FishSpecies)))
            {
                salt.Add(new Saltwater(species));
            }
        }

        private void InitializeFreshwaterTank()
        {
            foreach (Freshwater.Freshwaterfish species in Enum.GetValues(typeof(Freshwater.Freshwaterfish)))
            {
                fresh.Add(new Freshwater(species));
            }
        }

        public void Menu()
        {
            Console.WriteLine("This is your personal Aquarium! First, would you like freshwater or saltwater? (fresh/salt)");
            var freshOrSalt = Console.ReadLine();

            if (freshOrSalt == "salt")
            {
                

                for (int i = 0; i < salt.Count; i++) 
                {
                    var fish = salt[i];
                    Console.WriteLine($@"{i + 1}: {fish.Name} {fish.Draw}
{fish.Description}
");
                }
            }
            else if (freshOrSalt == "fresh")
            {
                for (int i = 0; i < fresh.Count; i++)
                {
                    var freshfish = fresh[i];
                    Console.WriteLine($@"{i}: {freshfish.Name} {freshfish.Draw}
{freshfish.Description}
");
                }
            }

        }
    }
}
