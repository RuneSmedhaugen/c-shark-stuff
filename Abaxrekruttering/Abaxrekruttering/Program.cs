
using Abaxrekruttering;

Boat boat = new Boat("ABC123", 100, 30, 500);
Plane plane = new Plane("LN1234", 100, 30, 2, 10, "jetfly");
Car car1 = new Car("NF123456", 147,200,"grønn","lett kjøretøy");
Car car2 = new Car("NF54321",150,195,"blå","lett kjøretøy");

while (true)
{


Console.WriteLine(@"Hei og velkommen til Abaxrekruttering.
Meny:
1: se båt
2: se fly
3: se biler
4: Sammenlign bilene
5: kjør en bil
6: fly et fly");
var input = Console.ReadLine();


switch (input)
{
    case "1":
        Console.Clear();
       Console.WriteLine(boat.PrintInfo());
        break;
    case "2":
        Console.Clear();
            Console.WriteLine(plane.PrintInfo());
            break;
    case "3":
        Console.Clear();
        Console.WriteLine(car1.PrintInfo());
        Console.WriteLine(car2.PrintInfo());
            break;
    case "4":
        Console.Clear();
            CheckIfSameCar();
        break;
    case "5":
        Console.Clear();
            Console.WriteLine($"Du setter deg i bilen med reg. nr {car1.Name} kjører avgårde! WROOM WROOM");
        break;
    case "6":
        Console.Clear();
            Console.WriteLine(
            $"Du setter deg i flyet med kjennetegn {plane.Name}, dessverre kan du ikke å fly så du kommer ingen sted. kekw");
        break;
    default:
        Console.Clear();
            Console.WriteLine("Velg et tall mellom 1-6 plz");
        break;
}
}

void CheckIfSameCar()
{
    Console.WriteLine(@$"Bilene har reg. nr {car1.Name} og {car2.Name}
Det er ikke samme bil. kekw");
}