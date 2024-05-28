using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = System.Console;

namespace Studentadmin
{
    internal class Fag
    {
        private int _fagKode;
        private string _fagName;
        private int _studyPoints;

        public Fag(int fagKode, string fagName, int studyPoints)
        {
            _fagKode = fagKode;
            _fagName = fagName;
            _studyPoints = studyPoints;
        }
        

        public void ShowInfo()
        {
            Console.WriteLine($@"
Navn: {_fagName}
Fag kode: {_fagKode}
Studiepoeng: {_studyPoints}");
        }
    }
}
