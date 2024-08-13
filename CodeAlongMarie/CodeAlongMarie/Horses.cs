using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAlongMarie
{
    internal class Horses
    {
        public string _name { get; private set; }
        public int _speed { get; private set; }
        public int Position { get; private set; }

        public Horses(string Name, int Speed)
        {
            _name = Name;
            _speed = Speed;
            Position = 0;
        }

        public void Run()
        {
            Position += _speed;
        }

        public string FeedHorse()
        {
            var Feed = "You fed the horse";
            return Feed;
        }

        public string BrushHorse()
        {
            var brush = "You brushed the horse so it's looking sparkling and pretty!";
            return brush;
        }
    }
}
