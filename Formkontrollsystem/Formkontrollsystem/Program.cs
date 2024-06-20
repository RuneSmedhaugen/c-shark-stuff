using System.Diagnostics;
using System.Formats.Asn1;
using Formkontrollsystem;


    


List<Shape> shapes = new List<Shape>()
{
    new Circle("Sirkel1", "rød", 20),
    new Circle("Sirkel2", "rød", 55),
    new Rectangle("Rektangel1", "blå", 20, 30),
    new Rectangle("Rektangel2", "blå", 45, 10),
    new Triangle("Trekant1", "rosa", 25, 20),
    new Triangle("Trekant2", "rosa", 8, 15),
};

while (true)
{
    Console.WriteLine(@"Velkommen. Hva vil du gjøre?
1: Se areal av sirkler
2: se areal av trekanter
3: se areal av rektangler
4: avslutt program"); 
    var input = Console.ReadLine();

    switch(input)
    {
        case "1":
            Console.Clear();
            foreach (var shape in shapes)
            {
                if (shape is Circle circle)
                {
                    
                    var area = circle.BeregnAreal();
                    Console.WriteLine($"Arealet til {circle.Name} er {area}");
                }
            }
            break;
        case "2":
            Console.Clear();
            foreach (var shape in shapes)
            {
                if (shape is Triangle triangle)
                {
                    
                    var area = triangle.BeregnAreal();
                    Console.WriteLine($"Arealet til {triangle.Name} er {area}");
                }
            }
            break;
        case "3":
            Console.Clear();
            foreach (var shape in shapes)
            {
                if (shape is Rectangle rectangle)
                {
                    
                    var area = rectangle.BeregnAreal();
                    Console.WriteLine($"Arealet til {rectangle.Name} er {area}");
                }
            }
            break;
        case "4":
            return;
        default:
            Console.Clear();
            Console.WriteLine("velg 1, 2 eller 3");
            break;
}
}




    
    