using System.Runtime.CompilerServices;
using AppDomainSetup = System.AppDomainSetup;

namespace RollRadar.Models
{
    public class BowlingBall
    {
        private int _id;
        private string _brand;
        private decimal? _cost;
        private string _surface;
        private int _hookPotential;
        private string _type;
        private string _image;

        public int Id { get { return _id; }
            private set => Id = value;
        }

        public string Brand { get { return _brand; } set { _brand = value; } }
        public decimal? Cost { get { return _cost; } set { _cost = value; } }
        public string Surface { get { return _surface; } set {_surface = value; } }
        public int HookPotential { get { return _hookPotential; } set { _hookPotential = value; } }
        public string Type { get { return _type; } set { _type = value; } }
        public string Image { get { return _image; } set { _image = value; } }

        public BowlingBall(string brand, decimal? cost, string surface, int hookPotential, string type, string image)
        {
            _brand = brand;
            _cost = cost;
            _surface = surface;
            _hookPotential = hookPotential;
            _type = type;
            _image = image;
        }
    }
}
