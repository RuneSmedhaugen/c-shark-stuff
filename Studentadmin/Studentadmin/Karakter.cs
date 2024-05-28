using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentadmin
{
    internal class Karakter
    {
        private string _student;
        private string _fag;
        private int _grade;

        public Karakter(string student, string fag, int grade)
        {
            _student = student;
            _fag = fag;
            _grade = grade;
        }

        public void getInfo()
        {
            Console.WriteLine(@$"
Student: {_student}
Fag: {_fag}
Karakter: {_grade}
");
        }
    }
}
