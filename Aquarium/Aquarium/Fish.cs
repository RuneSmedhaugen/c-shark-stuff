using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium
{
    internal class Fish
    {
        private string _name;
        private string _description;
        private string _draw;
        private int _x;
        private int _y;

        public string Name
        {
            get { return _name; }
            protected set { _name = value; }
        }

        public string Description
        {
            get { return _description; }
            protected set { _description = value; }
        }

        public string Draw
        {
            get { return _draw; }
            protected set { _draw = value; }
        }

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public Fish(string name, string description, string draw)
        {
            _name = name;
            _description = description;
            _draw = draw;
        }
    }
}
