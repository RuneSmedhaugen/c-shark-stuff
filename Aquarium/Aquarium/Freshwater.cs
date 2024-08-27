using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium
{
    internal class Freshwater : Fish
    {

        public enum Freshwaterfish
        {
            Bettafish,
            Goldfish,
            NeonTetra,
            Guppy,
            ZebraDanio,
            OscarFish,
            DiscusFish,
            CherryBarb,
            Rainbowfish,
            Pleco
        }

        public Freshwaterfish Fishes;

        public Freshwater(Freshwaterfish fishes) : base("", "", "")
        {
            Fishes = fishes;
            FishProperties(fishes);
        }

        public void FishProperties(Freshwaterfish Fishes)
        {
            switch (Fishes)
            {
                case Freshwaterfish.Bettafish:
                    Name = "Bettafish";
                    Description = "BETTAAAAAA!";
                    Draw = ">\u00b0))'>";
                    break;
                case Freshwaterfish.Goldfish:
                    Name = "Goldfish";
                    Description = "Am I made of gold?!";
                    Draw = "><(((('>";
                    break;
                case Freshwaterfish.NeonTetra:
                    Name = "NeonTetra";
                    Description = "Riders of the storm...";
                    Draw = "<><";
                    break;
                case Freshwaterfish.Guppy:
                    Name = "Guppy";
                    Description = "Gupp gupp";
                    Draw = ">))'>";
                    break;
                case Freshwaterfish.ZebraDanio:
                    Name = "Zebra Danio";
                    Description = "Didn't know Zebras had gills";
                    Draw = "><))\">";
                    break;
                case Freshwaterfish.OscarFish:
                    Name = "OscarFish";
                    Description = "Thank you for this prize!";
                    Draw = "><((\u00b0>";
                    break;
                case Freshwaterfish.DiscusFish:
                    Name = "DiscusFish";
                    Description = "Olympic medalist";
                    Draw = "><{{{\u00b0>";
                    break;
                case Freshwaterfish.CherryBarb:
                    Name = "CherryBarb";
                    Description = "That's one fruit I would not eat.";
                    Draw = "><>~";
                    break;
                case Freshwaterfish.Rainbowfish:
                    Name = "Rainbowfish";
                    Description = "Where is the pot of gold?!";
                    Draw = "><>``";
                    break;
                case Freshwaterfish.Pleco:
                    Name = "Pleco";
                    Description =
                        "The pleco is like the tank's personal vacuum cleaner—always on duty, never asking for a break!";
                    Draw = ">\u00b0(((\u00b0)>";
                    break;

            }
        }
    }

}
