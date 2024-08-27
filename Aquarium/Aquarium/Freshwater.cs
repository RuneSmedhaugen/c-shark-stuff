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

        private Freshwaterfish FishType { get; }

        public Freshwater(Freshwaterfish fishType) : base("","","")
        {
            FishType = fishType;
            FishProperties(fishType);
        }

        private void FishProperties(Freshwaterfish fish)
        {
            var fishData = new Dictionary<Freshwaterfish, Fish>
            {
                { Freshwaterfish.Bettafish, new Fish  (Name = "Bettafish", Description = "BETTAAAAAA!", Draw = ">\u00b0))'>") },
                { Freshwaterfish.Goldfish, new Fish  (Name = "Goldfish", Description = "Am I made of gold?!", Draw = "><(((('>") },
                { Freshwaterfish.NeonTetra, new Fish (Name = "NeonTetra", Description = "Riders of the storm...", Draw = "<><" ) },
                { Freshwaterfish.Guppy, new Fish (Name = "Guppy", Description = "Gupp gupp", Draw = ">))'>")  },
                { Freshwaterfish.ZebraDanio, new Fish (Name = "Zebra Danio", Description = "Didn't know Zebras had gills", Draw = "><))\">")  },
                { Freshwaterfish.OscarFish, new Fish (Name = "OscarFish", Description = "Thank you for this prize!", Draw = "><((\u00b0>")  },
                { Freshwaterfish.DiscusFish, new Fish (Name = "DiscusFish", Description = "Olympic medalist", Draw = "><{{{\u00b0>")  },
                { Freshwaterfish.CherryBarb, new Fish (Name = "CherryBarb", Description = "That's one fruit I would not eat.", Draw = "><>~")  },
                { Freshwaterfish.Rainbowfish, new Fish (Name = "Rainbowfish", Description = "Where is the pot of gold?!", Draw = "><>``")  },
                { Freshwaterfish.Pleco, new Fish (Name = "Pleco", Description = "The pleco is like the tank's personal vacuum cleaner—always on duty, never asking for a break!", Draw = ">\u00b0(((\u00b0)>") }
            };

            if (fishData.TryGetValue(fish, out Fish info))
            {
                Name = info.Name;
                Description = info.Description;
                Draw = info.Draw;
            }
        }
    }

}
