using System.Runtime.CompilerServices;
using AppDomainSetup = System.AppDomainSetup;

namespace RollRadar.Models
{
    public class BowlingBall : Inherit
    {
        private string _brand;
        private decimal? _cost;
        private string _surface;
        private int _hookPotential;
        private string _type;

        public string brand { get { return _brand; } set { _brand = value; } }
        public decimal? cost { get { return _cost; } set { _cost = value; } }
        public string surface { get { return _surface; } set {_surface = value; } }
        public int hookPotential { get { return _hookPotential; } set { _hookPotential = value; } }
        public string type { get { return _type; } set { _type = value; } }

        public BowlingBall(string brand, decimal? cost, string surface, int hookPotential, string type, string name, string image, string comments) : base(name, image, comments)
        {
            this.brand = brand;
            this.cost = cost;
            this.surface = surface;
            this.hookPotential = hookPotential;
            this.type = type;
        }
    }
}
