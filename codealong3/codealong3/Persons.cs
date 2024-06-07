using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace codealong3
{
    internal class Persons
    {
        private string _name;
        private int _age;
        private string _adress;


        public Persons(string Name, int Age, string Adress)
        {
            _name = Name;
            _age = Age;
            _adress = Adress;
        }

        public int Age { get { return _age; } }
        public string Adress { get { return _adress;} }
        public string Name { get { return _name;} }
    }


}
