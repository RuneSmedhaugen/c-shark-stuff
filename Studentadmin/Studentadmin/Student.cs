namespace Studentadmin
{
    internal class Student
    {
        private string _name;
        private int _age;
        private string _studyProgram;
        private int _studentID;

        public Student(string name, int age, string studyProgram, int studentID)
        {
            _name = name;
            _age = age;
            _studyProgram = studyProgram;
            _studentID = studentID;
        }

       
        public void SkrivUtInfo()
        {
            Console.WriteLine($@"
Navn: {_name}
Alder: {_age}
Studieprogram: {_studyProgram}
Student ID: {_studentID}
");
        }
    }
}