using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium
{
    internal class Run
    {
        List<Saltwater> salt = new List<Saltwater>();
        List<Freshwater> fresh = new List<Freshwater>();
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
            Console.WriteLine(
                "This is your personal Aquarium! Here are your options:" +
                "1: Add freshwater fish" +
                "2: add saltwater fish" +
                "3: view your fishtank" +
                "4: exit program");
            var input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    ShowFishOptions(fresh);
                    break;
                case "2":
                    ShowFishOptions(salt);
                    break;
                case "3":
                    ShowFishtank();
                    break;
                case "4":
                    return;
            }

        }

        private void ShowFishOptions<T>(List<T> fishList) where T : Fish
        {
            while (true)
            {
                for (int i = 0; i < fishList.Count; i++)
                {
                    var fish = fishList[i];
                    Console.WriteLine($@"{i + 1}: {fish.Name} {fish.Draw}
{fish.Description}
");
                }

                Console.WriteLine("Enter the number of a fish you want to add to your aquarium");
                int fishIndex = int.Parse(Console.ReadLine() ?? "0");

                if (fishIndex > 0 && fishIndex <= fishList.Count)
                {
                    var selectedFish = fishList[fishIndex -1];
                    fishtank.AddFish(selectedFish);
                    fishtank.PrintFishTank();
                    fishtank.DisplayFish();
                    break;
                }
            }
        }

        public void ShowFishtank()
        {

        }
    }
}
