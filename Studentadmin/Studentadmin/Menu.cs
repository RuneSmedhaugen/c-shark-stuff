using System;

namespace Studentadmin
{
    internal class Menu
    {
        public Menu()
        {
            Student Bjarne = new Student("Bjarne", 16, "filosof", 1337);
            Student Lise = new Student("Lise", 19, "influenser", 6969);
            Student Arthur = new Student("Arthur", 69, "Komiker", 420);

            Fag Filosof = new Fag(5555, "Filosof", 2);
            Fag Influenser = new Fag(1111, "Influenser", 9001);
            Fag Komiker = new Fag(42069, "Komiker", 1000000000);

            Karakter bjarneKarakter = new Karakter("Bjarne", "Filosof", 4);
            Karakter liseKarakter = new Karakter("Lise", "Influenser", 2);
            Karakter arthurKarakter = new Karakter("Arthur", "Komiker", 6);

            bool mainMenu = true;

            while (mainMenu)
            {
                Console.WriteLine(@"Velkommen til hovedmenyen. Her er dine valg:
1: studentinfo
2: faginfo
3: karakterer
4: avslutt");
                string mainMenuChoice = Console.ReadLine();

                switch (mainMenuChoice)
                {
                    case "1":
                        ShowStudentMenu(Bjarne, Lise, Arthur);
                        break;
                    case "2":
                        ShowFagMenu(Filosof, Influenser, Komiker);
                        break;
                    case "3":
                        ShowKarakterMenu(bjarneKarakter, liseKarakter, arthurKarakter);
                        break;
                    case "4":
                        mainMenu = false;
                        break;
                    default:
                        Console.WriteLine("Ugyldig valg. Prøv igjen.");
                        break;
                }
            }
        }

        private void ShowStudentMenu(Student Bjarne, Student Lise, Student Arthur)
        {
            bool studentMenu = true;

            while (studentMenu)
            {
                Console.WriteLine(@"Velg student:
1: Bjarne
2: Lise
3: Arthur
4: tilbake til hovedmeny");
                string menuChoice = Console.ReadLine();

                switch (menuChoice)
                {
                    case "1":
                        Bjarne.SkrivUtInfo();
                        break;
                    case "2":
                        Lise.SkrivUtInfo();
                        break;
                    case "3":
                        Arthur.SkrivUtInfo();
                        break;
                    case "4":
                        studentMenu = false;
                        break;
                    default:
                        Console.WriteLine("Ugyldig valg. Prøv igjen.");
                        break;
                }
            }
        }

        private void ShowFagMenu(Fag Filosof, Fag Influenser, Fag Komiker)
        {
            bool fagMenu = true;
            while (fagMenu)
            {

            
                Console.WriteLine(@"Velg fag.
1: Filosof
2: Influenser
3: Komiker
4: tilbake til hovedmeny
");
            string fagChoice = Console.ReadLine();

            switch (fagChoice)
            {
                case "1":
                    Filosof.ShowInfo();
                    break;
                case "2":
                    Influenser.ShowInfo();
                    break;
                case "3":
                    Komiker.ShowInfo();
                    break;
                case "4":
                    fagMenu = false;
                    break;
                default:
                    Console.WriteLine("Ugyldig valg. Prøv igjen.");
                    break;
            }
            }
        }

        private void ShowKarakterMenu(Karakter bjarneKarakter, Karakter liseKarakter, Karakter arthurKarakter)
        {
            bool karakterMenu = true;
            while (karakterMenu)
            {
                Console.WriteLine(@"Velg student.
1: Bjarne
2: Lise
3: Arthur
4: tilbake til hovedmeny");
                string karakterChoice = Console.ReadLine();
                switch (karakterChoice)
                {
                    case "1":
                        bjarneKarakter.getInfo();
                        break;
                    case "2":
                        liseKarakter.getInfo();
                        break;
                    case "3":
                        arthurKarakter.getInfo();
                        break;
                    case "4":
                        karakterMenu = false;
                        break;
                    default:
                        Console.WriteLine("Ugyldig valg. Prøv igjen.");
                        break;
                }
            }
        }
    }
}
