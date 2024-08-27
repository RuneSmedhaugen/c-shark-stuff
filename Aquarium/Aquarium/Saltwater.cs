using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium
{
    internal class Saltwater : Fish
    {
        public enum FishSpecies
        {
            Clownfish,
            Angelfish,
            Pufferfish,
            Boxfish,
            Lionfish,
            Butterflyfish,
            Parrotfish,
            Goblinshark,
            Flyingfish,
            Mandarinfish
        }

        public FishSpecies Fishes;

        public Saltwater(FishSpecies fishes) : base("", "", "")
        {
            Fishes = fishes;
            FishProperties(fishes);

        }

        public void FishProperties(FishSpecies Fishes) //Har ikke gjort om dette til en dictionary enda
        {
            switch (Fishes)
            {
                case FishSpecies.Clownfish:
                    Name = "Clownfish";
                    Description = "Clownin' around";
                    Draw = "><(((º>";
                    break;
                case FishSpecies.Angelfish:
                    Name = "Angelfish";
                    Description = "Blesses you";
                    Draw = "><(((\u00b0>";
                    break;
                case FishSpecies.Pufferfish:
                    Name = "Pufferfish";
                    Description = "Huffin'n'puffin'";
                    Draw = "<\u00b0)))><";
                    break;
                case FishSpecies.Boxfish:
                    Name = "Boxfish";
                    Description = "Box box";
                    Draw = "[><>";
                    break;
                case FishSpecies.Lionfish:
                    Name = "Lionfish";
                    Description = "RAWR!";
                    Draw = ">))'>>";
                    break;
                case FishSpecies.Butterflyfish:
                    Name = "Butterflyfish";
                    Description = "Can't believe it's not butter!";
                    Draw = "><((º>";
                    break;
                case FishSpecies.Parrotfish:
                    Name = "Parrotfish";
                    Description = "Hello i am hooman squaak squaak";
                    Draw = "<\u00b0)))>< squawk";
                    break;
                case FishSpecies.Goblinshark:
                    Name = "Goblinshark";
                    Description = "Mines of moria is ours!";
                    Draw = "(v\u00b0\u00b0)v";
                    break;
                case FishSpecies.Flyingfish:
                    Name = "Flyingfish";
                    Description = "I believe I can flyyyyyy";
                    Draw = ">\u00b0)))\u00b0";
                    break;
                case FishSpecies.Mandarinfish:
                    Name = "Mandarinfish";
                    Description = "为什么鱼从来不做功课？ 因为它们总是“在水里”（在“逃避”）！";
                    Draw = "><(((\u00b0>";
                    break;
            }
        }
    }
}